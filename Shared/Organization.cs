using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class Organization
    {
        [Key]
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;

        public string OrganizationDescription { get; set; } = string.Empty;

        public string OrganizationEmail { get; set; } = string.Empty; 
        public int OwnerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set;} = DateTime.Now;

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
      // public List<Member> Members { get; set; }
    }
}
