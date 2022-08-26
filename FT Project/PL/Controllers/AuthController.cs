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
    public class AuthController : ApiController
    {
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token= Request.Headers.Authorization.ToString();
            if(token !=null)
            {
                var rs = AuthService.Logout(token);
                if(rs)
                {
                   return  Request.CreateResponse(HttpStatusCode.OK,"Succesfully logged out");
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token");
        }

        [Route("api/user/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserModel user)
        {
            var token = AuthService.Authenticate(user);
            if(token !=null )
            {
                return new HttpResponseMessage(HttpStatusCode.OK);  
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
        [Route("api/admin/login")]
        [HttpPost]
        public HttpResponseMessage Login(AccountModel ac)
        {
            var token = AuthService2.Authenticate(ac);
            if (token != null)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
    }
}
