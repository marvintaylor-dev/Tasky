using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
        //throws an error that a keyless type or primary key is required
        //public List<DateTime>? VacationDates { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int WorkAssigned { get; set; } = 0;
        public string TimeZone { get; set; } = string.Empty;
        //public List<TimeSpan> ActiveTimes { get; set; }
        public int TeamId { get; set; } = 0;

        public bool IsEditing { get; set; }
    }
}
