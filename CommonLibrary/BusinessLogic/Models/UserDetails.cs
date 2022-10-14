using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Models
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AllowcationPercentage { get; set; }
        public string ProjectName { get; set; }
        public string Skills { get; set; }
        public int UserId { get; set; }
    }
}
