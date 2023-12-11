using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class UserStory
    {
        [Key]
        public int UserStoryId { get; set; }

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }

        public string As { get; set; } = string.Empty;
        public string Want { get; set; } = string.Empty;
        public string So { get; set; } = string.Empty;

        [ForeignKey(nameof(ProjectId))]

        public int ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }
    }
}
