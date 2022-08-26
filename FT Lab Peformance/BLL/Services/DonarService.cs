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
    public class DonarService
    {
        public static List<DonarModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<DonarModel>>(DonarDAL.Get());
            return data;
        }
        public static List<string> GetNames()
        {
            var data = DonarDAL.Get().Select(e => e.Name).ToList();
            return data;
        }
        public static void Add(DonarModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Donar>(a);
            DonarDAL.Add(data);
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








/*using AutoMapper;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DonarService
    {
            private DataAccessLayer.Repositories.DonarDAL _DAL;
            private Mapper _DonarMapper;

            public DonarService()
            {
                _DAL = new DataAccessLayer.Repositories.DonarDAL();
                var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<DonarModel, DonarModel>().ReverseMap());

                _DonarMapper = new Mapper(_configInventory);
            }

            public async Task<List<DonarModel>> GetAll()
            {
                List<Donar> donarFromDb = await _DAL.GetAll();
                List<DonarModel> donarModel = _DonarMapper.Map<List<Donar>, List<DonarModel>>(donarFromDb);

                return donarModel;
            }


            public async Task<DonarModel> GetDonarById(int id)
            {
                var data = await _DAL.GetDonarById(id);
                if (data != null)
                {
                    DonarModel cM = _DonarMapper.Map<Donar, DonarModel>(data);
                    return cM;
                }
                return null;
            }

            public async Task<bool> PostDonar(DonarModel DonarModel)
            {
                Donar donarEntity = _DonarMapper.Map<DonarModel, Donar>(DonarModel);
                if (await _DAL.PostDonar(donarEntity))
                {
                    return true;
                }
                return false;
            }


            public async Task DeleteDonar(DonarModel DonarModel)
            {
                Donar donarEntity = _DonarMapper.Map<DonarModel, Donar>(DonarModel);
                await _DAL.DeleteDonar(donarEntity);
            }
        }
}*/
