using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class PartyAttendee
    {
        [Key]
        public int PartyAttendeeId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int WatchPartyId { get; set; }
        
        public WatchParty WatchParty { get; set; }
    }
}
