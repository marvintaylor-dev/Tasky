using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class NoteModel
    {
        //create these properties for the model
        //string SupportingDocuments - may require a many-to-many relationship so that multiple documents can be linked to multiple tasks and tasks can be assigned more than one document.
        //ID for product backlog - will allow users to have multiple products within their account
        //ID for organization - will separate one organization's account from others.
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public int? Order { get; set; }

        [ForeignKey("StoryId")]
        public int? UserStory { get; set; }

        public string AcceptanceCriteria { get; set; } = string.Empty;


        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        [ForeignKey("EpicId")]
        public int? EpicId { get; set; } 

        //Navigation Property
        public Epic Epic { get; set; } = new();

        [ForeignKey("TagId")]
        public int? Tag { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.None;

        [ForeignKey("EstimationId")]
        public int? SizeEstimate { get; set; }

        public int VisualHeightOfTask { get; set; } = 0;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;


        [ForeignKey("StatusId")]
        public int? Status { get; set; }

        [JsonIgnore]
        public List<SprintModel>? AssignedToSprint { get; set; }
        public List<TasksSprints>? TasksSprints { get; set; }

        public bool? isSubTask { get; set; } = false;

        // public bool? recurringTask { get; set; } 

        public int? LinkTo { get; set; }

    }

}
