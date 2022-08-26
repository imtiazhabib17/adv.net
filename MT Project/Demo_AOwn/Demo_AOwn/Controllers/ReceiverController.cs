
using Demo_AOwn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_AOwn.Controllers
{
    public class ReceiverController : Controller
    {
        AllahEntities hello = new AllahEntities();
        // GET: Receiver
        public ActionResult Receiver()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReceiver( Receiver Hell)
        {
            


            Receiver gg = new Receiver();
            gg.Name = Hell.Name;
            gg.Phone = Hell.Phone;
            gg.RAmount= Hell.RAmount;   
            gg.Comment = Hell.Comment;

            hello.Receivers.Add(gg);
            hello.SaveChanges();

            ModelState.Clear();

            return View("Receiver");
        }

        public ActionResult ReceiverList()
        {
            var res = hello.Receivers.ToList();
            int total = 0;

            List<Donar> aa = hello.Donars.ToList();
            foreach (Donar item in aa)
            {
                total = total + item.Amount;

            }


            ViewBag.Alpha24 = total;
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = hello.Receivers.Where(x => x.ID == id).First();
            hello.Receivers.Remove(res);
            hello.SaveChanges();

            var List = hello.Receivers.ToList();


            return View("ReceiverList", List);
        }

        public ActionResult Display()
        {
            int total = 0;
            int count = 0;
            List<Donar> aa = hello.Donars.ToList();
            TotalAmount a = hello.TotalAmounts.Find(1);
            foreach (Donar item in aa)
            {
                total=total+ item.Amount;
                count++;
            }
            ViewBag.Alpha24 = total;
            ViewBag.use = count;
            ViewBag.Alpha = a.TotalAmount1;


            int total1 = 0;
            int use1 = 0;
            List<Receiver> ab = hello.Receivers.ToList();
            foreach (Receiver item in ab)
            {
                total1 = total1 + item.RAmount;
                use1++;
            }
            int remain = a.TotalAmount1 - total1;
            if (remain > 0)
            {
                ViewBag.msg = remain + "Taka";
                ViewBag.msg4 = "We Have the Money to FullFill All Request";
            }
            else
            {
                ViewBag.msg = "Dew" + remain + "Taka";
                ViewBag.msg4 = "We Don't Have The Money to FullFill All Request";
            }
            ViewBag.user2 = use1;
            ViewBag.alpha2 = total1;
            return View(hello.Receivers.ToList());
        }

        public ActionResult Done(int id)
        {
            TotalAmount a = hello.TotalAmounts.Find(1);

            Receiver receiver = hello.Receivers.Find(id);
            a.TotalAmount1 -= receiver.RAmount;
            hello.Receivers.Remove(receiver);
            hello.SaveChanges();
            return RedirectToAction("Display");

        }
        public ActionResult Remove(int id)
        {
           
            Receiver receiver = hello.Receivers.Find(id);
            hello.Receivers.Remove(receiver);
            hello.SaveChanges();
            return RedirectToAction("Display");

        }
    }
}