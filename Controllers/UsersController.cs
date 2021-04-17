using System.Collections;
using System.Collections.Generic;
using meistrelis.Data;
using meistrelis.Models;
using Microsoft.AspNetCore.Mvc;

namespace meistrelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        
        public UsersController(IUserRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetAppUsers();
            return Ok(userItems);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            return Ok(userItem);
        }
    }
}