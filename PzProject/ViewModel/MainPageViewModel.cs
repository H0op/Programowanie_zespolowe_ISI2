using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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
        private ObservableCollection<Movie> _movieList;
        private string[] _dataTime;
        private Movie _selectedMovie;

        #endregion

        #region Properties
        public ObservableCollection<Movie> MovieList
        {
            get { return _movieList; }
            set { SetProperty(ref _movieList, value); }
        }

        public string[] DataTime
        {
            get { return _dataTime; }
        }

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                SetProperty(ref _selectedMovie, value);
                OnPropertyChanged("SelectedMovie");
            }
        }
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            MovieList = new ObservableCollection<Movie>();
            InitData();
            InitDataTime();
            NextPageCommand = new RelayCommand(action => NextPage());
        }

        #endregion

        #region Methods

        private void NextPage()
        {
            MessageBox.Show(SelectedMovie.Name);
            //NavigationManager.NavigateTo(new RoomPage());
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
            MovieList.Insert(0, new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "pack://application:,,,/Resources/movie_img/john_wick.jpg", 1, 32, "7 Apr 2017"));
            MovieList.Insert(1, new Movie("Rambo", "John Rambo, były komandos, naraża się policjantom z pewnego miasteczka.", "pack://application:,,,/Resources/movie_img/rambo.jpg", 1, 24, "8 Apr 2017"));
            MovieList.Insert(2, new Movie("Kiler", "Jerzy Kiler, przypadkowo zostaje wzięty za płatnego zabójcę.", "pack://application:,,,/Resources/movie_img/kiler.jpg", 1, 43, "9 Apr 2017"));
            MovieList.Insert(3, new Movie("Szklana pułapka", "Grupa terrorystów opanowuje korporacyjny wieżowiec.", "pack://application:,,,/Resources/movie_img/szklana_pulapka.jpg", 2, 14, "10 Apr 2017"));
            MovieList.Insert(4, new Movie("Psy", "Franz Maurer, były funkcjonariusz Służby Bezpieczeństwa, zaczyna pracę w policji.", "pack://application:,,,/Resources/movie_img/psy.jpg", 2, 02, "10 Apr 2017"));
        }
        #endregion

    }
}
