using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOCProject.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
