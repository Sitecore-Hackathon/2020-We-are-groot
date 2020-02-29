using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Training.Feature.Panel.Models;
using Sitecore.Training.Feature.Panel.Template;

namespace ScHackathon.Feature.Panel.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        public PanelController()
        {

        }
        public ActionResult GetPanels()
        {
            var Items = Get(RenderingContext.Current.Rendering.Item);
            return View(Items);

            
        }
        public IEnumerable<PanelItem> Get(Item contextitem)
        {
            List<PanelItem> carouselList = new List<PanelItem>();
            if (contextitem == null)
            {
                throw new ArgumentNullException(nameof(contextitem));
            }
            MultilistField multiListField = contextitem.Fields[Template.PanelItems.Fields.Panel];
            if (multiListField != null)
            {
                foreach (Item panelItem in multiListField.GetItems())
                {
                    PanelItem eachCarouselItem = new PanelItem();
                    eachCarouselItem.PanelItems = panelItem;
                    string imageUrl = string.Empty;
                    ImageField imgField = ((ImageField)panelItem.Fields[Template.PanelItem.Fields.Image]);
                    if (imgField?.MediaItem != null)
                    {
                        var image = new MediaItem(imgField.MediaItem);
                        imageUrl = StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                    }
                    eachCarouselItem.ImageUrl = imageUrl;
                    eachCarouselItem.LinkedinUrl = LinkUrl((LinkField)panelItem.Fields[Template.PanelItem.Fields.LinkedinLink]);
                    eachCarouselItem.TwitterUrl = LinkUrl((LinkField)panelItem.Fields[Template.PanelItem.Fields.TwitterLink]);
                    carouselList.Add(eachCarouselItem);
                }
            }
            return carouselList.ToList();
        }

        public String LinkUrl(Sitecore.Data.Fields.LinkField lf)
        {
            switch (lf.LinkType.ToLower())
            {
                case "internal":
                    // Use LinkMananger for internal links, if link is not empty
                    return lf.TargetItem != null ? Sitecore.Links.LinkManager.GetItemUrl(lf.TargetItem) : string.Empty;
                case "media":
                    // Use MediaManager for media links, if link is not empty
                    return lf.TargetItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem) : string.Empty;
                case "external":
                    // Just return external links
                    return lf.Url;
                case "anchor":
                    // Prefix anchor link with # if link if not empty
                    return !string.IsNullOrEmpty(lf.Anchor) ? "#" + lf.Anchor : string.Empty;
                case "mailto":
                    // Just return mailto link
                    return lf.Url;
                case "javascript":
                    // Just return javascript
                    return lf.Url;
                default:
                    // Just please the compiler, this
                    // condition will never be met
                    return lf.Url;
            }
        }


    }
}