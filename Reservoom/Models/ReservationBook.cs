using Reservoom.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        /// <summary>
        /// Add a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <exception cref="ReservationConflictException">if reservation conflicts</exception>
        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _reservations)
            {
               if (existingReservation.Conflicts(reservation))
               {
                    throw new ReservationConflictException(existingReservation, reservation);
               }
            }
            _reservations.Add(reservation);
        }

    }
}
