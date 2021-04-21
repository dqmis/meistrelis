using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using meistrelis.Data.IRepos;
using meistrelis.Dtos.UserService;
using meistrelis.Migrations;
using meistrelis.Models;
using Microsoft.EntityFrameworkCore;
using user.PostgreSQL;

namespace meistrelis.Data.SqlRepos
{
    public class SqlUserRatingRepo : IUserRatingRepo
    {
        private readonly MeistrelisContext _context;
        
        public SqlUserRatingRepo(MeistrelisContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<UserRating> GetUsersRatings(int userId)
        {
            return _context.User
        }

        public void RateUser(UserRating usrR)
        {
            if (usrR == null)
            {
                throw new ArgumentNullException(nameof(usrR));
            }

            _context.Add(usrR);
        }

        public void RemoveUserRating(UserRating usrR)
        {
            throw new NotImplementedException();
        }

        public UserRating GetUserRatingByRatedUserId(int rUsrId)
        {
            throw new NotImplementedException();
        }
    }
}