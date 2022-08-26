using BLL;
using BEL;
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
        [CustomAuth]

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

        [Route("api/Account/Edit")]
        [HttpPost]
        public void Edit(AccountModel a)
        {
            AccountService.Edit(a);
        }

        [Route("api/Account/Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(AccountModel a)
        {
            AccountService.Delete(a);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}