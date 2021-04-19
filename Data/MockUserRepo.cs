using System;
using System.Collections.Generic;
using meistrelis.Models;

namespace meistrelis.Data
{
    public class MockUserRepo : IUserRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAppUsers()
        {
            var users = new List<User>
            {
                new User { Id = 1, Fullname = "Ponas Testas", Email = "test@testas.com", Password = "testavimas", IsMechanic = true },
                new User { Id = 2, Fullname = "Ponia Testiene", Email = "test2@testas.com", Password = "testavimas2", IsMechanic = false }

            };
            
            return users;
        }
        
        public User GetUserById(int id)
        {
            return new User
            {
                Id = 1, Fullname = "Ponas Testas", Email = "test@testas.com", Password = "testavimas", IsMechanic = true
            };
        }

        public void CreateUser(User usr)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User usr)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User usr)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
    
}