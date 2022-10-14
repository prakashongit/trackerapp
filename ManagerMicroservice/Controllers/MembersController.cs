using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerMicroservice.Controllers
{
    /// <summary>
    /// Add, get and update details of members in a team
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = "manager")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        public MembersController() {
        }

        [HttpGet]
        public ActionResult<IList<Member>> GetMembers() {
            return new List<Member> { new Member { Name = "john" }, new Member { Name = "peter" } };
        }
    }
}
