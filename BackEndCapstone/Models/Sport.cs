using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
