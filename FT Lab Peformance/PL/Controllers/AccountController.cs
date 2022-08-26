using BLL;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace PL.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/Account/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return AccountService.GetNames();
        }

        [Route("api/Account/All")]
        [HttpGet]
        public List<AccountModel> GetAll()
        {
            return AccountService.Get();
        }

        [Route("api/Account/Create")]
        [HttpPost]
        public void Add(AccountModel a)
        {
            AccountService.Add(a);
        }
    }
}