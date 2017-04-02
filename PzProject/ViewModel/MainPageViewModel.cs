﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using PzProject.Model;
using PzProject.Utility;

namespace PzProject.ViewModel
{
    class MainPageViewModel : BindableBase
    {
        // commands
        public ICommand HaloClick { get; set; }

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
            HaloClick = new RelayCommand(action => HeheHerabataCiStygnie(), () => CanDelete());
        }

        private void HeheHerabataCiStygnie()
        {
            int a = 1;
            int b = a + 1;
            MovieList.RemoveAt(1);
        }

        private bool CanDelete()
        {
            return MovieList.Count > 2;
        }

        private async void InitData()
        {
            await Task.Delay(300);
            MovieList.Insert(0, new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "pack://application:,,,/Resources/movie_img/john_wick.jpg", 1, 32));
            MovieList.Insert(1, new Movie("Rambo", "John Rambo, były komandos, naraża się policjantom z pewnego miasteczka.", "pack://application:,,,/Resources/movie_img/rambo.jpg", 1, 24));
            MovieList.Insert(2, new Movie("Kiler", "Jerzy Kiler, przypadkowo zostaje wzięty za płatnego zabójcę.", "pack://application:,,,/Resources/movie_img/kiler.jpg", 1, 43));
            MovieList.Insert(3, new Movie("Szklana pułapka", "Grupa terrorystów opanowuje korporacyjny wieżowiec.", "pack://application:,,,/Resources/movie_img/szklana_pulapka.jpg", 2, 14));
            MovieList.Insert(4, new Movie("Psy", "Franz Maurer, były funkcjonariusz Służby Bezpieczeństwa, zaczyna pracę w policji.", "pack://application:,,,/Resources/movie_img/psy.jpg", 2, 02));
        }
    }
}