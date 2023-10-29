using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int OrganizationId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        [Column(TypeName = "decimal(13,4)")]
        public decimal ProjectBudget { get; set; } = decimal.Zero;
        public int? CurrentProductGoal { get; set; }
        public List<ProductGoal>? ProductGoalHistory { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }
}
