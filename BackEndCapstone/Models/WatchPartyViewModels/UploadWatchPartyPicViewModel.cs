using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models.WatchPartyViewModels
{
    public class UploadWatchPartyPicViewModel
    {
        public WatchParty watchParty { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
