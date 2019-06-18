using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models.WatchPartyViewModels
{
    public class IndexViewModel

    {
        public IEnumerable<WatchParty> WatchParties { get; set; }

        public Team Teams { get; set; }

        public string SelectedTeam  { get; set; }



}
}
