using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTestRebtel.Controllers
{
    public class QunitTestRunnerController : Controller
    {
        //
        // GET: /QunitTestRunner/

        public ActionResult Index()
        {
            ViewBag.PageTitle = "QUnit Test Runner";
            return View();
        }

    }
}
