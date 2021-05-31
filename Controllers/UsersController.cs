using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Internal;
using meistrelis.Data;
using meistrelis.Data.IRepos;
using meistrelis.Dtos;
using meistrelis.Dtos.User;
using meistrelis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace meistrelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly IUserRatingRepo _ratingRepo;

        public UsersController(IUserRepo repository, IMapper mapper, IUserRatingRepo ratingRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _ratingRepo = ratingRepo;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAppUsers();
            var mapped_users = _mapper.Map<IEnumerable<UserReadDto>>(userItems);
            mapped_users.ToList().ForEach(u =>
            {
                u.Rating = _repository.GetUsersRating(u.Id);
            });
            return Ok(mapped_users);
        }

        [Authorize]
        [HttpGet("UnratedUsers")]
        public ActionResult<IEnumerable<UserReadDto>> GetUnratedUsers()
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var userModelFromRepo = _repository.GetUserById(id);
            var ratedUserIds = _ratingRepo.GetRatedUsersIds(id);
            var userItems = _repository.GetAppUsers();
            var ratedUsers = userItems.Where(u => !ratedUserIds.Contains(u.Id)).ToList();
            var mapped_users = _mapper.Map<IEnumerable<UserReadDto>>(userItems);
            mapped_users.ToList().ForEach(u =>
            {
                u.Rating = _repository.GetUsersRating(u.Id);
            });
            return Ok(mapped_users);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if (userItem != null)
            {
                var mappedUser = _mapper.Map<UserReadDto>(userItem);
                mappedUser.Rating = _repository.GetUsersRating(id);
                return Ok(mappedUser);
            }

            return NotFound();
        }

        [Authorize]
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