using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using meistrelis.Data;
using meistrelis.Data.IRepos;
using meistrelis.Dtos;
using meistrelis.Dtos.Service;
using meistrelis.Dtos.UserService;
using meistrelis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace meistrelis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        private readonly IUserServiceRepo _repository;
        private readonly IMapper _mapper;
        
        public UserServicesController(IUserServiceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserServiceReadDto> CreateUserService(UserServiceCreateDto usrServ)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var userServiceModel = _mapper.Map<UserService>(usrServ);
            userServiceModel.UserId = Int32.Parse(userId);
            try
            {
                _repository.CreateUserService(userServiceModel);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("Entity exists");
            }

            var savedUserServ = _repository.GetUserServicesByUserAndServiceId(Int32.Parse(userId), userServiceModel.ServiceId);

            return Ok(savedUserServ);
        }
        
        [HttpPut("{serviceId}")]
        public ActionResult <UserServiceReadDto> UpdateUserService(int serviceId, UserServiceUpdateDto usrServ)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var userServiceFromRepo = _repository.GetUserServicesByUserAndServiceIdRepo(userId, serviceId);
            

            if (userServiceFromRepo != null)
            {
                _mapper.Map(usrServ, userServiceFromRepo);
                _repository.UpdateUserService(userServiceFromRepo);
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<UserServiceReadDto>> GetAllServices()
        {
            var serviceItems = _repository.GetAppUserServices();
            return Ok(serviceItems);
        }
        
        [HttpDelete("{serviceId}")]
        public ActionResult DeleteUserService(int serviceId)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var userServiceModelFromRepo = _repository.GetUserServicesByUserAndServiceIdRepo(userId,serviceId);
            if (userServiceModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUserService(userServiceModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("user/{id}", Name = "GetUserServiceByUserId")]
        public ActionResult<UserServiceReadDto> GetServiceByUserId(int id)
        {
            var serviceItem = _repository.GetUserServicesByUserId(id);
            if (serviceItem != null)
            {
                return Ok(serviceItem);
            }

            return NotFound();
        }
        
        [HttpGet("service/{id}", Name = "GetUserServiceByServiceId")]
        public ActionResult<UserServiceReadDto> GetServiceByServiceId(int id)
        {
            var serviceItem = _repository.GetUserServicesByServiceId(id);
            if (serviceItem != null)
            {
                return Ok(serviceItem);
            }

            return NotFound();
        }
    }
}