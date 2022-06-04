using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTestingSample.Models;
using UnitTestingSample.Repository;
using UnitTestingSample.RepositoryInterface;

namespace UnitTestingSample.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        //constructors will also have the Configuration DI
        public UserController(IUserRepository userRepository = null)
        {
            _userRepository = userRepository ?? new UserRepository();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            //or !ModelState.IsValid
            if (user.Name == null)
            {
                //possibly do some logging here
                throw new ArgumentException();
            }

            _userRepository.AddUser(user);
            return RedirectToAction("Index", "Home");

        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                //possibly do some logging
                throw;
            }

        }
    }
}