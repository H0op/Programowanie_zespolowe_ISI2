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
    public partial class DescriptionPage : Page
    {
        private readonly DescriptionPageViewModel _viewModel;

        public DescriptionPage(Seance seans)
        {
            InitializeComponent();
            _viewModel = new DescriptionPageViewModel(seans);
            this.DataContext = _viewModel;


            /*var wb = new WebBrowser();
            this.Content = wb;
            wb.NavigateToString(@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta http-equiv='Content-Type' content='text/html; charset=unicode' />
                    <meta http-equiv='X-UA-Compatible' content='IE=9' /> 
                    <title></title>
                </head>
                <body>
                    <div>
                         <video autoplay='autoplay' preload='metadata'>
                            <source src='http://html5demos.com/assets/dizzy.mp4' type='video/mp4' />
                        </video>
                    </div>
                </body>
                </html>");
                */
        }
    }
}
