using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using meistrelis.Data;
using meistrelis.Data.IRepos;
using meistrelis.Dtos;
using meistrelis.Dtos.Service;
using meistrelis.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace meistrelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepo _repository;
        private readonly IMapper _mapper;
        
        public ServicesController(IServiceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ServiceReadDto>> GetAllServices()
        {
            var serviceItems = _repository.GetAppServices();
            return Ok(_mapper.Map<IEnumerable<ServiceReadDto>>(serviceItems));
        }

        [HttpGet("{id}", Name = "GetServiceById")]
        public ActionResult<ServiceReadDto> GetServiceById(int id)
        {
            var serviceItem = _repository.GetServiceById(id);
            if (serviceItem != null)
            {
                return Ok(_mapper.Map<ServiceReadDto>(serviceItem));
            }

            return NotFound();
        }
    }
}