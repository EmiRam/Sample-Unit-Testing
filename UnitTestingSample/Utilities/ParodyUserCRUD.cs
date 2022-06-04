using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingSample.Models;

namespace UnitTestingSample.Utilities
{
    public class ParodyUserCRUD
    {
        public static User FindUser(int id)
        {
            User user;
            if (id > 0)
            {
                 user = new User
                {
                    Id = id,
                    Name = "AName",
                    Email = "a@a.com",
                    FavouriteColor = "Green"
                };
            } else
            {
                 user = null;
            }
            

            return user;
        }

        public static void DeleteUser(User user)
        {
            var testString = "This method doesn't do anything for now";
            testString.ToLower();
        }

        public static void AddUser(User user)
        {
            var testString = "This method doesn't do anything for now";
            testString.ToLower();
        }
    }
}
