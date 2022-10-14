using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Models
{
    public class Registration
    {
        public virtual string Name { get; set; }
        public virtual string UserName { get; set; }
        public virtual int RoleId { get; set; }
        public virtual string Passcode { get; set; }
        public virtual string Password { get; set; }
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
