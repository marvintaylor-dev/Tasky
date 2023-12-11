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
    public class Epic
    {
        [Key]
        public int EpicId { get; set; }
        public string EpicName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8, 2)")]

        public decimal EpicBudget { get; set; } = decimal.Zero;

        public TagColor? EpicColor { get; set; } = TagColor.Warning;

        public string EpicCategory { get; set; } = string.Empty;

        //navigation property
        public virtual IList<NoteModel>? UserStoriesInEpic { get; set; }

        [ForeignKey(nameof(ProjectId))]

        public int ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }

    }
}
