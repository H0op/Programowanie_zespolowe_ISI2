using PzProject.Model;
using PzProject.Utility;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PzProject.View
{
    public class DescriptionPageViewModel : BindableBase
    {
        private Movie film;

        public DescriptionPageViewModel(Movie film)
        {
            this.Film = film;
        }
        
        public Movie Film
        {
            get
            {
                return film;
            }

            set
            {
                SetProperty(ref film, value);
                OnPropertyChanged("Film");
            }
        }
    }
}