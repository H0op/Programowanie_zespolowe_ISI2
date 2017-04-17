using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PzProject.Model;

namespace PzProject.ViewModel
{
    class SpotButton : Button
    {

        #region Fields

        private Spot _spot;

        #endregion

        #region Properties
        public Spot Spot
        {
            get { return _spot; }
            private set { _spot = value; }
        }
        #endregion

        #region Constructor
        public SpotButton(Spot spot)
        {
            this._spot = spot;
            this.Width = 50;
            this.Height = 50;
            this.Margin = new Thickness(2);
            this.Content = spot.SpotNumber;
            this.Focusable = false;
            if (spot.IsAvailable == 0) this.Background = Brushes.Gray;
                else if (spot.IsAvailable == 1)
            {
                this.IsEnabled = false;
            }
        }
        #endregion



    }
}