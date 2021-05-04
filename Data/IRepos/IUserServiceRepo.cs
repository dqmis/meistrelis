using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Dtos.UserService;
using meistrelis.Models;

namespace meistrelis.Data.IRepos
{
    public interface IUserServiceRepo
    {
        bool SaveChanges();

        IEnumerable<UserServiceReadDto> GetAppUserServices();
        IEnumerable<UserServiceReadDto> GetUserServicesByUserId(int id);
        IEnumerable<UserServiceReadDto> GetUserServicesByServiceId(int id);
        UserServiceReadDto GetUserServicesByUserAndServiceId(int userId, int serviceId);
        UserService GetUserServicesByUserAndServiceIdRepo(int userId, int serviceId);
        void CreateUserService(UserService userServ);
        void UpdateUserService(UserService usrServ);
        void DeleteUserService(UserService usrServ);
    }
}