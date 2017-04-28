using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PzProject.Utility;
using PzProject.View;

namespace PzProject.ViewModel
{
    public class LoginPageViewModel : BindableBase
    {
        #region Fields/Commands

        private string _login;
        private string _wrongData;

        public ICommand PreviousPageCommand { set; get; }
        public ICommand LoginCommand { set; get; }

        #endregion

        #region Properties

        public string WrongData
        {
            get { return _wrongData; }
            set
            {
                SetProperty(ref _wrongData, value);
                OnPropertyChanged("WrongData");
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);
                OnPropertyChanged("Login");
            }
        }

        #endregion

        #region Constructor

        public LoginPageViewModel()
        {
            PreviousPageCommand = new RelayCommand(action => { NavigationManager.Back(); });
            LoginCommand = new RelayCommand(action => LoginUser(Login, (PasswordBox)action));
        }

        #endregion

        #region Methods

        private void LoginUser(string log, PasswordBox pass)
        {
            //sprawdzanie z baza poprawnosci hasla
            //if (ldb.Login(log, pass.Password))
            if(pass.Password == "")
            {
                WrongData = string.Empty;
                NavigationManager.NavigateTo(new UserPage());
            }
            else WrongData = "Bledne dane";
        }

        #endregion


    }
}
