using System;
using System.Collections.Generic;
using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberMicroservice.Controllers
{
    [Route("member/[controller]")]
    [Authorize(Roles = "Member")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskBusiness _taskBusiness;

        public TaskController(ITaskBusiness taskBusiness, ILogger<TaskController> logger)
        {
            _taskBusiness = taskBusiness;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IList<TaskDetails>> GetTasks([FromQuery]int userid) {
            try
            {
                return Ok(_taskBusiness.GetTasks(userid));
            }
            catch (Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
