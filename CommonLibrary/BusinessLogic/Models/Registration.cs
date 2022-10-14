using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Models
{
    public class Registration
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Passcode { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AllowcationPercentage { get; set; }
        public int ProjectId { get; set; }
        public int ManagerId { get; set; }
        public int YearsOfExperience { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
    }
}
