using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class TestatorHomePageController : Controller
    {
        // GET: TestatorHomePage
        public ActionResult TestatorHomePageIndex()
        {




            return View("~/Views/TestatorHomePage/TestatorHomePageContent.cshtml");
        }
    }
}