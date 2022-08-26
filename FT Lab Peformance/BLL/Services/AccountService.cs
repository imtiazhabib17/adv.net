using AutoMapper;
using DAL;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;


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
            var data = mapper.Map<List<AccountModel>>(AccountDAL.Get());
            return data;
        }
        public static List<string>GetNames()
        {
            var data = AccountDAL.Get().Select(e => e.UserName).ToList();
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
            AccountDAL.Add(data);
        }

    }
}



/*
namespace BLL.Services
{
    public class AccountService
    {
        private DataAccessLayer.Repositories.AccountDAL _DAL;
        private Mapper _AccountMapper;
        private Account accountEntity;

        public AccountService()
        {
            _DAL = new DataAccessLayer.Repositories.AccountDAL();
            var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<AccountModel, AccountModel>().ReverseMap());

            _AccountMapper = new Mapper(_configInventory);
        }

        public async Task<List<AccountModel>> GetAll()
        {
            List<Account> accountFromDb = await _DAL.GetAll();
            List<AccountModel> accountModel = _AccountMapper.Map<List<Account>, List<AccountModel>>(accountFromDb);

            return accountModel;
        }


        public async Task<AccountModel> GetAccountById(int id)
        {
            var data = await _DAL.GetAccountById(id);
            if (data != null)
            {
                AccountModel cd = _AccountMapper.Map<Account, AccountModel>(data);
                return cd;
            }
            return null;
        }

        public async Task<bool> PostAccount(AccountModel AccountModel)
        {
            Account accountEntity = _AccountMapper.Map<AccountModel, Account>(AccountModel);
            if (await _DAL.PostAccount(accountEntity))
            {
                return true;
            }
            return false;
        }


        public async Task DeleteAccount(AccountModel AccountModel)
        {
            Account account = _AccountMapper.Map<AccountModel, Account>(AccountModel);
            await _DAL.DeleteAccount(accountEntity);
        }
    }
}
*/