using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyToolkit.Collections;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    class UserPageViewModel:BindableBase
    {

        #region Fields/Commands
        public ICommand PreviousPageCommand { set; get; }

        private ObservableCollection<string> _bookingList;
        private ObservableCollectionView<string> _filteredBookList;
        private string _search;


        #endregion

        #region Properties

        public ObservableCollectionView<string> FilteredBookList
        {
            get { return _filteredBookList; }
            set { SetProperty(ref _filteredBookList, value); }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                SetProperty(ref _search, value);
                OnPropertyChanged("Search");
                _filteredBookList.Filter = s => s.ToLowerInvariant().Contains(value.ToLowerInvariant());
            }
        }

        #endregion

        #region Constructor

        public UserPageViewModel()
        {
            PreviousPageCommand = new RelayCommand(action => {NavigationManager.BackToMain();});
            FakeBooking();
        }

        #endregion

        #region Methods
        

        #endregion

        #region FakeBooking

        private void FakeBooking()
        {
            _bookingList = new ObservableCollection<string>();
            _bookingList.Add("Rezerwacja 1");
            _bookingList.Add("Rezerwacja 2");
            _bookingList.Add("Rezerwacja 3");
            _bookingList.Add("Rezerwacja 4");
            _bookingList.Add("Rezerwacja 5");
            _bookingList.Add("Rezerwacja 6");
            _filteredBookList = new ObservableCollectionView<string>(_bookingList);
        }

        #endregion

    }
}
