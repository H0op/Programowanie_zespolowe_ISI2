using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    public class Seance : BindableBase
    {
        #region Fields

        private int _seansID;
        private Movie _movie;
        private ObservableCollection<Room> _rooms;
        private ObservableCollection<string> _seanceHours;
        private DateTime _startDate;
        private DateTime _endDate;
        #endregion

        #region Properties

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                SetProperty(ref _movie, value);
                OnPropertyChanged("Movie");
            }
        }

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }

        public ObservableCollection<string> SeanceHours
        {
            get { return _seanceHours; }
            set { SetProperty(ref _seanceHours, value); }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                SetProperty(ref _startDate, value); 
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                SetProperty(ref _endDate, value);
                OnPropertyChanged("EndDate");
            }
        }

        public int SeansID
        {
            get { return _seansID; }
            set
            {
                SetProperty(ref _seansID, value);
                OnPropertyChanged("SeansID");
            }

        }
        #endregion

        #region Constructor
        public Seance(Movie movie, ObservableCollection<Room> rooms, ObservableCollection<string> seanceHours, DateTime startDate, DateTime endDate, int id)
        {
            _movie = movie;
            _rooms = rooms;
            _seanceHours = seanceHours;
            _startDate = startDate;
            _endDate = endDate;
            _seansID = id;
        }
        #endregion

    }
}
