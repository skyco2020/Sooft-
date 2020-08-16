﻿using BusinessServices.Interfaces;
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
    public class SingerController : ApiController
    {
        #region Dependency injection
        private ISingerService _services;

        public SingerController(ISingerService services)
        {
            _services = services;
        }
        #endregion

        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetAll(Int32 state = (Int32)StateEnum.Activated, String search = "")
        {
            IQueryable<SingerBE> query = _services.GetAll(state, search).AsQueryable();
            return Ok(query);
        }
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetById(Int64 id)
        {
            SingerBE query = _services.GetById(id);
            return Ok(query);
        }

        [AllowAnonymous]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Post(SingerBE be)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Int64 create = _services.Create(be);
            return Created(new Uri(Url.Link("DefaultApi", new { Id = create})), create);
        }
        [AllowAnonymous]
        [System.Web.Http.HttpPost]
        [Route("api/Singer/AddGenderSong")]
        public async Task<IHttpActionResult> PostAddGenderSong(SingerGenderBE be)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Int64 create = _services.CreateGenderSong(be);
            return Ok(create);
        }
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        [Route("api/Singer/GetAllDetail")]
        public async Task<IHttpActionResult> GetAllDetail(Int64 id = 0)
        {
            IQueryable<SingerGenderBE> query = _services.DetailGenderSong(id).AsQueryable();
            return Ok(query);
        }
    }
}
