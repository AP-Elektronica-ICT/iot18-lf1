﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI
{
    //API endpoints
    [Route("api/labfarm")]
    public class LabFarmController : ControllerBase
    {
        private LabFarmService _service;

        public LabFarmController(LabFarmService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/labfarm
        public IEnumerable<LabFarmModel> GetAll(string userId)
        {
            return _service.GetAll(userId);
        }

        [HttpGet("{id}")] // GET api/labfarm/5
        public LabFarmModel Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public LabFarmModel Put([FromBody]LabFarmModel labfarm)
        {
            return _service.Update(labfarm);
        }

        [HttpPost]
        public LabFarmModel Post([FromBody]LabFarmModel labfarm)
        {
            return _service.Create(labfarm);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }


    }
}