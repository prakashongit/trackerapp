using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLibrary.Repository.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Passcode { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public int? ManagerId { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AllowcationPercentage { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("ManagerId")]
        public List<User> Users { get; set; }

        [ForeignKey("ProjectId")]
        public IList<Project> Project { get; set; }
    }
}
