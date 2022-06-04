using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using UnitTestingSample.AggregatorInterface;
using UnitTestingSample.Controllers;
using UnitTestingSample.Models;
using UnitTestingSample.RepositoryInterface;
using UnitTestingSample.Utilities;
using Xunit;

namespace TestProject
{
    public class UserRepositoryTests
    {
        [Fact]
        public void DeleteUser_ValidUserId_UserIsDeleted()
        {
            var userRepository = new Mock<IUserRepository>();
            var controller = new UserController(userRepository.Object);

            IActionResult result = controller.DeleteUser(1);

            userRepository.Verify(m => m.DeleteUser(1));
        }

        [Fact]
        public void RegisterUser_ValidUser_UserIsAdded()
        {
            var userRepository = new Mock<IUserRepository>();
            var controller = new UserController(userRepository.Object);

            User user = new User
            {
                Id = 1,
                Name = "AName",
                FavouriteColor = "Red",
                Email = "a@a.com"
            };

            IActionResult result = controller.RegisterUser(user);

            userRepository.Verify(m => m.AddUser(user));
        }

        [Fact]
        public void RegisterUser_InValidUser_ExceptionThrown()
        {
            var userRepository = new Mock<IUserRepository>();
            var controller = new UserController(userRepository.Object);

            User user = new User();
   
            //IActionResult result = controller.RegisterUser(user);

            Assert.Throws<ArgumentException>(() => controller.RegisterUser(user));
        }
    }
}
