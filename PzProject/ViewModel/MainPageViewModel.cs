using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Utility;

namespace PzProject.ViewModel
{
    class MainPageViewModel : BindableBase
    {
        // commands
        public ICommand AddMovie { get; set; }

        private ObservableCollection<Movie> _movieList;

        public ObservableCollection<Movie> MovieList
        {
            get { return _movieList; }
            set { SetProperty(ref _movieList, value); }
        }

        public MainPageViewModel()
        {
            MovieList = new ObservableCollection<Movie>();
            InitData();
        }

        private async void InitData()
        {
            await Task.Delay(300);
            MovieList.Insert(0, new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "SRC", 1, 32));
            MovieList.Insert(1, new Movie("Rambo", "John Rambo, były komandos, naraża się policjantom z pewnego miasteczka.", "SRC", 1, 24));
            MovieList.Insert(2, new Movie("Kiler", "Jerzy Kiler, przypadkowo zostaje wzięty za płatnego zabójcę.", "SRC", 1, 43));
            MovieList.Insert(3, new Movie("Szklana pułapka", "Grupa terrorystów opanowuje korporacyjny wieżowiec.", "SRC", 2, 14));
            MovieList.Insert(4, new Movie("Psy", "Franz Maurer, były funkcjonariusz Służby Bezpieczeństwa, zaczyna pracę w policji.", "SRC", 2, 02));
        }
    }
}
