using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; } = String.Empty;


        //public List<int> SectionTasks { get; set; } = new List<int>();
    }
}
