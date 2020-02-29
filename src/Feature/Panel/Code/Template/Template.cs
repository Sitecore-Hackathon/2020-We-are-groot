using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Training.Feature.Panel.Template
{
    public class Template
    {
        public struct PanelItem
        {
            public static readonly ID ID = new ID("{8C4335B6-48FB-4B8A-B68F-961A20182A44}");
            public struct Fields
            {
                public static readonly ID Name = new ID("{7F5734BE-D34F-4093-949D-21E973DF736F}");
                public static readonly ID Image = new ID("{2A7E601E-F7AE-45EE-8B4C-D4851695D98B}");
                public static readonly ID TwitterLink = new ID("{78FA706D-E574-48D8-BDDB-666AFB3CCF7D}");
                public static readonly ID LinkedinLink = new ID("{1D7224D7-D792-4390-9245-995983D3B6DD}");  
            }
        }
        
        public struct PanelItems
        {
            public static readonly ID ID = new ID("{B82EEF6E-5CB9-4BEC-AEB3-D2364E88D8E9}");
            public struct Fields
            {
                public static readonly ID Panel = new ID("{5C0D27B6-4332-4496-A8B0-8BDD9C6651F3}");
            }
        }
    }
}