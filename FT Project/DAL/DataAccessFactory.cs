using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static AllahEntities db;
        static DataAccessFactory()
        {
            db = new AllahEntities();
        }
        public static IRepository<Donar,int> DonarDataAccess()
        {
            return new DonarDAL(db);
        }
        public static IRepository<Receiver, int> ReceiverDataAccess()
        {
            return new ReceiverDAL(db);
        }
        public static IRepository<Account, int> AccountDataAccess()
        {
            return new AccountDAL (db);
        }
        public static IRepository<User, int> UserDataAccess()
        {
            return new UserDAL(db);
        }
        public static IRepository<Token, string> TokenDataAccess()
        {
            return new TokenDAL(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new UserDAL(db);
        }

        public static IAuth2 AuthDataAccess2()
        {
            return new AccountDAL(db);
        }


    }
}
