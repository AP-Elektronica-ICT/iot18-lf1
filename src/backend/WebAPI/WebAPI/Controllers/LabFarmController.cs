﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using ViewModels;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/labfarm")]
    public class LabFarmController : Controller
    {
        private LabFarmService _labfarmService;
        private PlantService _plantService;
        private SensorService _sensorService;
        private SensorDataService _sensorDataService;
        private PictureService _pictureService;

        public LabFarmController(LabFarmService labfarmService, PlantService plantService, SensorService sensorService, SensorDataService sensorDataService, PictureService pictureService)
        {
            _labfarmService = labfarmService;
            _plantService = plantService;
            _sensorService = sensorService;
            _sensorDataService = sensorDataService;
            _pictureService = pictureService;
        }

        [HttpGet("{id:int}")] 
        public LabFarm Get(int id)
        {
            return _labfarmService.GetById(id);
        }

        [HttpGet("{authId?}")]
        public List<LabFarm> GetList(string authId = "")
        {
            return _labfarmService.GetList(authId);
        }

        [HttpPut("{id}")]
        public LabFarm Put([FromBody]LabFarm labfarm,int id)
        {
            return _labfarmService.Update(labfarm,id);
        }

        [HttpPost]
        public LabFarm Post([FromBody]LabFarm labfarm)
        {
            return _labfarmService.Create(labfarm);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _labfarmService.Delete(id);
        }

        [HttpGet("{id}/plants")]
        public List<Plant> GetPlants(int id)
        {
            return _labfarmService.GetById(id).Plants.ToList();
        }

        [HttpGet("{id}/plants/pictures")]
        public List<LastPictures> GetPlants(int id, int count)
        {
            return _plantService.GetLastPictures(id, count);
        }

        [HttpPost("{id}/plants")]
        public Plant PostCamera([FromBody]Plant plant, int id)
        {
            plant.Labfarm = _labfarmService.GetById(id);
            return _plantService.Create(plant);
        }

        [HttpGet("{id}/plants/{plantName}")]
        public List<Plant> GetPlant(int id, string plantName)
        {
            return _labfarmService.GetPlant(id, plantName);
        }

        [HttpPost("{id}/plants/{plantName}/pictures")]
        public Picture PostPicture([FromBody]Picture picture, int id, string plantName)
        {
            picture.Plant = _labfarmService.GetPlant(id, plantName)[0]; //TODO bad code?
            return _pictureService.Create(picture);
        }

        [HttpGet("{id}/sensors")]
        public List<Sensor> GetSensors(int id)
        {
            return _labfarmService.GetById(id).Sensors.ToList();
        }

        [HttpGet("{id}/sensors/values")]
        public List<LastSensorValues> GetSensors(int id, int count)
        {
            return _sensorService.GetLastValues(id, count);
        }

        [HttpPost("{id}/sensors")]
        public Sensor PostSensor([FromBody]Sensor sensor, int id)
        {
            sensor.LabFarm = _labfarmService.GetById(id);
            return _sensorService.Create(sensor);
        }
        [HttpGet("{id}/sensors/{sensorName}")]
        public List<Sensor> GetSensor(int id, string sensorName)
        {
            return _labfarmService.GetSensor(id, sensorName);
        }

        [HttpPost("{id}/sensors/{sensorName}/data")]
        public SensorData PostSensorData([FromBody]SensorData data, int id, string sensorName)
        {
            data.Sensor = _labfarmService.GetSensor(id, sensorName)[0]; // TODO bad code?
            return _sensorDataService.Create(data);
        }


    }
}
