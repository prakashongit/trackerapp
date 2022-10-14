using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController() { }

        [HttpGet]
        public ActionResult<IList<TaskDetails>> GetTasks() {
            return new List<TaskDetails> { new TaskDetails() { Name = "Task1" }, new TaskDetails() { Name = "Task2" } };
        }
    }
}
