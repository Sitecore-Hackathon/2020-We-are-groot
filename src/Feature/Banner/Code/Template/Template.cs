using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Training.Feature.Banner.Template
{
    public class Template
    {
        public struct Carousel
        {
            public static readonly ID ID = new ID("{0AA841C3-52B1-463A-B959-C1826ADEEC0C}");
            public struct Fields
            {
                public static readonly ID Image = new ID("{C70A8E74-54A0-4BA6-9969-96B4CE6C3D9B}");
                public static readonly ID Header = new ID("{B11B535B-9E57-431B-BDC6-3103CB7F6525}");
                public static readonly ID Teaser = new ID("{9672C488-08CB-4F91-B9AB-DD5BF02F4D24}");
                public static readonly ID Link = new ID("{9B715570-6C7C-427E-BB94-F0C672D47F09}");  
                public static readonly ID LinkText = new ID("{73E948CB-5E6F-4446-A14D-4C73A2B10E78}");

            }
        }
        
        public struct CarouselItems
        {
            public static readonly ID ID = new ID("{03C02512-4BFB-486B-A7F3-530D1622E810}");
            public struct Fields
            {
                public static readonly ID Carousel = new ID("{27E96531-18FF-4391-A23D-6D13B0576645}");
            }
        }
    }
}