using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using meistrelis.Data;
using meistrelis.Data.IRepos;
using meistrelis.Dtos;
using meistrelis.Dtos.Service;
using meistrelis.Dtos.UserRating;
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
    public class UserRatingsController : ControllerBase
    {
        private readonly IUserRatingRepo _repository;
        private readonly IMapper _mapper;

        public UserRatingsController(IUserRatingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<UserRating> GetUsersRatings(int id)
        {
            return Ok(_repository.GetUserRatingsByRatedUserId(id));
        }
        
        [HttpPost("{userId}")]
        public ActionResult<UserRatingReadDto> RateUser(int userId, UserRatingCreateDto usrCreateDto)
        {
            var reviewerUserId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var userRatingModel = _mapper.Map<UserRating>(usrCreateDto);
            userRatingModel.ReviewerId = Int32.Parse(reviewerUserId);
            userRatingModel.RatedUserId = userId;

            try
            {
                _repository.RateUser(userRatingModel);
                _repository.SaveChanges();

            }
            catch (Exception e)
            {
                return BadRequest("Entity exists");
            }

            return Ok(_repository.GetUserRatingByIds(Int32.Parse(reviewerUserId), userId));
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUserRating(int userId)
        {
            var reviewerUserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var reviewUserReviewModel = _repository.GetUserRatingByIdsRepo(reviewerUserId, userId);

            if (reviewUserReviewModel == null)
            {
                return NotFound();
            }
            
            _repository.RemoveUserRating(reviewUserReviewModel);
            _repository.SaveChanges();

            return NoContent();
        }
        
        
    }
}