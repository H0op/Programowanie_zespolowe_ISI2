using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    class MainPageViewModel : BindableBase
    {
        #region Fields/Commands
        public ICommand NextPageCommand { get; set; }

        private ObservableCollection<Seance> _seances;
        private string[] _dataTime;
        private Seance _selectedSeance;

        private StackPanel _morning;
        private StackPanel _afternoon;
        private StackPanel _evening;

        #endregion

        #region Properties
        public string[] DataTime
        {
            get { return _dataTime; }
        }

        public Seance SelectedSeance
        {
            get { return _selectedSeance; }
            set
            {
                SetProperty(ref _selectedSeance, value);
                OnPropertyChanged("SelectedSeance");
                CreateSeanceButton();
            }
        }

        public ObservableCollection<Seance> Seances
        {
            get { return _seances; }
            set { SetProperty(ref _seances, value); }
        }

        public StackPanel Morning
        {
            get { return _morning; }
            set
            {
                SetProperty(ref _morning, value);
                OnPropertyChanged("Morning");
            }
        }

        public StackPanel Afternoon
        {
            get { return _afternoon; }
            set
            {
                SetProperty(ref _afternoon, value);
                OnPropertyChanged("Afternoon");
            }
        }

        public StackPanel Evening
        {
            get { return _evening; }
            set
            {
                SetProperty(ref _evening, value);
                OnPropertyChanged("Evening");
            }
        }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            NextPageCommand = new RelayCommand(action => NextPage());

            Seances = new ObservableCollection<Seance>();
            _morning = new StackPanel();
            _afternoon = new StackPanel();
            _evening = new StackPanel();

            InitData();
            InitDataTime();
        }

        #endregion

        #region Methods

        private void CreateSeanceButton()
        {
            _morning.Children.RemoveRange(0, _morning.Children.Count);
            _afternoon.Children.RemoveRange(0, _afternoon.Children.Count);
            _evening.Children.RemoveRange(0, _evening.Children.Count);
            foreach (var hour in _selectedSeance.SeanceHours)
            {
                if (Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 12) _morning.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150 });
                    else if(Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 18) _afternoon.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150 });
                        else _evening.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150 });
            }
        }


        private void NextPage()
        {
            NavigationManager.NavigateTo(new RoomPage(_selectedSeance));
        }

        #endregion

        #region InitData

        private void InitDataTime()
        {
            _dataTime = new string[7];
            for (int i = 0; i < 7 ; i++)
            {
                _dataTime[i] = System.DateTime.Now.AddDays(i).ToString(" dd\nMMM", new CultureInfo("en-US"));
            }
        }

        private void InitData()
        {
            Movie JohnWick = new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "pack://application:,,,/Resources/movie_img/john_wick.jpg", 1, 32, "7 Apr 2017");
            Movie Rambo = new Movie("Rambo", "John Rambo, były komandos, naraża się policjantom z pewnego miasteczka.", "pack://application:,,,/Resources/movie_img/rambo.jpg", 1, 24, "8 Apr 2017");
            Movie Kiler = new Movie("Kiler", "Jerzy Kiler, przypadkowo zostaje wzięty za płatnego zabójcę.","pack://application:,,,/Resources/movie_img/kiler.jpg", 1, 43, "9 Apr 2017");
            Movie SzklanaPulapka = new Movie("Szklana pułapka", "Grupa terrorystów opanowuje korporacyjny wieżowiec.", "pack://application:,,,/Resources/movie_img/szklana_pulapka.jpg", 2, 14, "10 Apr 2017");
            Movie Psy = new Movie("Psy", "Franz Maurer, były funkcjonariusz Służby Bezpieczeństwa, zaczyna pracę w policji.", "pack://application:,,,/Resources/movie_img/psy.jpg", 2, 02, "10 Apr 2017");


            ObservableCollection<Spot> spots = new ObservableCollection<Spot>()
            {
                new Spot(0, 0, 0, 1),
                new Spot(0, 1, 0, 2),
                new Spot(0, 2, 0, 3),
                new Spot(0, 3, 0, 4),
                new Spot(0, 4, 0, 5),
                new Spot(0, 5, 0, 6),
                new Spot(0, 6, 0, 7),
                new Spot(0, 7, 0, 8),
                new Spot(0, 8, 0, 9),
                new Spot(0, 9, 0, 10),

                new Spot(0, 0, 1, 11),
                new Spot(0, 1, 1, 12),
                new Spot(0, 2, 1, 13),
                new Spot(0, 3, 1, 14),
                new Spot(0, 4, 1, 15),
                new Spot(0, 5, 1, 16),
                new Spot(0, 6, 1, 17),
                new Spot(0, 7, 1, 18),
                new Spot(0, 8, 1, 19),
                new Spot(0, 9, 1, 20),

                new Spot(0, 0, 2, 21),
                new Spot(0, 1, 2, 22),
                new Spot(0, 2, 2, 23),
                new Spot(0, 3, 2, 24),
                new Spot(0, 4, 2, 25),
                new Spot(0, 5, 2, 26),
                new Spot(0, 6, 2, 27),
                new Spot(0, 7, 2, 28),
                new Spot(0, 8, 2, 29),
                new Spot(0, 9, 2, 30),

                new Spot(0, 0, 3, 31),
                new Spot(0, 1, 3, 32),
                new Spot(0, 2, 3, 33),
                new Spot(0, 3, 3, 34),
                new Spot(0, 4, 3, 35),
                new Spot(0, 5, 3, 36),
                new Spot(0, 6, 3, 37),
                new Spot(0, 7, 3, 38),
                new Spot(0, 8, 3, 39),
                new Spot(0, 9, 3, 40),

                new Spot(0, 0, 4, 41),
                new Spot(0, 1, 4, 42),
                new Spot(0, 2, 4, 43),
                new Spot(0, 3, 4, 44),
                new Spot(0, 4, 4, 45),
                new Spot(0, 5, 4, 46),
                new Spot(0, 6, 4, 47),
                new Spot(0, 7, 4, 48),
                new Spot(0, 8, 4, 49),
                new Spot(0, 9, 4, 50)
            };
            ObservableCollection<Room> rooms = new ObservableCollection<Room>()
            {
                new Room(1, spots, 10, 5),
                new Room(2, spots, 10, 5),
                new Room(3, spots, 10, 5),
                new Room(4, spots, 10, 5)
            };
            ObservableCollection<string> seanceHours = new ObservableCollection<string>()
            {
                "8:00",
                "12:00",
                "16:00",
                "20:00"
            };
            ObservableCollection<string> seanceHours2 = new ObservableCollection<string>()
            {
                "8:00",
                "12:00"
            };

            Seances.Add(new Seance(JohnWick, rooms, seanceHours, new DateTime(2017, 4, 14), new DateTime(2017, 4, 16) ));
            Seances.Add(new Seance(Rambo, rooms, seanceHours, new DateTime(2017, 4, 14), new DateTime(2017, 4, 16) ));
            Seances.Add(new Seance(Kiler, rooms, seanceHours2, new DateTime(2017, 4, 14), new DateTime(2017, 4, 16) ));
            Seances.Add(new Seance(SzklanaPulapka, rooms, seanceHours, new DateTime(2017, 4, 14), new DateTime(2017, 4, 16) ));
            Seances.Add(new Seance(Psy, rooms, seanceHours2, new DateTime(2017, 4, 14), new DateTime(2017, 4, 16) ));
        }
        #endregion

    }
}
