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
    public class DonarController : ApiController
    {
        [Route("api/Donar/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return DonarService.GetNames();
        }

        [Route("api/Donar/All")]
        [HttpGet]
        public List<DonarModel> GetAll()
        {
            return DonarService.Get();
        }

        [Route("api/Donar/Create")]
        [HttpPost]
        public void Add(DonarModel a)
        {
            DonarService.Add(a);
        }

        [Route("api/donar/Edit")]
        [HttpPost]
        public void Edit(DonarModel a)
        {
            DonarService.Edit(a);
        }

        [Route("api/donar/Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(DonarModel a)
        {
            DonarService.Delete(a);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}