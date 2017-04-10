using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    class Room : BindableBase
    {
        #region Fields
        private int _roomNumber;
        private ObservableCollection<Spot> _spots;
        #endregion

        #region Properties

        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                SetProperty(ref _roomNumber, value);
                OnPropertyChanged("RoomNumber");
            }
        }
        public ObservableCollection<Spot> Spots
        {
            get { return _spots; }
            set { SetProperty(ref _spots, value); }
        }


        #endregion

        #region Constructor
        public Room(int roomNumber, ObservableCollection<Spot> spots)
        {
            _roomNumber = roomNumber;
            _spots = spots;
        }

        #endregion

    }
}
