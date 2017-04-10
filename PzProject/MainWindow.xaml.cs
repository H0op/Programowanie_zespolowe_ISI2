using MahApps.Metro.Controls;
using PzProject.Utility;
using PzProject.View;

namespace PzProject
{

    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationManager.Initialize(MainFrame);
            NavigationManager.NavigateTo(new MainPage());
        }
    }
}
