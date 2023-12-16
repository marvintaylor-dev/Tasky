using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class SprintModel
    {
        [Key] 
        public int SprintId { get; set; }

        //[ForeignKey("OrganizationId")]
        //public int OrganizationId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now + TimeSpan.FromDays(7);
        public int? SprintNumber { get; set; }
        [Column(TypeName = "decimal(8, 2)")]

        public decimal SprintBudget { get; set; }
        public int? PreviousVelocity { get; set; }
        public int? CurrentMinCapacity { get; set; }
        public int? CurrentMaxCapacity { get; set; }
        //for when you have multiple teams and are assigning to their sprint.
        public int? TeamId { get; set; }
        public string Holidays { get; set; } = string.Empty;
        public List<Member> MembersWithPlannedLeave { get; set; } = new();


        public List<NoteModel> AssignedTasks { get; set; } = new();
        public List<TasksSprints>? TasksSprints { get; set; }

        public string PlannedTraining { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal PercentOfTimeOnFeatures { get; set; } = decimal.Zero;
        [Column(TypeName = "decimal(8, 2)")]

        public decimal PercentOfTimeOnDebt { get;set; } = decimal.Zero;
        [Column(TypeName = "decimal(8, 2)")]

        public decimal PercentOfTimeOnOther { get;set; } = decimal.Zero;
        [Column(TypeName = "decimal(8, 2)")]

        public decimal PercentOfTimeBuffer { get;set; } = decimal.Zero;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(ProjectId))]

        public int ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }


        //private readonly List<Member> _members = new();

        //public SprintModel(List<Member> members) {
        //    _members = members;
        //    MembersWithPlannedLeave = _members.ToList();
        //}
    }
}
