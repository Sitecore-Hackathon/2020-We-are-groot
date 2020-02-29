using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ScHackathon.Feature.Footer.Controller
{
    using System.Web.Mvc;
    public class FooterDetailsController : Controller
    {
        // GET: FooterTest
        public FooterDetailsController()
        {

        }
        public ActionResult Footer()
        {
            return View();
        }
    }
}