using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Markup;
using System.Xml;

namespace PzProject.View
{
    /// <summary>
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        private RoomPageViewModel _viewModel;

        public RoomPage(RoomPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            CreateView(5, 5);
        }

        

        private void CreateView(int column, int row)
        {
            ObservableCollection<Spot> spots = new ObservableCollection<Spot>();
            List<SpotButton> spotButtons = new List<SpotButton>();

            #region initFakeButton

            for (int i = 1; i <= row; i++)
                for (int j = 1; j <= column; j++)
                    spots.Add(new Spot(false, j, i));

            #endregion

            var iterator = spots.GetEnumerator();
            while (iterator.MoveNext())
            {
                spotButtons.Add(new SpotButton(iterator.Current));
            }

            Grid grid = new Grid();

            for (int i = 1; i <= column; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int j = 1; j <= row; j++)
                grid.RowDefinitions.Add(new RowDefinition());

            foreach (SpotButton button in spotButtons)
            {
                Grid.SetColumn(button, button.Spot.Column);
                Grid.SetRow(button, button.Spot.Row);
                grid.Children.Add(button);
            }

            this.Content = grid;
        }

        class SpotButton : Button
        {
            private Spot _spot;

            public SpotButton(Spot spot)
            {
                this._spot = spot;
                this.Width = 50;
                this.Height = 50;
                this.Content = spot.Column + "\n" + spot.Row;
                this.Background = !spot.IsAvailable ? Brushes.Gray : Brushes.Red;
            }

            public Spot Spot
            {
                get { return _spot; }
                private set { _spot = value; }
            }
        }
    }
}
