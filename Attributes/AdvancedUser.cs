using System.ComponentModel;

namespace Attributes
{
    public class AdvancedUser : User
    {
        public int _externalId;

        [DefaultValue(3443454)]
        public int ExternalId
        {
            get
            {
                return this._externalId;
            }
        }

        [MatchParameterWithProperty("id", "Id")]
        [MatchParameterWithProperty("externalId", "ExternalId")]
        public AdvancedUser(int id, int externalId) : base(id)
        {
            this._externalId = externalId;
        }
    }
}
