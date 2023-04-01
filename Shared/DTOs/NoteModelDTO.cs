using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared.DTOs
{
    public class NoteModelDTO
    {

        [Key]
       public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public int? Order { get; set; }

        [ForeignKey("StoryId")]
        public int UserStory { get; set; }

        public string AcceptanceCriteria { get; set; } = string.Empty;


        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        [ForeignKey("TagId")]
        public int? Tag { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.None;

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;

      

        // [ForeignKey("StatusId")]
        // public Status? Status { get; set; }

        public bool? isSubTask { get; set; } = false;

        // public bool? recurringTask { get; set; } 

        public int? LinkTo { get; set; }
    }
}
