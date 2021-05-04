using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using meistrelis.Data.IRepos;
using meistrelis.Models;
using Microsoft.EntityFrameworkCore;
using user.PostgreSQL;

namespace meistrelis.Data.SqlRepos
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly MeistrelisContext _context;

        public SqlUserRepo(MeistrelisContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<User> GetAppUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public void CreateUser(User usr)
        {
            if (usr == null)
            {
                throw new ArgumentNullException(nameof(usr));
            }

            usr.Password = BCrypt.Net.BCrypt.HashPassword(usr.Password);

            _context.Add(usr);
        }

        public void UpdateUser(User usr)
        {
        }

        public void DeleteUser(User usr)
        {
            if (usr == null)
            {
                throw new ArgumentNullException(nameof(usr));
            }

            _context.Users.Remove(usr);
        }

        public double GetUsersRating(int id)
        {
            var res = _context.UserRatings.Where(r => r.RatedUserId == id);
            if (res.Any())
            {
                return res.Average(r => r.Score);
            }

            return 0;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}