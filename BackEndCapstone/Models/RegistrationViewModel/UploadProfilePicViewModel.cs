using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models.RegistrationViewModel
{
    public class UploadProfilePicViewModel
    {
        public ApplicationUser User { get; set; }

        public IFormFile ImageFile { get; set; }

        public IEnumerable<ApplicationUser> IUsers { get; set; }

        public IEnumerable<WatchParty> watchParty { get; set; }
    }
}
