using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class EstimationGroup
    {
        [Key]
        public int EstimationGroupId { get; set; }
        public int OrganizationId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set;} = DateTime.Now;
    }
}
