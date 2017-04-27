using PzProject.Model;
using PzProject.Utility;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PzProject.View
{
    public class DescriptionPageViewModel : BindableBase
    {
        private Seance seans;
        private StackPanel _morning;
        private StackPanel _afternoon;
        private StackPanel _evening;

        public ICommand PowrotCommand { get; set; }
        public ICommand NextPageCommand { get; set; }


        public DescriptionPageViewModel(Seance seans)
        {
            NextPageCommand = new RelayCommand(action => NextPage(action));
            PowrotCommand = new RelayCommand(action => Powrot());
            this.seans = seans;
            _morning = new StackPanel();
            _afternoon = new StackPanel();
            _evening = new StackPanel();
            CreateSeanceButton();



        }

        private void NextPage(object hour)
        {
            NavigationManager.NavigateTo(new RoomPage(Seans, hour.ToString()));
        }

        private void Powrot()
        {
            NavigationManager.NavigateTo(new MainPage());
        }

        public Seance Seans
        {
            get
            {
                return seans;
            }

            set
            {
                SetProperty(ref seans, value);
                OnPropertyChanged("Seans");
            }
        }

   

        public StackPanel Morning
        {
            get { return _morning; }
            set
            {
                SetProperty(ref _morning, value);
                OnPropertyChanged("Morning");
            }
        }

        public StackPanel Afternoon
        {
            get { return _afternoon; }
            set
            {
                SetProperty(ref _afternoon, value);
                OnPropertyChanged("Afternoon");
            }
        }

        public StackPanel Evening
        {
            get { return _evening; }
            set
            {
                SetProperty(ref _evening, value);
                OnPropertyChanged("Evening");
            }
        }

        private void CreateSeanceButton()
        {
            _morning.Children.RemoveRange(0, _morning.Children.Count);
            _afternoon.Children.RemoveRange(0, _afternoon.Children.Count);
            _evening.Children.RemoveRange(0, _evening.Children.Count);
            foreach (var hour in seans.SeanceHours)
            {
                if (Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 12) _morning.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour });
                else if (Int32.Parse(hour.Remove(hour.IndexOf(':'))) <= 18) _afternoon.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour });
                else _evening.Children.Add(new Button { Content = hour, Command = NextPageCommand, Width = 150, CommandParameter = hour });
            }
        }
    }
}