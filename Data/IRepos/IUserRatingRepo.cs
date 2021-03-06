using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Dtos.User;
using meistrelis.Dtos.UserRating;
using meistrelis.Models;

namespace meistrelis.Data.IRepos
{
    public interface IUserRatingRepo
    {
        bool SaveChanges();

        void RateUser(UserRating usrR);
        UserRatingReadDto GetUserRatingByIds(int reviewerId, int ratedId);
        List<int> GetRatedUsersIds(int reviewerId);
        UserRating GetUserRatingByIdsRepo(int reviewerId, int ratedId);
        void RemoveUserRating(UserRating usrR);
        IEnumerable<UserRating> GetUserRatingsByRatedUserId(int rUsrId);
        IEnumerable<UserRating> GetUserRatings();
    }
}