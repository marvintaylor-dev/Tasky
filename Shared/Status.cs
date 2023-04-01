using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Shared
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusDefinitionOfFinished { get; set; } = string.Empty;
        public int WorkInProgressLimit { get; set; } = 0;

        public DateTime? CreatedAt { get; set; }
    }
}
