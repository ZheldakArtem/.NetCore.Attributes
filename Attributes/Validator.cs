using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public static class Validator
    {
        public static void IsValid(User[] user)
        {
            IntValid(user);

            StrValid(user);
        }

        private static void StrValid(User[] users)
        {
            var fields = new List<FieldInfo>();
            foreach (var user in users)
            {
                foreach (var item in typeof(User).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (item.GetCustomAttributes(typeof(StringValidatorAttribute), false).Count() != 0)
                    {
                        fields.Add(item);
                    }
                }

                foreach (var field in fields)
                {
                    var attr = (StringValidatorAttribute)field.GetCustomAttribute(typeof(StringValidatorAttribute), false);
                    if (((string)field.GetValue(user)).Length > attr.MaxLength)
                    {
                        throw new ArgumentException($"Length {field.Name} must be < {attr.MaxLength}");
                    }
                }

                var properties = new List<PropertyInfo>();

                foreach (var item in typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (item.GetCustomAttributes(typeof(StringValidatorAttribute), false).Count() != 0)
                    {
                        properties.Add(item);
                    }
                }

                foreach (var property in properties)
                {
                    var attr = (StringValidatorAttribute)property.GetCustomAttribute(typeof(StringValidatorAttribute), false);
                    if (((string)property.GetValue(user)).Length > attr.MaxLength)
                    {
                        throw new ArgumentException($"Length {property.Name} must be < {attr.MaxLength}");
                    }
                }
            }
        }

        private static void IntValid(User[] users)
        {
            var fields = new List<FieldInfo>();
            foreach (var user in users)
            {
                foreach (var item in typeof(User).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (item.GetCustomAttributes(typeof(IntValidatorAttribute), false).Count() != 0)
                    {
                        fields.Add(item);
                    }
                }

                foreach (var field in fields)
                {
                    var attr = (IntValidatorAttribute)field.GetCustomAttribute(typeof(IntValidatorAttribute), false);

                    if ((int)field.GetValue(user) > attr.Max || (int)field.GetValue(user) < attr.Min)
                    {
                        throw new ArgumentException($"{field.Name} must be between {attr.Min} and {attr.Max}.");
                    }
                }

                var properties = new List<PropertyInfo>();

                foreach (var item in typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (item.GetCustomAttributes(typeof(IntValidatorAttribute), false).Count() != 0)
                    {
                        properties.Add(item);
                    }
                }

                foreach (var property in properties)
                {
                    var attr = (IntValidatorAttribute)property.GetCustomAttribute(typeof(IntValidatorAttribute), false);

                    if ((int)property.GetValue(user) > attr.Max || (int)property.GetValue(user) < attr.Min)
                    {
                        throw new ArgumentException($"{property.Name} must be between {attr.Min} and {attr.Max}.");
                    }
                }
            }
        }
    }
}
