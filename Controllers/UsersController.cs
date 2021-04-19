using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using meistrelis.Data;
using meistrelis.Dtos;
using meistrelis.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace meistrelis.Controllers
{
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

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
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

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            
            if (userModelFromRepo != null)
            {
                var userToPath = _mapper.Map<UserUpdateDto>(userModelFromRepo);
                patchDocument.ApplyTo(userToPath, ModelState);
                if (!TryValidateModel(userToPath))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(userToPath, userModelFromRepo);
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

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}