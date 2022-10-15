using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.BusinessLogic.Interface;
using CommonLibrary.BusinessLogic.Models;
using CommonLibrary.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminMicroservice.Controllers
{
    [Route("admin/[controller]")]
    [Authorize(Roles = "Admin")]
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

        [HttpPost]
        public ActionResult<bool> PostTask([FromBody] SaveTask details)
        {

            try
            {
                return Created(nameof(PostTask), _taskBusiness.AddTask(details));
            }
            catch (Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
