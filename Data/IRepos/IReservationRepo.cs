using System.Collections.Generic;
using meistrelis.Dtos;
using meistrelis.Dtos.UserRating;
using meistrelis.Models;

namespace meistrelis.Data.IRepos
{
    public interface IReservationRepo
    {
        bool SaveChanges();

        void CreateReservation(Reservation userR);
        IEnumerable<Reservation> GetReservationsByUserId(int id);
        void CancelReservation(Reservation userR);
    }
}