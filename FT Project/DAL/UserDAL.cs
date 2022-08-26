using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IRepository<User, int>,IAuth
    {
        AllahEntities db;
        public UserDAL(AllahEntities db)
        {
            this.db = db;
        }
        public void Add(User e)
        {
            db.Users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.Id == id);
            db.Users.Remove(e);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var d = db.Users.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(d).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.Id == id);
        }

        public Token Authenticate(User user)
        {
            var u = db.Users.FirstOrDefault(en=>en.UserName.Equals(user.UserName) && en.Password.Equals(user.Password));
            Token t = null;
            if(u != null)
            {
                string token= Guid.NewGuid().ToString();
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
            if(t!= null)
            {
                t.ExpiredAt=DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;   
        }
    }
}
