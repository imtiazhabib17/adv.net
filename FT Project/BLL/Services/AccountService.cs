using AutoMapper;
using DAL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class AccountService
    {
        public static List<AccountModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<AccountModel>>(DataAccessFactory.AccountDataAccess().Get());
            return data;
        }
        public static AccountModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<AccountModel>(DataAccessFactory.AccountDataAccess().Get(id));
            return data;
        }

        public static List<string>GetNames()
        {
            var data = DataAccessFactory.AccountDataAccess().Get().Select(e => e.UserName).ToList();
            return data;
        }
        public static void Add(AccountModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AccountModel, Account>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Account>(a);
            DataAccessFactory.AccountDataAccess().Add(data);
        }
        public static void Edit(AccountModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Account>(a);
            DataAccessFactory.AccountDataAccess().Edit(data);
        }
        public static void Delete(AccountModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<int>(a);
            DataAccessFactory.AccountDataAccess().Delete(data);
        }
    }
}