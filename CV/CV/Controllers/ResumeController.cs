using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Resume()
        {
            return View();
        }
    }
}