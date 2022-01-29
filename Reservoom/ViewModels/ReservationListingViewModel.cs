using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            var reservationViewModels = hotel.GetAllReservations().Select(h => new ReservationViewModel(h));
            _reservations = new ObservableCollection<ReservationViewModel>(reservationViewModels);

            //_reservations = new ObservableCollection<ReservationViewModel>
            //{
            //    new ReservationViewModel(new Reservation(new RoomID(1, 2), "SingletonSean", DateTime.Now, DateTime.Now)),
            //    new ReservationViewModel(new Reservation(new RoomID(1, 3), "SingletonSam", DateTime.Now, DateTime.Now)),
            //    new ReservationViewModel(new Reservation(new RoomID(2, 2), "SingletonDill", DateTime.Now, DateTime.Now))
            //};

            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        }

        private void UpdateReservations()
        {
            _reservations.Clear();
            
        }

    }

}
