using BusinessServices.Interfaces;
using BussinessEntities.BE;
using Resolver.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SooftApi.Controllers
{
    public class GenderController : ApiController
    {
        #region Dependency injection
        private IGenderService _services;

        public GenderController(IGenderService services)
        {
            _services = services;
        }
        #endregion

        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetAll(Int32 state = (Int32)StateEnum.Activated, String search = "")
        {
            IQueryable<GenderBE> query = _services.GetAll(state, search).AsQueryable();
            return Ok(query);
        }

        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetById(Int64 id)
        {
            GenderBE query = _services.GetById(id);
            return Ok(query);
        }

        [AllowAnonymous]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Post(GenderBE be)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Int64 create = _services.Create(be);
            return Created(new Uri(Url.Link("DefaultApi", new { Id = create })), create);
        }
    }
}
