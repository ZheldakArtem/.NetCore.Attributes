using System;

namespace Attributes
{  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntValidatorAttribute : Attribute
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public IntValidatorAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
