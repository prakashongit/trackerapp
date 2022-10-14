using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IUserBusiness _userBusiness;

        public RegistrationController(IUserBusiness userBusiness, ILogger<RegistrationController> logger)
        {
            _userBusiness = userBusiness;
            _logger = logger;
        }

        [HttpPost("status")]
        public ActionResult<int> CheckStatus([FromBody] Registration user)
        {
            try
            {
                return Ok(_userBusiness.MemeberStatusWithUpdate(user,false));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }

        [HttpPost("update")]
        public ActionResult<int> UpdateMemberDetails([FromBody] Registration user)
        {
            try
            {
                return Created(nameof(UpdateMemberDetails), _userBusiness.MemeberStatusWithUpdate(user));
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
