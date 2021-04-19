using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Models;

namespace meistrelis.Data
{
    public interface IServiceRepo
    {
        bool SaveChanges();
        
        IEnumerable<Service> GetAppServices();
        Service GetServiceById(int id);
    }
}