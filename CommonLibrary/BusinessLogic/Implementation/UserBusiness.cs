using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Constants;
using CommonLibrary.Extensions;
using CommonLibrary.Repository.Interface;
using CommonLibrary.Repository.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.BusinessLogic.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JWTService _jWTService;
        private readonly ILogger<UserBusiness> _logger;

        public UserBusiness(IUnitOfWork unitOfWork, JWTService jWTService, ILogger<UserBusiness> logger) {
            _jWTService = jWTService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IEnumerable<UserDetails> GetMyUsers(int managerId)
        {
            var users = from u in _unitOfWork.Users.GetAll()
                        join project in _unitOfWork.Projects.GetAll() on u.ProjectId equals project.ProjectId
                        where managerId == u.ManagerId.GetValueOrDefault()
                        select new UserDetails {
                            Name = u.Name,
                            UserName = u.UserName,
                            StartDate = u.StartDate,
                            EndDate = u.EndDate,
                            AllowcationPercentage = u.AllowcationPercentage,
                            ProjectName = project.ProjectName,
                            Skills = u.Skills,
                            UserId = u.UserId
                        };
            return users;
        }

        public string GetToken(LoginDetails loginDetails) {
            try
            {
                string username = loginDetails.UserName;
                string password = loginDetails.Password;

                var user = _unitOfWork.Users.Find(u => u.UserName.ToUpper().Equals(username.ToUpper())).FirstOrDefault();
                string token = string.Empty;
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    string roleName = _unitOfWork.Roles.GetById(user.RoleId).RoleName;
                    token = _jWTService.GenerateSecurityToken(username, roleName, user.UserId);
                }
                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateUser(Registration userRegistration, bool isAdmin=true)
        {
            try
            {
                var existingUser = _unitOfWork.Users.Find(u => u.UserName.ToUpper().Equals(userRegistration.UserName.ToUpper())).FirstOrDefault();
                if (existingUser == null)
                {
                    User user = new User();

                    if (isAdmin)
                    {
                        user = new User
                        {
                            Password = BCrypt.Net.BCrypt.HashPassword(userRegistration.Password),
                            RoleId = userRegistration.RoleId,
                            UserName = userRegistration.UserName,
                            Name = userRegistration.Name
                        };
                    }
                    else {
                        user = new User
                        {
                            IsActive = false,
                            Passcode = BCrypt.Net.BCrypt.HashPassword(userRegistration.Passcode),
                            RoleId = userRegistration.RoleId,
                            UserName = userRegistration.UserName,
                            ProjectId = userRegistration.ProjectId,
                            StartDate = userRegistration.StartDate,
                            EndDate = userRegistration.EndDate,
                            Description = userRegistration.Description,
                            Skills = userRegistration.Skills,
                            AllowcationPercentage = userRegistration.AllowcationPercentage
                        };
                    }
                    
                    _unitOfWork.Users.Add(user);
                    return _unitOfWork.Complete() > 0;
                }
                else
                    new Exception("User already exists in the system");
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UserStatusWithUpdate(Registration userRegistration, bool isUpdate = true)
        {
            int status = (int)Status.Success;
            try
            {
                _logger.LogInformation($"Getting user using username");
                var user = _unitOfWork.Users.Find(u => u.UserName.ToUpper().Equals(userRegistration.UserName.ToUpper())).FirstOrDefault();

                if (user == null)
                {
                    _logger.LogInformation($"User didn't created by admin");
                    status = (int)Status.DoesnotExist;
                    return status;
                }
                else if (user.IsActive)
                {
                    _logger.LogInformation($"User already created");
                    status = (int)Status.AlreadyCreated;
                    return status;
                }
                else if (isUpdate) {
                    user.IsActive = true;
                    user.Name = userRegistration.Name;
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userRegistration.Password);
                    _unitOfWork.Users.Update(user);
                    _unitOfWork.Complete();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }
    }
}
