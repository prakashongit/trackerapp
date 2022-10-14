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
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectBusiness _projectBusiness;

        public ProjectController(IProjectBusiness projectBusiness, ILogger<ProjectController> logger)
        {
            _projectBusiness = projectBusiness;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> PostProject([FromBody] ProjectDetails projectDetails) {

            try
            {
                return Created(nameof(PostProject), _projectBusiness.AddProject(projectDetails));
            }
            catch (Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult<bool> GetProjects()
        {
            try
            {
                return Ok(_projectBusiness.GetProjects());
            }
            catch (Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }



        [HttpPost("update")]
        public ActionResult<bool> UpdateAllocationPercentage([FromBody] UpdatePercentage details)
        {
            try
            {
                return Created(nameof(PostProject), _projectBusiness.UpdateAllowcationPercentage(details));
            }
            catch (Exception ex)
            {
                _logger.LogErrorDetails(ex);
                throw ex;
            }
        }
    }
}
