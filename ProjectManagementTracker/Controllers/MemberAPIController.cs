using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAPIController : ControllerBase
    {
        public MemberAPIController() { 
        }

        [HttpGet]
        public ActionResult<List<Member>> GetMembers() {
            var members = new List<Member> { new Member { Name = "John" }, new Member { Name = "Iyer"} };
            return Ok(members);
        }
    }

    public class Member {
        public string Name { get; set; }
    }
}
