using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer.Repositories
{
    public class AccountDAL
    {
        static AllahEntities db;
        static AccountDAL()
        {
            db = new AllahEntities();
        }
        public static List<Account> Get()
        {
            return db.Accounts.ToList();
        }
        public static Account Get(int id) 
        {
            return db.Accounts.SingleOrDefault(a => a.Id == id);
        }
        public static void Delete(int id) 
        {
            var ds = db.Accounts.FirstOrDefault(a => a.Id == id);
            db.Accounts.Remove(ds);
        }
        public static void Add(Account a)
        {
            db.Accounts.Add(a);
            db.SaveChanges();
        }
    }
}

