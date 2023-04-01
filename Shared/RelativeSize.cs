using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Shared
{
    public class RelativeSize
    {
        [Key]
        public int SizeId { get; set; }

        public string SizeName { get; set; } = string.Empty;

        //size group - my thought process, I'll be able to do T-shirt sizing, fib numbers, and allow for customizing and new groups to be created if I just have another table column.
        //Ex: Fib numbers would be in group 1. 
        //   T-shirt sizes in group two. etc.
        // The size group should not be null if a new one is created. When a new size is created the user should be prompted to also select a group to place it in or create a new group.
        [Required]
        public int? SizeGroup { get; set; }

    }
}
