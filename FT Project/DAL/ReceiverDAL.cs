using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReceiverDAL : IRepository<Receiver, int>
    {
        AllahEntities db;
        public ReceiverDAL(AllahEntities db)
        {
            this.db = db;
        }
        public void Add(Receiver e)
        {
            db.Receivers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
           var e = db.Receivers.FirstOrDefault(en=> en.ID == id);
            db.Receivers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Receiver e)
        {
            var d = db.Receivers.FirstOrDefault(en => en.ID == e.ID);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Receiver> Get()
        {
            return db.Receivers.ToList();
        }

        public Receiver Get(int id)
        {
            return db.Receivers.FirstOrDefault(e => e.ID == id);

        }
    }
}
