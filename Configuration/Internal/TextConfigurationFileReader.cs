using Configuration.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Configuration.Internal
{
    class TextConfigurationFileReader : IConfigurationFileReader
    {
        public ConfigurationSection[] Read(string fileName)
        {
            Regex sectionDeclarationRegex = new Regex(@"\[(?<SectionName>[^\]]+)", RegexOptions.Compiled);
            Regex commentsRemoveRegex = new Regex(@"(//.*$)|(/\*[^(\*/)]+\*/)", RegexOptions.Compiled | RegexOptions.Multiline);
            Regex propertyRegex = new Regex("(?<PropertyName>[^=]+)=(?<PropertyValue>.+)", RegexOptions.Compiled | RegexOptions.Singleline);

            List<ConfigurationSection> sections = new List<ConfigurationSection>();
            string configurationFileContent;

            try
            {
                configurationFileContent = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationFileNotFoundException(fileName, ex);
            }

            string[] lines = commentsRemoveRegex.Replace(configurationFileContent, string.Empty).Split('\n').Select(line => line.Trim()).Where(line => !string.IsNullOrEmpty(line)).ToArray();
            ConfigurationSection section = null;

            foreach (var line in lines)
            {
                if (sectionDeclarationRegex.Match(line).Success)
                {
                    // New section
                    section = new ConfigurationSection(sectionDeclarationRegex.Match(line).Groups["SectionName"].Value);
                    sections.Add(section);
                }
                else
                {
                    if (section == null)
                        throw new BadConfigurationFileException(
                            string.Format("Section must be declared before property. Line = '{0}'", line));

                    Match propertyMatch = propertyRegex.Match(line);
                    if (propertyMatch.Success)
                        section.AddProperty(
                            propertyMatch.Groups["PropertyName"].Value.Trim(),
                            propertyMatch.Groups["PropertyValue"].Value.Trim());   
                }
            }

            return sections.ToArray();
        }
    }
}
