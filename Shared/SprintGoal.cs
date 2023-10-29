using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class SprintGoal
    {
        [Key]
        public int SprintGoalId { get; set; }

        public int OrganizationId { get; set; }
        public int ProductBacklogId { get; set; }
        public string SprintGoals { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
