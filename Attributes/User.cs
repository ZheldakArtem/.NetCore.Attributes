using System.ComponentModel;

namespace Attributes
{
    [InstantiateUser("Alexander", "Alexandrov")]
    [InstantiateUser(2, "Semen", "Semenov")]
    [InstantiateUser(3, "Petr", "Petrov")]
    public class User
    {
        [IntValidator(1, 1000)]
        private int _id;

        [DefaultValue(1)]
        public int Id
        {
            get
            {
                return this._id;
            }

            set
            {
                this._id = value;
            }
        }

        [StringValidator(30)]
        public string FirstName { get; set; }

        [StringValidator(20)]
        public string LastName { get; set; }

        [MatchParameterWithProperty("id", "Id")]
        public User(int id)
        {
            this._id = id;
        }
    }
}
