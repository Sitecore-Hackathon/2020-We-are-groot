using ScHackathon.Feature.Header.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ScHackathon.Feature.Header.Controllers
{
    public class HeaderDetailsController : Controller
    {
        // GET: HeaderDetails
        public HeaderDetailsController()
        {

        }
        public ActionResult Header()
        {
            NavigationItems navigationItems = null;
            Item homePageItem = Sitecore.Context.Database.GetItem(new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"));
            if (homePageItem != null)
            {
                List<Item> childItem = homePageItem.GetChildren().ToList();
                if (childItem != null && childItem.Any())
                {
                    List<Item> hackathonItems = childItem.Where(x => x.TemplateID.ToString() == "{0EF7A108-B361-48D6-950C-3F9758275209}" && x.Fields["Show on Navigation"].Value == "1").ToList();
                    if (hackathonItems != null && hackathonItems.Any())
                    {
                        navigationItems = new NavigationItems
                        {
                            HackathonItems = hackathonItems.Select(x => new HackathonItem
                            {
                                Title = x.Fields["Navigation Title"].Value,
                                Url = LinkManager.GetItemUrl(x)
                            }).ToList()
                        };
                    }
                }
            }
            return View("~/Views/HeaderDetails/Header.cshtml", navigationItems);
        }
    }
}