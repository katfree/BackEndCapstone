using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BackEndCapstone.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        public override string UserName { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        public virtual ICollection<WatchParty> WatchParties { get; set; }

        public virtual ICollection<PartyAttendee> PartyAttendees { get; set; }

    }
}