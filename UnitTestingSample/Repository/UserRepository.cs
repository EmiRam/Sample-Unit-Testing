using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingSample.Models;
using UnitTestingSample.RepositoryInterface;
using UnitTestingSample.Utilities;

namespace UnitTestingSample.Repository
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            //do any additional processing necessary
            user.Email = user.Email.ToLower();

            //we're assuming that the CRUD operations have their own unit tests handled like the "utility" example
            //and could be part of a different package (like SharedCode)
            ParodyUserCRUD.AddUser(user);
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = ParodyUserCRUD.FindUser(id);

            if (user == null)
            {
                throw new ArgumentException();
            }
            ParodyUserCRUD.DeleteUser(user);
        }
    }
}
