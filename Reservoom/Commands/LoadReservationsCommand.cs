using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly Hotel _hotel;
        private readonly ReservationViewModel _viewModel;

        public LoadReservationsCommand(Hotel hotel, ReservationViewModel viewModel)
        {
            _hotel = hotel;
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
