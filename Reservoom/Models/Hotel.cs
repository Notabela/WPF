using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private ReservationBook _reservationBook;

        public string Name { get;  }
        

        public Hotel(string name)
        {
            this.Name = name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get all Reservations
        /// </summary>
        /// <returns>all reservations</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }

    }
}
