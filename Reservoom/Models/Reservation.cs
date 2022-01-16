using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get;  }

        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            StartTime = startTime;
            Username = username;
            EndTime = endTime;
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != this.RoomID)
            {
                return false;
            }

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
