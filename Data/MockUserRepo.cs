using System;
using System.Collections.Generic;
using meistrelis.Models;

namespace meistrelis.Data
{
    public class MockUserRepo : IUserRepo
    {
        public IEnumerable<User> GetAppUsers()
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<User> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
    
}