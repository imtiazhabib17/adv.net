using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer.Repositories
{
    public class DonarDAL
    {
        static AllahEntities db;
        static DonarDAL()
        {
            db = new AllahEntities();
        }
        public static List<Donar> Get()
        {
            return db.Donars.ToList();
        }
        public static Donar Get(int id)
        {
            return db.Donars.SingleOrDefault(a => a.ID == id);
        }
        public static void Delete(int id)
        {
            var ds = db.Donars.FirstOrDefault(a => a.ID == id);
            db.Donars.Remove(ds);
        }
        public static void Add(Donar a)
        {
            db.Donars.Add(a);
            db.SaveChanges();
        }
    }
}