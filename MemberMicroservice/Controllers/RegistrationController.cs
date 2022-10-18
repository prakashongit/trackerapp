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
        public ActionResult<StatusInfo> CheckStatus([FromBody] Registration user)
        {
            try
            {
                StatusInfo status = new StatusInfo();
                status.Code = _userBusiness.MemeberStatusWithUpdate(user, false);
                return Ok(status);
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }

        [HttpPost("update")]
        public ActionResult<StatusInfo> UpdateMemberDetails([FromBody] Registration user)
        {
            try
            {
                StatusInfo status = new StatusInfo();
                status.Code = _userBusiness.MemeberStatusWithUpdate(user);
                return Created(nameof(UpdateMemberDetails), status);
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
