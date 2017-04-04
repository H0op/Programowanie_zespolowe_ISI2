using PzProject.Model;
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

namespace PzProject.View
{
    /// <summary>
    /// Interaction logic for DescriptionPage.xaml
    /// </summary>
    public partial class DescriptionPage : Page
    {
        private readonly DescriptionPageViewModel _viewModel;

        public DescriptionPage(Movie film)
        {
            InitializeComponent();
            _viewModel = new DescriptionPageViewModel(new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "pack://application:,,,/Resources/movie_img/john_wick.jpg", 1, 32));
            this.DataContext = _viewModel;
        }
    }
}
