using BEL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
    public class TokenController : ApiController
    {
        [Route("api/tokens")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TokenService.Get());
        }

        [Route("api/tokens/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string token)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TokenService.Get(token));
        }

        [Route("api/tokens/create")]
        [HttpPost]
        public HttpResponseMessage Create(TokenModel token)
        {
            TokenService.Create(token);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/tokens/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(TokenModel token)
        {
            TokenService.Edit(token);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/tokens/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(TokenModel token)
        {
            TokenService.Delete(token);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
