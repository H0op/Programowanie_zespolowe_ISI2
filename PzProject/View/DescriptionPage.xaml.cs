using PzProject.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class DescriptionPage : Page
    {
        private readonly DescriptionPageViewModel _viewModel;

        public DescriptionPage(Seance seans)
        {
            InitializeComponent();
            _viewModel = new DescriptionPageViewModel(seans);
            this.DataContext = _viewModel;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}
