using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
     
    public class Task : BaseEntity
    {
        [ForeignKey("Moc")]
        public int MocId { get; set; }
        [ForeignKey("RelatedUser")]
        public string RelatedUserId { get; set; }
        [Required]
        public DateTime Duedate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Comment { get; set; }
        [Required]
        [MaxLength(255)]
        public string Definition { get; set; }

        public IdentityUser RelatedUser { get; set; }

        public Moc Moc { get; set; }
    }
}
