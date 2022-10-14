using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLibrary.Repository.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Deliverables { get; set; }
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
