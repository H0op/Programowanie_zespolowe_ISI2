using MahApps.Metro.Controls;
using PzProject.Model;
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
            NavigationManager.NavigateTo(new DescriptionPage(new Movie("John Wick", "Były płatny morderca ściga gangsterów, którzy wtargnęli do jego domu.", "pack://application:,,,/Resources/movie_img/john_wick.jpg", 1, 32)));
        }
    }
}
