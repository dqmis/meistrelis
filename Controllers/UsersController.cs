using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using meistrelis.Data;
using meistrelis.Data.IRepos;
using meistrelis.Dtos;
using meistrelis.Dtos.User;
using meistrelis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace meistrelis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        
        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAppUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }

            return NotFound();
        }

        [HttpPut]
        public ActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var userModelFromRepo = _repository.GetUserById(id);
            
            if (userModelFromRepo != null)
            {
                _mapper.Map(userUpdateDto, userModelFromRepo);
                _repository.UpdateUser(userModelFromRepo);
                _repository.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }
        
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto createUserDto)
        {
            var userModel = _mapper.Map<User>(createUserDto);
            try
            {
                _repository.CreateUser(userModel);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("Entity exists");
            }

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new
            {
                Id = userReadDto.Id
            }, userReadDto);
        }
    }
}