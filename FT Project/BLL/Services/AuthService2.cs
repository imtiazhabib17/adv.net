using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService2
    {
        public static TokenModel Authenticate(AccountModel ac)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountModel>();
                c.CreateMap<AccountModel, Account>();
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Account>(ac);
            var result= DataAccessFactory.AuthDataAccess2().Authenticate(data);
            var token = mapper.Map<TokenModel>(result);
            return token;
        }
        public static bool IsAuthenticated(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess2().IsAuthenticated(token);
            return rs;
        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess2().Logout(token);
        }
    }
}
