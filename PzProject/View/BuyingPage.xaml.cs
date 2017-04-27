using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PzProject.Model;
using PzProject.ViewModel;

namespace PzProject.View
{
    /// <summary>
    /// Interaction logic for BuyingPage.xaml
    /// </summary>
    public partial class BuyingPage : Page
    {
        private BuyingPageViewModel _viewModel;

        public BuyingPage(List<Spot> selectedSpots, Seance seance, string selectedHour)
        {
            InitializeComponent();
            _viewModel = new BuyingPageViewModel(selectedSpots, seance, selectedHour);
            this.DataContext = _viewModel;
        }
    }
}
