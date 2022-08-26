using Demo_AOwn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_AOwn.Controllers
{
    public class DonarController : Controller
    {
        // GET: Donar
        AllahEntities ab = new AllahEntities();
        public ActionResult Donar(Donar obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddDonar(Donar model)
        {
            Donar obj = new Donar();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;  
                obj.Name = model.Name;
                obj.Phone = model.Phone;
                obj.Email = model.Email;
                obj.Amount = model.Amount;
                obj.Address = model.Address;
                obj.Comment = model.Comment;

                if(model.ID == 0)
                {
                    TotalAmount a = ab.TotalAmounts.Find(1);
                    a.TotalAmount1 += model.Amount;
                    ab.Donars.Add(obj);
                    ab.SaveChanges();
                }
                else
                {
                    TotalAmount a = ab.TotalAmounts.Find(1);
                    a.TotalAmount1 += model.Amount;
                    ab.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    ab.SaveChanges();
                }
                
            }
            ModelState.Clear();
           
            return View("Donar");
        }

        public ActionResult DonarList()
        {
            var res = ab.Donars.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = ab.Donars.Where(x => x.ID == id).First();
            ab.Donars.Remove(res);
            ab.SaveChanges();

            var List = ab.Donars.ToList();


            return View("DonarList", List);
        }
    }
}