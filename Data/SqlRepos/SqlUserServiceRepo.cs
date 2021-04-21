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
    public class SqlUserServiceRepo : IUserServiceRepo
    {
        private readonly MeistrelisContext _context;
        
        public SqlUserServiceRepo(MeistrelisContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<UserServiceReadDto> GetAppUserServices()
        {
            return _context.UserServices.Select(us => new UserServiceReadDto
            {
                Price = us.Price,
                ServiceTitle = us.Service.Title,
                MechanicEmail = us.User.Email,
                MechanicFullname = us.User.Fullname
            });
        }

        public IEnumerable<UserServiceReadDto> GetUserServicesByUserId(int id)
        {
            return _context.UserServices.Where(u=> u.UserId == id).Select(us => new UserServiceReadDto
            {
                Price = us.Price,
                ServiceTitle = us.Service.Title,
                MechanicEmail = us.User.Email,
                MechanicFullname = us.User.Fullname
            });
        }
        
        public IEnumerable<UserServiceReadDto> GetUserServicesByServiceId(int id)
        {
            return _context.UserServices.Where(u=> u.ServiceId == id).Select(us => new UserServiceReadDto
            {
                Price = us.Price,
                ServiceTitle = us.Service.Title,
                MechanicEmail = us.User.Email,
                MechanicFullname = us.User.Fullname
            });
        }

        public UserServiceReadDto GetUserServicesByUserAndServiceId(int userId, int serviceId)
        {
            var userQuery = _context.UserServices.Where(us => us.UserId == userId);
            return userQuery.Where(us => us.ServiceId == serviceId).Select(us => new UserServiceReadDto
            {
                Price = us.Price,
                ServiceTitle = us.Service.Title,
                MechanicEmail = us.User.Email,
                MechanicFullname = us.User.Fullname
            }).FirstOrDefault();
        }
        
        public UserService GetUserServicesByUserAndServiceIdRepo(int userId, int serviceId)
        {
            var userQuery = _context.UserServices.Where(us => us.UserId == userId);
            return userQuery.Where(us => us.ServiceId == serviceId).FirstOrDefault();
        }

        public void CreateUserService(UserService userServ)
        {
            if (userServ == null)
            {
                throw new ArgumentNullException(nameof(userServ));
            }
            
            _context.Add(userServ);
        }

        public void UpdateUserService(UserService userServ)
        {
        }

        public void DeleteUserService(UserService userServ)
        {
            if (userServ == null)
            {
                throw new ArgumentNullException(nameof(userServ));
            }
            
            _context.UserServices.Remove(userServ);
        }
    }
}