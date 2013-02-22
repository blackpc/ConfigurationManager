using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration.Attributes;
using Configuration.Internal;
using Configuration.Exceptions;

namespace Configuration
{
    public class ConfigurationManager
    {
        private static readonly SectionMapper _mapper = new SectionMapper();
        private static readonly Dictionary<string, Dictionary<string, ConfigurationSection>> _configurationSets = new Dictionary<string, Dictionary<string, ConfigurationSection>>();

        private static void CheckSet(string setName)
        {
            if (!_configurationSets.ContainsKey(setName))
                throw new ConfigurationSetNotExistsException(setName);
        }

        private static void CheckSection(string setName, string sectionName)
        {
            CheckSet(setName);
            if (!_configurationSets[setName].ContainsKey(sectionName))
                throw new SectionNotFoundException(sectionName, setName);
        }

        private static void CheckProperty(string setName, string sectionName, string propertyName)
        {
            CheckSection(setName, sectionName);
            if (!_configurationSets[setName][sectionName].Properties.ContainsKey(propertyName))
                throw new PropertyNotFoundException(setName, sectionName, propertyName);
        }

        private static string ResolveTypeToSectionName<T>()
        {
            if (Attribute.IsDefined(typeof(T), typeof(ConfigurationSectionAttribute), true))
            {
                var configurationClassAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(ConfigurationSectionAttribute), true) as ConfigurationSectionAttribute;
                return string.IsNullOrEmpty(configurationClassAttribute.ClassName) ? typeof(T).Name : configurationClassAttribute.ClassName;
            }

            return typeof(T).Name;
        }

        public static void Load(string setName, string configurationfileName)
        {
            TextConfigurationFileReader reader = new TextConfigurationFileReader();
            var sections = reader.Read(configurationfileName);
            _configurationSets.Add(setName, sections.ToDictionary(s => s.Name));
        }

        public static T GetClass<T>(string setName)
            where T : class, new()
        {
            string resolvedSectionName = ResolveTypeToSectionName<T>();

            CheckSection(setName, resolvedSectionName);

            ConfigurationSection section = _configurationSets[setName][resolvedSectionName];
            T target = _mapper.MapSection<T>(section, true);
            return target;
        }

        public static T GetValue<T>(string setName, string sectionName, string propertyName)
        {
            CheckProperty(setName, sectionName, propertyName);
            T converted;

            try
            {
                converted = (T)Convert.ChangeType(_configurationSets[setName][sectionName].Properties[propertyName], typeof(T));
            }
            catch
            {
                throw new PropertyTypeMismatchException(
                    setName,
                    sectionName,
                    propertyName,
                    _configurationSets[setName][sectionName].Properties[propertyName].GetType(),
                    typeof(T));
            }

            return converted;
        }
    }
}
