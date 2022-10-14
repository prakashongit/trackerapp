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

        public UsersController(IUserBusiness userBusiness, ILogger<UsersController> logger) {
            _userBusiness = userBusiness;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> PostAdminUser([FromBody] Registration user)
        {
            try
            {
                return Created(nameof(PostAdminUser), _userBusiness.CreateUser(user));
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

        [HttpPost("add-member")]
        public ActionResult<bool> PostMember([FromBody] Registration user)
        {
            try
            {
                return Created(nameof(PostMember), _userBusiness.CreateUser(user, false));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
