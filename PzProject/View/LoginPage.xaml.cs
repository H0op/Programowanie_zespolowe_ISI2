﻿using System;
using System.Collections.Generic;
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
using PzProject.ViewModel;

namespace PzProject.View
{
    public partial class LoginPage : Page
    {
        private LoginPageViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginPageViewModel();
            this.DataContext = _viewModel;
        }
    }
}
