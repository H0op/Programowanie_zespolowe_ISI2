using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    public class Movie : BindableBase
    {
        #region Fields
        private string _name;
        private string _description;
        private string _imageSrc;
        private int _hours;
        private int _minutes;
        private string _releasDate;
        private string _productionCountries;
        private string _genres;
        private string _adult;
        private string _director;
        private string _cast;
        private string _screenPlay;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged("Description");
            }
        }

        public string ImageSrc
        {
            get { return _imageSrc; }
            set
            {
                SetProperty(ref _imageSrc, value);
                OnPropertyChanged("ImageSrc");
            }
        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                SetProperty(ref _hours, value);
                OnPropertyChanged("Length");
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                SetProperty(ref _minutes, value);
                OnPropertyChanged("Length");
            }
        }

        public string Length
        {
            get { return $"{(Hours*60) +Minutes}min"; }
        }

        public string ReleaseDate
        {
            get { return _releasDate; }
            set
            {
                SetProperty(ref _releasDate, value);
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string ProductionCountries
        {
            get { return _productionCountries; }
            set
            {
                SetProperty(ref _productionCountries, value);
                OnPropertyChanged("ProductionCountries");
            }
        }

        public string Genres
        {
            get { return _genres; }
            set
            {
                SetProperty(ref _genres, value);
                OnPropertyChanged("Genres");
            }
        }

        public string Adult
        {
            get { return _adult; }
            set
            {
                SetProperty(ref _adult, value);
                OnPropertyChanged("Adult");
            }
        }

        public string Director
        {
            get { return _director; }
            set
            {
                SetProperty(ref _director, value);
                OnPropertyChanged("Director");
            }
        }

        public string Cast
        {
            get { return _cast; }
            set
            {
                SetProperty(ref _cast, value);
                OnPropertyChanged("Cast");
            }
        }

        public string ScreenPlay
        {
            get { return _screenPlay; }
            set
            {
                SetProperty(ref _screenPlay, value);
                OnPropertyChanged("ScreenPlay");
            }
        }

   

        #endregion

        #region Constructor

        public Movie(string name, string description, string imageSrc, int hours, int minutes, string releaseData, string productionCountries, string Genres, string adult, string director, string cast, string sp)
        {
            _name = name;
            _description = description;
            _imageSrc = imageSrc;
            _hours = hours;
            _minutes = minutes;
            _releasDate = releaseData;
            _productionCountries = productionCountries;
            _genres = Genres;
            Adult = adult;
            _director = director;
            _cast = cast;
            _screenPlay = sp;
        }

        public Movie()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
