using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Training.Feature.Banner.Model;
using Sitecore.Training.Feature.Banner.Template;

namespace Sitecore.Training.Feature.Banner.Controllers
{
    public class BannerController : Controller
    {
        public BannerController()
        {

        }
        // GET: Banner
        public ActionResult Carousel()
        {
            var Items = Get(RenderingContext.Current.Rendering.Item);
            return View(Items);
        }
        public ActionResult Pinterest()
        {
            
            return View();
        }
        public IEnumerable<Carousel> Get(Item contextitem)
        {
            List<Carousel> carouselList = new List<Carousel>();
            if (contextitem == null)
            {
                throw new ArgumentNullException(nameof(contextitem));
            }
            MultilistField multiListField = contextitem.Fields[Template.Template.CarouselItems.Fields.Carousel];
            if (multiListField != null)
            {
                foreach (Item carouselItem in multiListField.GetItems())
                {
                    Carousel eachCarouselItem = new Carousel();
                    eachCarouselItem.CarouselItems = carouselItem;
                    string imageUrl = string.Empty;
                    ImageField imgField = ((ImageField)carouselItem.Fields[Template.Template.Carousel.Fields.Image]);
                    if (imgField?.MediaItem != null)
                    {
                        var image = new MediaItem(imgField.MediaItem);
                        imageUrl = StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                    }
                    eachCarouselItem.ImageUrl = imageUrl;
                    carouselList.Add(eachCarouselItem);
                }
            }
            return carouselList.ToList();
        }


        public ActionResult AboutUs()
        {
            return View();
        }
    }
}