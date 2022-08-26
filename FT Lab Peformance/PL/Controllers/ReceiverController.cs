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
    public class ReceiverController : ApiController
    {
        [Route("api/Receiver/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return ReceiverService.GetNames();
        }

        [Route("api/Receiver/All")]
        [HttpGet]
        public List<ReceiverModel> GetAll()
        {
            return ReceiverService.Get();
        }

        [Route("api/Receiver/Createl")]
        [HttpPost]
        public void Add(ReceiverModel a)
        {
            ReceiverService.Add(a);
        }
    }
}