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

        #endregion

        #region Constructor

        public Movie(string name, string description, string imageSrc, int hours, int minutes, string releaseData)
        {
            _name = name;
            _description = description;
            _imageSrc = imageSrc;
            _hours = hours;
            _minutes = minutes;
            _releasDate = releaseData;
        }

        public Movie()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
