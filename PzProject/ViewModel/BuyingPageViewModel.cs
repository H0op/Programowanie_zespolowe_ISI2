using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    class BuyingPageViewModel: BindableBase
    {
        #region Fields/Commands
        public ICommand PreviousPageCommand { get; set; }
        public ICommand BuyingCommand { get; set; }

        private Grid _grid;
        private Seance _seance;
        private List<Spot> _spots;
        private string _selectedHour;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;


        #endregion

        #region Properties

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
                SetProperty(ref _firstName, value);
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                OnPropertyChanged("LastName");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                OnPropertyChanged("Email");
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetProperty(ref _phoneNumber, value);
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion

        #region Constructor

        public BuyingPageViewModel(List<Spot> selectedSpots, Seance seance, string selectedHour)
        {
            _seance = seance;
            _spots = selectedSpots;
            _selectedHour = selectedHour;

            PreviousPageCommand = new RelayCommand(action => PreviousPage());
            BuyingCommand = new RelayCommand(action => Buying((string)action));
            _grid = CreateDiscount();
        }

        #endregion

        #region Methods

        private Grid CreateDiscount()
        {
            var mainGrid = new Grid();
            ComboBox ulgi;
            TextBlock tekst;

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
                ulgi.Width = 150;
                ulgi.Items.Add(new ComboBoxItem() { Content = "Zwykly" });
                ulgi.Items.Add(new ComboBoxItem() { Content = "Ulgowy" });


                Grid.SetColumn(ulgi, 1);
                Grid.SetRow(ulgi, i);
                mainGrid.Children.Add(ulgi);
            }


            return mainGrid;
        }

        private void Buying(string metoda)
        {
            MessageBox.Show(_phoneNumber+ " "+ metoda);
        }
        private void PreviousPage()
        {
            NavigationManager.NavigateTo(new RoomPage(_seance, _selectedHour));
        }

        #endregion
    }
}
