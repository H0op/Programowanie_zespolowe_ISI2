﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PzProject.Model;
using PzProject.ViewModel;
using System.Windows.Markup;
using System.Xml;

namespace PzProject.View
{
    public partial class BookingPage : Page
    {

        private BookingPageViewModel _viewModel;

        public BookingPage(List<Spot> selectedSpots,Seance seance,string selectedHour)
        {
            InitializeComponent();
            _viewModel = new BookingPageViewModel(selectedSpots, seance, selectedHour);
            this.DataContext = _viewModel;
        }
    }
}
