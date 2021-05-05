using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using meistrelis.Data.IRepos;
using meistrelis.Models;
using user.PostgreSQL;

namespace meistrelis.Data.SqlRepos 
{
    public class SqlReservationRepo : IReservationRepo
    {
        private readonly MeistrelisContext _context;

        public SqlReservationRepo(MeistrelisContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateReservation(Reservation userR)
        {
            var q = _context.Reservations.Where(r => r.Service.UserId == userR.Service.UserId);
            var res = q.Where(r => r.ReservationDate == userR.ReservationDate).FirstOrDefault();

            if (res != null)
            {
                throw new ArgumentException(nameof(userR));
            }
            
            if (userR == null)
            {
                throw new ArgumentNullException(nameof(userR));
            }

            _context.Add(userR);
        }

        public IEnumerable<Reservation> GetReservationsByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CancelReservation(Reservation userR)
        {
            throw new System.NotImplementedException();
        }
    }
    
}