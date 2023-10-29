using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class ProductGoal
    {
        [Key]
        public int ProductGoalId { get; set; }

        public int OrganizationId { get; set; }
        public int ProductBacklogId { get; set; }
        public string ProductGoalName { get; set; } = string.Empty;
      //public List<string>? ProductGoals { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;


    }
}
