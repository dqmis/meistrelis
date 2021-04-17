using System.Collections.Generic;
using meistrelis.Models;

namespace meistrelis.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAppUsers();
        User GetUserById(int id);
    }
}