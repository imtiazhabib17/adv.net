using Create.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Create.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
     
        public ActionResult StudentInfo(Student s)
        {
            /*Student s = new Student();
            s.Name = Request["Name"];
            s.NID = Request["NID"];
            s.BG = Request["BG"];*/

            return View(s);
        }
    }
}