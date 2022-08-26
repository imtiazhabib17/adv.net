using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using BEL;

namespace PL.Controllers
{
    public class UserController : ApiController
    {
        [CustomAuth]

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
        }

        [Route("api/users/create")]
        [HttpPost]
        public HttpResponseMessage Add(UserModel user)
        {
            UserService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/users/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/users/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(UserModel user)
        {
            UserService.Delete(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
