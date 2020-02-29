using ScHackathon.Feature.Teams.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScHackathon.Feature.Teams.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Teams()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSourceItem = Sitecore.Context.Database.GetItem(dataSourceId);
            TeamListViewModel teamListViewModel = null;
            if (dataSourceItem != null)
            {
                List<Item> participantList = dataSourceItem.GetChildren().ToList();
                teamListViewModel = new TeamListViewModel
                {
                    Title = dataSourceItem.Fields["Title"] != null ? dataSourceItem.Fields["Title"].Value : string.Empty,
                    TeamInfo = participantList.Select(x => new TeamViewModel
                    {
                        TeamName = x.Fields["Team Name"] != null ? x.Fields["Team Name"].Value : string.Empty,
                        Location = x.Fields["Location"] != null ? x.Fields["Location"].Value : string.Empty,
                        FirstParticipantName = x.Fields["First Participant Name"] != null ? x.Fields["First Participant Name"].Value : string.Empty,
                        FirstParticipantLinkedInUrl = x.Fields["First Participant LinkedIn Url"] != null ? x.Fields["First Participant LinkedIn Url"].Value : string.Empty,
                        FirstParticipantTwitterUrl = x.Fields["First Participant Twitter Url"] != null ? x.Fields["First Participant Twitter Url"].Value : string.Empty,
                        SecondParticipantName = x.Fields["Second Participant Name"] != null ? x.Fields["Second Participant Name"].Value : string.Empty,
                        SecondParticipantLinkedInUrl = x.Fields["Second Participant LinkedIn Url"] != null ? x.Fields["Second Participant LinkedIn Url"].Value : string.Empty,
                        SecondParticipantTwitterUrl = x.Fields["Second Participant Twitter Url"] != null ? x.Fields["Second Participant Twitter Url"].Value : string.Empty,
                        ThirdParticipantName = x.Fields["Third Participant Name"] != null ? x.Fields["Third Participant Name"].Value : string.Empty,
                        ThirdParticipantLinkedInUrl = x.Fields["Third Participant LinkedIn Url"] != null ? x.Fields["Third Participant LinkedIn Url"].Value : string.Empty,
                        ThirdParticipantTwitterUrl = x.Fields["Third Participant Twitter Url"] != null ? x.Fields["Third Participant Twitter Url"].Value : string.Empty,
                    }).ToList(),
                };
            }
            return View("~/Views/Teams.cshtml", teamListViewModel);
        }
    }
}