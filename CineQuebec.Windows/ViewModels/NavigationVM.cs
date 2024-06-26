﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Utilities;
using System.Windows.Input;
using CineQuebec.Windows.ViewModels;
using CineQuebec.Windows.View;

namespace CineQuebec.Windows.ViewModels
{
    class NavigationVM :Utilities. ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand UsersCommand { get; set; }
        public ICommand HomeAdminCommand { get; set; }


        private void Users(object obj) => CurrentView = new UsersVm();
        private void HomeAdmin(object obj) => CurrentView = new AdminHomVm();
       

        public NavigationVM()
        {
            UsersCommand = new RelayCommand(Users);
            HomeAdminCommand = new RelayCommand(HomeAdmin);
          
            // Startup Page
            CurrentView = new AdminHomVm();
        }
    }
}
