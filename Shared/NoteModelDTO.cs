using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class NoteModelDTO
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        [ForeignKey("TagId")]
        public int? Tag { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.MustHave;
        public DateTime DueDate { get; set; } = DateTime.Now;

        public List<Note>? Notes { get; set; }

        public Status status { get; set; } = Status.ToDo;

        public bool? isSubTask { get; set; } = false;

        public int? LinkTo { get; set; }

        public List<int> Subtasks { get; set; }

        public NoteModelDTO(NoteModel x)
        {
            TaskId = x.TaskId;
            Name = x.Name;
            Assignee = x.Assignee;
            Tag = x.Tag;
            PriorityLevel = x.PriorityLevel;
            DueDate = x.DueDate;
            Notes = x.Notes;
            status = x.status;
            isSubTask = x.isSubTask;
            LinkTo = x.LinkTo;
            
        }
    }
}
