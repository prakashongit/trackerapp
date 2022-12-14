using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IUserBusiness _userBusiness;

        public TokenController(ILogger<TokenController> logger, IUserBusiness userBusiness) {
            _logger = logger;
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public ActionResult<Token> GetToken([FromBody] LoginDetails loginDetails) {
            try
            {
                _logger.LogInformation("Requested for token");
                var jwtToken = _userBusiness.GetToken(loginDetails);
                var token = new Token { JWTToken = jwtToken };
                return Ok(token);
            }
            catch (System.Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw new System.Exception("Please contact Administrator");
            }
        }

        //[HttpGet]
        //public ActionResult GetUsers() {
        //    return Ok(_userBusiness.GetUsers());
        //}
    }
}
