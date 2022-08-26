using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonarDAL : IRepository<Donar, int>
    {
        AllahEntities db;
        public DonarDAL(AllahEntities db)
        {
            this.db = db;
        }
        public void Add(Donar e)
        {
            db.Donars.Add(e);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var e = db.Donars.FirstOrDefault(en => en.ID == id);
            db.Donars.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Donar e)
        {
            var d = db.Donars.FirstOrDefault(en => en.ID == e.ID);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Donar> Get()
        {
            return db.Donars.ToList();
        }

        public Donar Get(int id)
        {
            return db.Donars.FirstOrDefault(e => e.ID == id);
        }
    }
}
