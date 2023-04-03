using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Shared
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Status name should be less than 20 characters.")]
        public string StatusName { get; set; } = string.Empty;
        public string StatusDefinitionOfFinished { get; set; } = string.Empty;
        public int WorkInProgressLimit { get; set; } = 0;

        public int StatusOrder { get; set; } = 1;

        public DateTime? CreatedAt { get; set; }
    }
}
