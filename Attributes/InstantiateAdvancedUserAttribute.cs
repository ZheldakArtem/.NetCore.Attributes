using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class InstantiateAdvancedUserAttribute : InstantiateUserAttribute
    {
        public int? ExternalId { get; set; }
        
        public InstantiateAdvancedUserAttribute(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            this.ExternalId = null;
        }

        public InstantiateAdvancedUserAttribute(int id, string firstName, string lastName, int externalId) : base(id, firstName, lastName)
        {
            this.ExternalId = externalId;
        }
    }
}