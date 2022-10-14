using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.BusinessLogic.Models
{
    public class SaveTask
    {
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Deliverables { get; set; }
        public int UserId { get; set; }
    }
}
