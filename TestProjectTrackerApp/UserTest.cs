using AdminMicroservice.Controllers;
using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestProjectTrackerApp
{
    public class UserTest
    {
        public Mock<IUserBusiness> mock = new Mock<IUserBusiness>();
        public Mock<IProjectBusiness> mockR = new Mock<IProjectBusiness>();
        public Mock<ILogger<UsersController>> mocLogger = new Mock<ILogger<UsersController>>();

        [Fact]
        public void GetUserbyId()
        {
            mock.Setup(p => p.GetMyUsers(1)).Returns(new List<UserDetails> { new UserDetails { UserName = "Test" } });
            UsersController user = new UsersController(mock.Object, mocLogger.Object, mockR.Object);
            var result = user.GetUser(1);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(200,okResult?.StatusCode);
        }

        [Fact]
        public void CreateUser()
        {
            Registration registration = new Registration();
            mock.Setup(p => p.CreateUser(registration)).Returns(true);
            UsersController user = new UsersController(mock.Object, mocLogger.Object, mockR.Object);
            var result = user.PostUser(registration);

            var okResult = result.Result as CreatedResult;
            Assert.Equal(201, okResult?.StatusCode);
            Assert.True((bool)okResult?.Value);
        }
    }
}
