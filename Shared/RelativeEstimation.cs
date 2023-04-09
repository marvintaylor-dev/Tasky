using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class RelativeEstimation
    {
        [Key]
        public int EstimationId { get; set; }
        public int OrganizationId { get; set; } 
        public string Value { get; set; } = string.Empty;
        //Estimation group is for creating different sets of estimation for different scenarios. Ex: T-shirt sizing, Fib numbers
        [ForeignKey("EstimationGroupId")]
        public int EstimationGroup { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set;} = DateTime.Now;
    }
}
