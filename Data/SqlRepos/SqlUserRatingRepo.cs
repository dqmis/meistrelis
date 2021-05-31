using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using meistrelis.Data.IRepos;
using meistrelis.Dtos.User;
using meistrelis.Dtos.UserRating;
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

        public void RateUser(UserRating usrR)
        {
            if (usrR == null)
            {
                throw new ArgumentNullException(nameof(usrR));
            }

            _context.Add(usrR);
        }

        public List<int> GetRatedUsersIds(int reviewerId)
        {
            return _context.UserRatings.Where(r => r.ReviewerId == reviewerId).Select(r => r.RatedUserId).ToList();
        }

        public UserRatingReadDto GetUserRatingByIds(int reviewerId, int ratedId)
        {
            var q = _context.UserRatings.Where(r => r.ReviewerId == reviewerId);
            return q.Where(r => r.RatedUserId == ratedId).Select(r => new UserRatingReadDto
            {
                ReviewerFullname = r.Reviewer.Fullname,
                Description = r.Description,
                Score = r.Score,
            }).FirstOrDefault();
        }

        public UserRating GetUserRatingByIdsRepo(int reviewerId, int ratedId)
        {
            var q = _context.UserRatings.Where(r => r.ReviewerId == reviewerId);
            return q.Where(r => r.RatedUserId == ratedId).FirstOrDefault();
        }

        public void RemoveUserRating(UserRating usrR)
        {
            if (usrR == null)
            {
                throw new ArgumentNullException();
            }

            _context.UserRatings.Remove(usrR);
        }

        public IEnumerable<UserRating> GetUserRatingsByRatedUserId(int rUsrId)
        {
            return _context.UserRatings.Where(r => r.RatedUserId == rUsrId).ToList();
        }
        
        public IEnumerable<UserRating> GetUserRatings()
        {
            return _context.UserRatings.ToList();
        }
    }
}