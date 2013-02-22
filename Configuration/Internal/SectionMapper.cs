using Configuration.Attributes;
using Configuration.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Internal
{
    class SectionMapper
    {
        private void PropertiesCheck(Type targetType, ConfigurationSection section, bool strict)
        {
            if (strict && !Attribute.IsDefined(targetType, typeof(ConfigurationSectionAttribute), true))
                throw new NoConfigurationClassException(targetType);

            Dictionary<string, PropertyInfo> targetProperties
                = targetType.GetProperties().ToDictionary(GetConfigurationPropertyName);

            foreach (var sectionProperty in section.Properties)
            {
                PropertyInfo targetProperty = targetProperties[sectionProperty.Key];

                if (!targetProperties.ContainsKey(sectionProperty.Key))
                    throw new TargetPropertyNotFoundException(targetType, targetProperty);

                if (strict && !Attribute.IsDefined(targetProperty, typeof(ConfigurationPropertyAttribute), true))
                    throw new NoConfigurationPropertyException(targetType, targetProperty);
            }
        }

        private string GetConfigurationPropertyName(PropertyInfo property)
        {
            if (!Attribute.IsDefined(property, typeof(ConfigurationPropertyAttribute), true))
                return property.Name;

            ConfigurationPropertyAttribute configurationField 
                = Attribute.GetCustomAttribute(property, typeof(ConfigurationPropertyAttribute)) as ConfigurationPropertyAttribute;

            return string.IsNullOrEmpty(configurationField.FieldName) ?  property.Name : configurationField.FieldName;
        }

        public T MapSection<T>(ConfigurationSection section, bool strict)
            where T : class, new()
        {
            Type targetType = typeof(T);
            T target = new T();

            PropertiesCheck(targetType, section, strict);

            Dictionary<string, PropertyInfo> targetProperties = targetType.GetProperties().ToDictionary(GetConfigurationPropertyName);

            foreach (var sectionProperty in section.Properties)
                targetProperties[sectionProperty.Key].SetValue(
                    target, 
                    Convert.ChangeType(
                        sectionProperty.Value, targetProperties[sectionProperty.Key].PropertyType));
            
            return target;
        }

    }
}
