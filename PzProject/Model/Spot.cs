using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    public class Spot : BindableBase
    {

        #region Fields
        private int _isAvailable;
        private int _column;
        private int _row;
        private int _spotNumber;
        #endregion

        #region Properties
        public int IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                SetProperty(ref _isAvailable, value);
                OnPropertyChanged("IsAvailable");
            }
        }
        public int Column
        {
            get { return _column; }
            set
            {
                SetProperty(ref _column, value);
                OnPropertyChanged("Column");
            }
        }
        public int Row
        {
            get { return _row; }
            set
            {
                SetProperty(ref _row, value);
                OnPropertyChanged("Row");
            }
        }

        public int SpotNumber
        {
            get { return _spotNumber; }
            set
            {
                SetProperty(ref _spotNumber, value);
                OnPropertyChanged("SpotNumber");
            }
        }


        #endregion

        #region Constructor
        public Spot(int isAvailable, int column, int row, int spotnumber)
        {
            _isAvailable = isAvailable;
            _column = column;
            _row = row;
            _spotNumber = spotnumber;
        }
        #endregion

    }
}
