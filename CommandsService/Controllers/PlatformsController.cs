using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mappper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mappper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
           var platforms = _repository.GetAllPlatforms();
           return Ok(_mappper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }


        [HttpPost]
        public ActionResult TestInboundConnection()
        {
         Console.WriteLine("Inbound Post");
         return Ok("Inbound test");
        }
    }
}