using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingSample.Models;

namespace UnitTestingSample.RepositoryInterface
{
    public interface IUserRepository
    {
        void DeleteUser(int id);
        User AddUser(User user);
    }
}
