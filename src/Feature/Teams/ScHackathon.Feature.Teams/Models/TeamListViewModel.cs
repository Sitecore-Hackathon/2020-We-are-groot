using System.Collections.Generic;

namespace ScHackathon.Feature.Teams.Models
{
    public class TeamListViewModel
    {
        public string Title { get; set; }
        public List<TeamViewModel> TeamInfo { get; set; }
    }
}