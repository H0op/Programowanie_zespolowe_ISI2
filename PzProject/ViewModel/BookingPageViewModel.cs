﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Utility;
using PzProject.View;
using System.ComponentModel.DataAnnotations;
using PzProject.Network;

namespace PzProject.ViewModel
{
    class BookingPageViewModel : BindableBase
    {
        #region Fields/Commands
        public ICommand PreviousPageCommand { get; set; }
        public ICommand BookingCommand { get; set; }

        private Grid _grid;
        private Seance _seance;
        private List<Spot> _spots;
        private string _selectedHour;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        private int _selectedDiscount;


        #endregion

        #region Properties

        public int SelectedDiscount
        {
            get { return _selectedDiscount; }
            set
            {
                SetProperty(ref _selectedDiscount, value);
                OnPropertyChanged("SelectedDiscount");
            }
        }

        public Grid Grid
        {
            get { return _grid; }
            set
            {
                SetProperty(ref _grid, value);
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("To pole jest wymagane");
                SetProperty(ref _firstName, value);
                OnPropertyChanged("FirstName");

            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("To pole jest wymagane");
                SetProperty(ref _lastName, value);
                OnPropertyChanged("LastName");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("To pole jest wymagane");
               if(!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException("Podany email jest bledny");
                SetProperty(ref _email, value);
                OnPropertyChanged("Email");
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("To pole nie moze byc puste");
                if (value.Length > 9)
                    throw new ArgumentException("Bledny numer");
                SetProperty(ref _phoneNumber, value);
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion

        #region Constructor

        public BookingPageViewModel(List<Spot> selectedSpots,Seance seance,string selectedHour)
        {
            _seance = seance;
            _spots = selectedSpots;
            _selectedHour = selectedHour;

            PreviousPageCommand = new RelayCommand(action => PreviousPage());
            BookingCommand = new RelayCommand(action => Booking(), () => canBooking());
            _grid = CreateDiscount();

        }

        #endregion

        #region Methods

        private Grid CreateDiscount()
        {
            var mainGrid = new Grid();
            ComboBox ulgi;
            TextBlock tekst;
            DatabasePZEntities context = new DatabasePZEntities();

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });


            for (int i = 0; i < _spots.Count; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                tekst = new TextBlock() { Text = "Bilet #" + mainGrid.RowDefinitions.Count };
                tekst.Margin = new Thickness(0, 0, 10, 10);
                tekst.Width = 150;
                Grid.SetColumn(tekst, 0);
                Grid.SetRow(tekst, i);
                mainGrid.Children.Add(tekst);

                ulgi = new ComboBox();
                ulgi.SelectedIndex = SelectedDiscount;
                ulgi.Width = 150;

                foreach (var ulga in context.ULGA)
                {
                    ulgi.Items.Add(new ComboBoxItem() { Content = ulga.Nazwa });
                }


                Grid.SetColumn(ulgi, 1);
                Grid.SetRow(ulgi, i);
                mainGrid.Children.Add(ulgi);
            }


            return mainGrid;
        }

        private void Booking()
        {
            using (DatabasePZEntities db = new DatabasePZEntities())
            {
                GODZINY updateSpot = db.GODZINY.Where(h => h.Godzina == _selectedHour).FirstOrDefault(s => s.Id_Seansu == _seance.SeansID);
                char[] spots = updateSpot.Miejsca.ToCharArray();


                bool canBooking = _spots.Where(n => spots[n.SpotNumber - 1] == '0').Count() != 0;

                if (canBooking)
                {
                    foreach (var spot in _spots)
                    {
                        BILET ticket = new BILET()
                        {
                            Potwierdzenie = 0,
                            Imie = _firstName,
                            Nazwisko = _lastName,
                            Email = _email,
                            Telefon = _phoneNumber,
                            Id_Godziny = updateSpot.Id_Godziny,
                            Id_ulga = _selectedDiscount + 1,
                            Realizacja = 0,
                            Miejsce = spot.SpotNumber - 1
                        };
                        db.BILET.Add(ticket);
                        spot.IsAvailable = 1;
                        spots[spot.SpotNumber - 1] = '1';
                    }
                    updateSpot.Miejsca = new string(spots);
                    db.SaveChanges();


                    // tresc emaila
                    string trescEmaila = "Tutaj bedzie jakas tresc emaila";

                    SendEmail email = new SendEmail();
                    email.SendAsync(_email, "Rezerwacja filmu", trescEmaila);

                    MessageBox.Show("Bilet zarezerwowany.");
                    NavigationManager.BackToMain();
                }
                else
                {
                    foreach (var spot in _spots)
                    {
                        spot.IsAvailable = 1;
                    }
                    MessageBox.Show("Miejsca zostaly juz przez kogos zarezerwowane. Prosze wybrac inne");
                    NavigationManager.BackToMain();
                }

            }

        }
        private void PreviousPage()
        {
            NavigationManager.Back();
        }

        private bool canBooking()
        {
            if (String.IsNullOrEmpty(_email) &&
                String.IsNullOrEmpty(_firstName) &&
                String.IsNullOrEmpty(_lastName) &&
                String.IsNullOrEmpty(_phoneNumber)) return false;
            else return true;
        }

        #endregion

    }
}
