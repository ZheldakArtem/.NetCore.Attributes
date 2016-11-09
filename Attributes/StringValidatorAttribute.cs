using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class StringValidatorAttribute : Attribute
    {
        public int MaxLength { get; set; }

        public StringValidatorAttribute(int length)
        {
            this.MaxLength = length;
        }
    }
}
