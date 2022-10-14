using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Models
{
    public class TaskDetails
    {
        public string TaskName { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public int AllowcationPercentage { get; set; }
        public string Deliverables { get; set; }
    }
}
