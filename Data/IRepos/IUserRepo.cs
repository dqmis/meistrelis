using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Models;

namespace meistrelis.Data.IRepos
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAppUsers();
        User GetUserById(int id);
        void CreateUser(User usr);
        void UpdateUser(User usr);
        void DeleteUser(User usr);
        double GetUsersRating(int id);
        User GetUserByEmailAndPassword(string email, string password);
    }
}