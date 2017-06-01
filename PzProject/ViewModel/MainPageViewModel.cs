using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Network;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    class MainPageViewModel : BindableBase
    {
        #region Fields/Commands

        public ICommand NextPageCommand { get; set; }
        public ICommand MoreInfoCommand { get; set; }  
        public ICommand LoginCommand { get; set; }

        private ObservableCollection<Seance> _seances;
        private string[] _dataTime;
        private Seance _selectedSeance;
        private string _selectedHour;

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
            NextPageCommand = new RelayCommand(action => NextPage( action ));
            MoreInfoCommand = new RelayCommand(action => MoreInfoPage(), ()=>_selectedSeance!=null);
            LoginCommand = new RelayCommand(action => Login());


            Seances = new ObservableCollection<Seance>();
            _morning = new StackPanel();
            _afternoon = new StackPanel();
            _evening = new StackPanel();

            InitDataTime();
            InitData();

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
                if (Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 12) _morning.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour});
                    else if(Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 18) _afternoon.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour });
                        else _evening.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour });
            }
        }

        private void NextPage(object hour)
        {
            NavigationManager.NavigateTo(new RoomPage(_selectedSeance, hour.ToString()));
        }

        private void Login()
        {
            NavigationManager.NavigateTo(new LoginPage());
        }

        private void MoreInfoPage()
        {
            NavigationManager.NavigateTo(new DescriptionPage(_selectedSeance));
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
            DatabasePZEntities context = new DatabasePZEntities();

            var api = new ApiRequester();
            Movie movie;
            foreach (var seans in context.SEANS)
            {
                movie = api.getAppMovie((int)seans.Id_film);
                var hours = new ObservableCollection<string>();
                var rooms = new ObservableCollection<Room>();
                string spotTable;
                int currentSpotNumber;

                foreach (var godziny in context.GODZINY.Where(id => id.Id_Seansu == seans.Id_seans))
                {
                    hours.Add(godziny.Godzina);
                    var spots = new ObservableCollection<Spot>();
                    SALA room = godziny.SEANS.SALA;
                    spotTable = godziny.Miejsca;

                    for (int i = 0; i < room.Ilosc_wierszy; i++)
                    {
                        for (int j = 0; j < room.Ilosc_kolumn; j++)
                        {
                            currentSpotNumber = (i * (int)room.Ilosc_kolumn) + j;
                            int isAvailable = Int32.Parse(spotTable[currentSpotNumber].ToString());
                            spots.Add(new Spot(isAvailable, j, i, currentSpotNumber+1));
                        }
                    }
                    
                    rooms.Add(new Room(room.Id_sala, spots, (int)room.Ilosc_kolumn, (int)room.Ilosc_wierszy));

                }

                Seances.Add(new Seance(movie, rooms, hours, (DateTime)seans.Data_rozpoczecia, (DateTime)seans.Data_zakonczenia, seans.Id_seans));
            }
        }

        private async Task Load()
        {
            await Task.Run(() => { InitData(); });
        }

        #endregion

    }
}
