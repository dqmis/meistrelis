using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Models;

namespace meistrelis.Data.IRepos
{
    public interface IUserRatingRepo
    {
        bool SaveChanges();
        
        IEnumerable<UserRating> GetUsersRatings(int userId);
        void RateUser(UserRating usrR);
        void RemoveUserRating(UserRating usrR);
        UserRating GetUserRatingByRatedUserId(int rUsrId);
    }
}