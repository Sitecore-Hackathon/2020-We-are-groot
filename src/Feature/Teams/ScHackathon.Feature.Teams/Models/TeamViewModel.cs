using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScHackathon.Feature.Teams.Models
{
    public class TeamViewModel
    {
        public string TeamName { get; set; }
        public string Location { get; set; }
        public string FirstParticipantName { get; set; }
        public string SecondParticipantName { get; set; }
        public string ThirdParticipantName { get; set; }
        public string FirstParticipantLinkedInUrl { get; set; }
        public string SecondParticipantLinkedInUrl { get; set; }
        public string ThirdParticipantLinkedInUrl { get; set; }
        public string FirstParticipantTwitterUrl { get; set; }
        public string SecondParticipantTwitterUrl { get; set; }
        public string ThirdParticipantTwitterUrl { get; set; }
    }
}