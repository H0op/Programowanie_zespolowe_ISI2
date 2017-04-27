using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;
using PzProject.Model;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    public class RoomPageViewModel : BindableBase
    {
        #region Fields/Commands
        public ICommand PreviousPageCommand { get; set; }
        public ICommand SelectSpotCommand { get; set; }
        public ICommand BookingCommand { get; set; }
        public ICommand BuyingCommand { get; set; }



        private Grid _grid;
        private Room _room;
        private string _selectedHour;
        private Seance _seance;
        private List<Spot> _selectedSpots;
        #endregion

        #region Properties
        public Grid Grid
        {
            get
            {
                return _grid;
            }
            set
            {
                SetProperty(ref _grid, value);
            }
        }

        public Seance Seance
        {
            get { return _seance; }
            set { SetProperty(ref _seance, value); }
        }

        #endregion

        #region Constructor

        public RoomPageViewModel(Seance selectedSeance, string hour)
        {
            PreviousPageCommand = new RelayCommand(action => PreviousPage());
            SelectSpotCommand = new RelayCommand(action => SelectSpot( (Spot)action ));
            BookingCommand = new RelayCommand(action => Booking());
            BuyingCommand = new RelayCommand(action => Buying());
            _selectedSpots = new List<Spot>();

            _selectedHour = hour;
            _seance = selectedSeance;
            _room = _seance.Rooms[selectedSeance.SeanceHours.IndexOf(_selectedHour)];
            _grid = CreateView();
        }


        #endregion

        #region Methods

        private void SelectSpot(Spot spot)
        {
            if (_selectedSpots.Contains(spot))
            {
                _selectedSpots.Remove(spot);
                SpotButton selectedSpotButton = _grid.Children.Cast<SpotButton>().First(e => Grid.GetRow(e) == spot.Row && Grid.GetColumn(e) == spot.Column);
                selectedSpotButton.Background = Brushes.Gray;
            }
            else
            {
                _selectedSpots.Add(spot);
                SpotButton selectedSpotButton = _grid.Children.Cast<SpotButton>().First(e => Grid.GetRow(e) == spot.Row && Grid.GetColumn(e) == spot.Column);
                selectedSpotButton.Background = Brushes.ForestGreen;
            }
        }

        private Grid CreateView()
        {
            var mainGrid = new Grid();
            SpotButton spotButton;
            ColumnDefinition col;
            RowDefinition row;

            for (int i = 0; i < _room.RowNumber; i++)
            {
                row = new RowDefinition();
                row.Height = GridLength.Auto;
                mainGrid.RowDefinitions.Add(row);

            }

            for (int i = 0; i < _room.ColumnNumber; i++)
            {
                col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                mainGrid.ColumnDefinitions.Add(col);
            }
                    

            var iterator = _room.Spots.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (iterator.Current.IsAvailable != 2)
                {
                    spotButton = new SpotButton(iterator.Current);
                    spotButton.Command = SelectSpotCommand;
                    spotButton.CommandParameter = iterator.Current;
                    Grid.SetColumn(spotButton, iterator.Current.Column);
                    Grid.SetRow(spotButton, iterator.Current.Row);
                    mainGrid.Children.Add(spotButton);
                }
            }
            

            return mainGrid;
        }

        private void PreviousPage()
        {
            NavigationManager.NavigateTo(new MainPage());
        }

        private void Booking()
        {
            NavigationManager.NavigateTo(new BookingPage(_selectedSpots, _seance, _selectedHour));
        }
        private void Buying()
        {
            NavigationManager.NavigateTo(new BuyingPage(_selectedSpots, _seance, _selectedHour));
        }

        #endregion

        #region InitFakeRoom

        private Room fakeRoom()
        {
            int row = 5;
            int col = 5;
            Room newRoom;
            ObservableCollection<Spot> spots = new ObservableCollection<Spot>();

            #region initFakeSpots
            spots.Add(new Spot(1, 0, 0, 0));
            spots.Add(new Spot(2, 1, 0, 0));
            spots.Add(new Spot(0, 2, 0, 1));
            spots.Add(new Spot(2, 3, 0, 0));
            spots.Add(new Spot(2, 4, 0, 0));

            spots.Add(new Spot(2, 0, 1, 0));
            spots.Add(new Spot(0, 1, 1, 2));
            spots.Add(new Spot(0, 2, 1, 3));
            spots.Add(new Spot(0, 3, 1, 4));
            spots.Add(new Spot(2, 4, 1, 0));

            spots.Add(new Spot(0, 0, 2, 5));
            spots.Add(new Spot(0, 1, 2, 6));
            spots.Add(new Spot(1, 2, 2, 7));
            spots.Add(new Spot(0, 3, 2, 8));
            spots.Add(new Spot(0, 4, 2, 9));

            spots.Add(new Spot(2, 0, 3, 0));
            spots.Add(new Spot(0, 1, 3, 10));
            spots.Add(new Spot(0, 2, 3, 11));
            spots.Add(new Spot(0, 3, 3, 12));
            spots.Add(new Spot(2, 4, 3, 0));

            spots.Add(new Spot(2, 0, 4, 0));
            spots.Add(new Spot(2, 1, 4, 0));
            spots.Add(new Spot(0, 2, 4, 13));
            spots.Add(new Spot(2, 3, 4, 0));
            spots.Add(new Spot(2, 4, 4, 0));

            #endregion

            newRoom = new Room(1, spots, col, row);


            return newRoom;
        }

        #endregion

    }
}