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
            this.Content = spot.Column + "\n" + spot.Row;
            this.Background = !spot.IsAvailable ? Brushes.Gray : Brushes.Red;
        }
        #endregion



    }
}