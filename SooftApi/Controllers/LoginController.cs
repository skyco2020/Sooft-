using BusinessServices.Interfaces;
using BussinessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SooftApi.Controllers
{
    public class LoginController : ApiController
    {
        #region Dependency injection
        private IUserService _services;

        public LoginController(IUserService services)
        {
            _services = services;
        }
        #endregion
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Authenticate(String username, String userpass)
        {
            UserBE query = _services.Login(username, userpass);
            return Ok(query);
        }
    }
}
