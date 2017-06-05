using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand RemoveCommand { set; get; }

        private ObservableCollection<BILET> _bookingList;
        private ObservableCollectionView<BILET> _filteredBookingList;
        private string _search;
        private DatabasePZEntities db;
        private BILET _selectedBooking;

        #endregion

        #region Properties

        public ObservableCollectionView<BILET> FilteredBookingList
        {
            get { return _filteredBookingList; }
            set
            {
                SetProperty(ref _filteredBookingList, value);
            }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                SetProperty(ref _search, value);
                OnPropertyChanged("Search");
                _filteredBookingList.Filter = s => s.Imie.ToLowerInvariant().Contains(value.ToLowerInvariant()) ||
                                                   s.Nazwisko.ToLowerInvariant().Contains(value.ToLowerInvariant()) ||
                                                   s.Email.ToLowerInvariant().Contains(value.ToLowerInvariant()) ||
                                                   s.Telefon.ToLowerInvariant().Contains(value.ToLowerInvariant());
            }
        }

        public BILET SelectedBooking
        {
            get { return _selectedBooking; }
            set
            {
                SetProperty(ref _selectedBooking, value);
                OnPropertyChanged("SelectedBookingIndex");
            }
        }
        #endregion

        #region Constructor

        public UserPageViewModel()
        {
            PreviousPageCommand = new RelayCommand(action =>
            {
                db.SaveChanges();
                NavigationManager.NavigateTo(new MainPage());
            });
            RemoveCommand = new RelayCommand(action =>
            {
                GODZINY godz = db.GODZINY.FirstOrDefault(n => n.Id_Godziny == SelectedBooking.Id_Godziny);
                char[] spots = godz.Miejsca.ToCharArray();
                spots[(int) SelectedBooking.Miejsce] = '0';
                godz.Miejsca = new string(spots);
                db.SaveChanges();
                db.BILET.Remove(SelectedBooking);
                _bookingList.Remove(SelectedBooking);
                _filteredBookingList.Refresh();
            });
            FakeBooking();
        }

        #endregion

        #region Methods


        #endregion

        #region FakeBooking

        private void FakeBooking()
        {
            _bookingList = new ObservableCollection<BILET>();
            db = new DatabasePZEntities();
                foreach (var bilet in db.BILET.Include("ULGA").Include("GODZINY"))
                {
                    _bookingList.Add(bilet);
                    
                }

            _filteredBookingList = new ObservableCollectionView<BILET>(_bookingList);
        }

        #endregion

    }
}