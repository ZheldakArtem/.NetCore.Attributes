using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    public static class Creator
    {
        public static User[] CreateUsers()
        {
            var users = new List<User>();

            Type[] p = { typeof(int) };
            var matchAttr = (MatchParameterWithPropertyAttribute)typeof(User).GetConstructor(p).GetCustomAttribute(typeof(MatchParameterWithPropertyAttribute), false);

            var defaultIdAttr = (DefaultValueAttribute)typeof(User).GetProperty(matchAttr.PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));

            var defaultId = (int)defaultIdAttr.Value;

            foreach (InstantiateUserAttribute attr in typeof(User).GetCustomAttributes(typeof(InstantiateUserAttribute), false))
            {
                users.Add(new User(attr.Id == null ? defaultId : (int)attr.Id)
                {
                    FirstName = attr.FirstName,
                    LastName = attr.LastName,
                });
            }

            return users.ToArray();
        }

        public static AdvancedUser[] CreateAdvancedUser()
        {
            var assy = typeof(AdvancedUser).Assembly;

            var users = new List<AdvancedUser>();

            Type[] p = { typeof(int), typeof(int) };

            var matchAttr = (MatchParameterWithPropertyAttribute[])typeof(AdvancedUser).GetConstructor(p).GetCustomAttributes(typeof(MatchParameterWithPropertyAttribute), false);

            var defAttrId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.First().PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            var defId = (int)defAttrId.Value;

            var defExAttrId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.Last().PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            var defExId = (int)defExAttrId.Value;
            
            foreach (InstantiateAdvancedUserAttribute attr in Attribute.GetCustomAttributes(assy, typeof(InstantiateAdvancedUserAttribute)))
            {
                users.Add(new AdvancedUser(attr.Id == null ? defId : (int)attr.Id, attr.ExternalId == null ? defId : (int)attr.ExternalId)
                {
                    FirstName = attr.FirstName,
                    LastName = attr.FirstName,
                });
            }

            return users.ToArray();
        }
    }
}