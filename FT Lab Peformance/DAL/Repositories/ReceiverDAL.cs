using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer.Repositories
{
    public class ReceiverDAL
    {
        static AllahEntities db;
        static ReceiverDAL()
        {
            db = new AllahEntities();
        }
        public static List<Receiver> Get()
        {
            return db.Receivers.ToList();
        }
        public static Receiver Get(int id)
        {
            return db.Receivers.SingleOrDefault(a => a.ID == id);
        }
        public static void Delete(int id)
        {
            var ds = db.Receivers.FirstOrDefault(a => a.ID == id);
            db.Receivers.Remove(ds);
        }
        public static void Add(Receiver a)
        {
            db.Receivers.Add(a);
            db.SaveChanges();
        }
    }
}