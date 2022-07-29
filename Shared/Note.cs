using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int AuthorId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("TaskId")]
        public int AssignedToTask { get; set; }
       
    }
}
