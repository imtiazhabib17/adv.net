using BLL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

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

        [Route("api/Receiver/Create")]
        [HttpPost]
        public void Add(ReceiverModel a)
        {
            ReceiverService.Add(a);
        }

        [Route("api/Receiver/Edit")]
        [HttpPost]
        public void Edit(ReceiverModel a)
        {
            ReceiverService.Edit(a);
        }

        [Route("api/Receiver/Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(ReceiverModel a)
        {
            ReceiverService.Delete(a);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}