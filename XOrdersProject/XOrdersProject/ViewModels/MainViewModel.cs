﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XOrdersProject.Pages;
using XOrdersProject.Services;

namespace XOrdersProject.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;
        public MainViewModel()
        {
            navigationService = new NavigationService();
            LoadMenu();
            LoadData();
        }

        #region Properties
        public OrderViewModel NewOrder { get; private set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion


        #region Commands
        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }


        private void Start()
        {
            //var list = await apiService.GetAllOrders();
            //Orders.Clear();

            //foreach (var item in list)
            //{
            //    Orders.Add(new OrderViewModel()
            //    {
            //        Title = item.Title,
            //        DeliveryDate = item.DeliveryDate,
            //        Description = item.Description
            //    });
            //}

            navigationService.SetMainPage("MasterPage");
        }
        #endregion
        #region Methods
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Pedidos",
                PageName = "MainPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_client",
                Title = "Clientes",
                PageName = "ClientsPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_alarm",
                Title = "Alarmas",
                PageName = "AlarmsPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_settings",
                Title = "Ajustes",
                PageName = "SettingsPage"
            });
        }

        private void LoadData()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            for (int i = 0; i < 5; i++)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title = "Hola Bienvenido",
                    DeliveryDate = DateTime.Today,
                    Description = "Usando xamarin para darle cambios al aplicativo web"
                });
            }
        } 
        #endregion
    }
}
