using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservoom.Models;
using Reservoom.Stores;

namespace Reservoom.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            // subscribe to the navigationStore event
            _navigationStore.CurrentViewModelChanged += OnCurrentModelChanged;
        }

        private void OnCurrentModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
