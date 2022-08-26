using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;

namespace BLL.Services
{
    public class TokenService
    {
        public static List<TokenModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<TokenModel>>(DataAccessFactory.TokenDataAccess().Get());
            return data;
        }
        public static TokenModel Get(string token)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<TokenModel>(DataAccessFactory.TokenDataAccess().Get(token));
            return data;
        }
        public static void Create(TokenModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(a);
            DataAccessFactory.TokenDataAccess().Add(data);
        }
        public static void Edit(TokenModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(a);
            DataAccessFactory.TokenDataAccess().Edit(data);
        }
        public static void Delete(TokenModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var token = mapper.Map<string>(a);
            DataAccessFactory.TokenDataAccess().Delete(token);
        }
    }
}
