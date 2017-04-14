using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    public class Room : BindableBase
    {
        #region Fields
        private int _roomNumber;
        private int _rowNumber;
        private int _columnNumber;
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
        public int RowNumber
        {
            get { return _rowNumber; }
            set
            {
                SetProperty(ref _rowNumber, value);
                OnPropertyChanged("RowNumber");
            }
        }
        public int ColumnNumber
        {
            get { return _columnNumber; }
            set
            {
                SetProperty(ref _columnNumber, value);
                OnPropertyChanged("ColumnNumber");
            }
        }


        public ObservableCollection<Spot> Spots
        {
            get { return _spots; }
            set { SetProperty(ref _spots, value); }
        }


        #endregion

        #region Constructor
        public Room(int roomNumber, ObservableCollection<Spot> spots, int column, int row)
        {
            _roomNumber = roomNumber;
            _spots = spots;
            _columnNumber = column;
            _rowNumber = row;
        }

        #endregion

    }
}
