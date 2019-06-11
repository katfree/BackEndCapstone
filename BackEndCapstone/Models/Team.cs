using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SportId { get; set; }

        public Sport Sport { get; set; }

        public virtual ICollection<WatchParty> WatchParties { get; set; }


    }
}
