using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PzProject.Utility;

namespace PzProject.Model
{
    class Spot : BindableBase
    {
        private bool _isAvailable;
        private int _column;
        private int _row;

        public bool IsAvailable
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

        public Spot(bool isAvailable, int column, int row)
        {
            _isAvailable = isAvailable;
            _column = column;
            _row = row;
        }
    }
}
