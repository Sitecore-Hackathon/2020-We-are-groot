using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;


namespace Sitecore.Training.Feature.Panel.Models
{
    public class PanelItem
    {
        public Item PanelItems { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedinUrl { get; set; }

        
    }
}