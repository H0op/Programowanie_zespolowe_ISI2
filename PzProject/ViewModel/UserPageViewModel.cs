using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyToolkit.Collections;
using PzProject.Model;
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
            using (DatabasePZEntities db = new DatabasePZEntities())
            {
                foreach (var bilet in db.BILET)
                {
                    string rezerwacja = bilet.Imie + " " + bilet.Nazwisko + " " + bilet.Email + " " + bilet.Telefon + " " + bilet.GODZINY.SEANS.Id_film + " " + bilet.GODZINY.Godzina;
                    _bookingList.Add(rezerwacja);
                }
            }
            _filteredBookList = new ObservableCollectionView<string>(_bookingList);
        }

        #endregion

    }
}