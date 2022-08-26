using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL : IRepository<Account, int>,IAuth2
    {
        AllahEntities db;
        public AccountDAL(AllahEntities db)
        {
            this.db = db;
        }
        public void Add(Account e)
        {
            db.Accounts.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Accounts.FirstOrDefault(en => en.Id == id);
            db.Accounts.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Account e)
        {
            var d = db.Accounts.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Account> Get()
        {
            return db.Accounts.ToList();
        }

        public Account Get(int id)
        {
            return db.Accounts.FirstOrDefault(e => e.Id == id);
        }

        public Token Authenticate(Account user)
        {
            var u = db.Accounts.FirstOrDefault(en => en.UserName.Equals(user.UserName) && en.Password.Equals(user.Password));
            Token t = null;
            if (u != null)
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId = u.Id;
                t.AccessToken = token;
                t.CreatedDate = DateTime.Now;
                db.SaveChanges();
            }
            return t;
        }

        public bool IsAuthenticated(string token)
        {
            var rs = db.Tokens.Any(e => e.AccessToken.Equals(token) && e.ExpiredAt != null);
            return rs;
        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if (t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

       
    }
}

