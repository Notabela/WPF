using Reservoom.Models;
using Reservoom.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Reservoom.ViewModels;
using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.Services.ReservationProviders;
using Reservoom.Services.ReservationConflictValidators;
using Reservoom.Services.ReservationCreators;


namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly string CONNECTION_STRING = @"Data Source=localhost;Initial Catalog=reservoom;Trusted_Connection=True;";
        private readonly ReservoomDbContextFactory _reservoomDbContextFactory;
        private readonly Hotel _hotel;

        public App()
        {
            _reservoomDbContextFactory = new ReservoomDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_reservoomDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_reservoomDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_reservoomDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);

            _hotel = new Hotel("SingletonSean Suites", reservationBook);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (ReservoomDbContext dbContext = _reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_hotel)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
