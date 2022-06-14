using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class NoteModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.Low;
        public DateTime DueDate {get; set;} = DateTime.Now;
        public string? Note { get; set; } = string.Empty;

        public Status status { get; set; } = Status.ToDo;

        
    }

}
