using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class SubTask
    {
        [Key]
        public int SubTaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.MustHave;
        public DateTime DueDate { get; set; } = DateTime.Now;
      
        public Status status { get; set; } = Status.ToDo;

        public List<Note>? Notes { get; set; }

        [ForeignKey("TaskId")]
        public int AssignedToTask { get; set; }
    }
}
