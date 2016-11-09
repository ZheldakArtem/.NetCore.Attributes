using System;

namespace Attributes
{
    // Matches a .ctor parameter with property. Needs to get a default value from property field, and use this value for calling .ctor.
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
    public class MatchParameterWithPropertyAttribute : Attribute
    {
        public string ParameterName { get; set; }

        public string PropertyName { get; set; }

        public MatchParameterWithPropertyAttribute(string parameter, string property)
        {
            this.ParameterName = parameter;
            this.PropertyName = property;
        }
    }
}
