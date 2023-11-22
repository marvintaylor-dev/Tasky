using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class OrganizationModel
    {
        [Key]
        public int OrganizationId { get; set; }
        //[Required]
        public int? OwnerId { get; set; }
        //public List<Member> OrganizationMembers { get; set; } = new();

        //public List<User> OrganizationUsers { get; set; } = new();
        public string OrganizationName { get; set; } = string.Empty;
        public string OrganizationDescription { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }
}
