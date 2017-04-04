using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PzProject.Model;
using PzProject.Utility;

namespace PzProject.ViewModel
{
    public class RoomPageViewModel : BindableBase
    {

        public RoomPageViewModel(ContentPresenter salaContent)
        {
            salaContent.Content = CreateView(10, 5);
        }


        private Grid CreateView(int column, int row)
        {
            var spots = new ObservableCollection<Spot>();
            var spotButtons = new List<SpotButton>();
            var mainGrid = new Grid();
            var inGrid = new Grid();
            var col = new ColumnDefinition();
            RowDefinition rowDefinition;

            InitFakeButton(column, row, spots);
            col.Width = new GridLength(1, GridUnitType.Star);
         

            mainGrid.ColumnDefinitions.Add(col);
            mainGrid.Margin = new Thickness(-60, 0, 0, 0);
            Grid.SetColumn(inGrid, 0);
            mainGrid.Children.Add(inGrid);

            var iterator = spots.GetEnumerator();
            while (iterator.MoveNext())
            {
                spotButtons.Add(new SpotButton(iterator.Current));
            }


            for (int i = 0; i <= column; i++)
            {
                col = new ColumnDefinition();
                col.Width = new GridLength(60);
                inGrid.ColumnDefinitions.Add(col);
            }


            for (int j = 0; j <= row; j++)
            {
                rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(60);
                inGrid.RowDefinitions.Add(rowDefinition);
            }
               

            foreach (SpotButton button in spotButtons)
            {
                Grid.SetColumn(button, button.Spot.Column);
                Grid.SetRow(button, button.Spot.Row);
                inGrid.Children.Add(button);
            }

            return mainGrid;
        }


        #region initFakeButton
        private void InitFakeButton(int column, int row, ObservableCollection<Spot> spots)
        {
            for (int i = 1; i <= row; i++)
            for (int j = 1; j <= column; j++)
                spots.Add(new Spot(false, j, i));
        }

        #endregion
    }

}
