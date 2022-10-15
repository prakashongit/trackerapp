using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AdminMicroservice.Controllers
{

    [Route("admin/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserBusiness _userBusiness;
        private readonly IProjectBusiness _projectBusiness;

        public UsersController(IUserBusiness userBusiness, ILogger<UsersController> logger, IProjectBusiness projectBusiness) {
            _userBusiness = userBusiness;
            _logger = logger;
            _projectBusiness = projectBusiness;
        }

        [HttpPost]
        public ActionResult<bool> PostUser([FromBody] Registration user)
        {
            try
            {
                return Created(nameof(PostUser), _userBusiness.CreateUser(user));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult<IList<UserDetails>> GetUser([FromQuery] int userid)
        {
            try
            {
                return Ok(_userBusiness.GetMyUsers(userid));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult<bool> UpdateAllocationPercentage([FromQuery] UpdatePercentage details)
        {
            try
            {
                return Created(nameof(UpdateAllocationPercentage), _projectBusiness.UpdateAllowcationPercentage(details));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
