using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Models;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>
            {
                new ReservationViewModel(new Reservation(new RoomID(1, 2), "SingletonSean", DateTime.Now, DateTime.Now)),
                new ReservationViewModel(new Reservation(new RoomID(1, 3), "SingletonSam", DateTime.Now, DateTime.Now)),
                new ReservationViewModel(new Reservation(new RoomID(2, 2), "SingletonDill", DateTime.Now, DateTime.Now))
            };
        }
    }

}
