using MahApps.Metro.Controls;
using PzProject.Utility;
using PzProject.View;

namespace PzProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
