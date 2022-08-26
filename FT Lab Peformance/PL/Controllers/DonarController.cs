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

        [Route("api/Donar/Createl")]
        [HttpPost]
        public void Add(DonarModel a)
        {
            DonarService.Add(a);
        }
    }
}