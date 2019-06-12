using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class WatchParty
    {
        [Key]
        public int WatchPartyId { get; set; }


        [Required]
        [StringLength(55)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]

        public int Limit { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        [Required]
        [DisplayName("Team")]
        public int TeamId { get; set; }

        public ApplicationUser User { get; set; }

        public Team Team { get; set; }

        public virtual ICollection<PartyAttendee> PartyAttendees { get; set; }




    }
}
