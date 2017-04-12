using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PzProject.Model;
using PzProject.Utility;

namespace PzProject.ViewModel
{
    public class RoomPageViewModel : BindableBase
    {
        #region Fields
        private Grid _grid;
        private Room _room;
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

        public Room Room1
        {
            get { return _room; }
            set { SetProperty(ref _room, value); }
        }

        #endregion

        private Seans _seans;

        #region Constructor

        public RoomPageViewModel(Seans newSeans)
        {
            _seans = newSeans;
            _room = _seans.Room;
            Grid = CreateView();
        }


        #endregion

        #region Methods

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
                    Grid.SetColumn(spotButton, iterator.Current.Column);
                    Grid.SetRow(spotButton, iterator.Current.Row);
                    mainGrid.Children.Add(spotButton);
                }
            }
            

            return mainGrid;
        }


        #endregion

        #region InitFakeRoom

        public static Room fakeRoom()
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