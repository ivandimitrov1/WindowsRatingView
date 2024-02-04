using System.Collections.ObjectModel;
using System.ComponentModel;
using RatingViewControl.Models;

namespace RatingViewControl.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    OnPropertyChanged(nameof(Movies));
                }
            }
        }

        public MainPageViewModel()
        {
            Movies = new ObservableCollection<Movie>
            {
                new Movie("The Shawshank Redemption", 0),
                new Movie("The Godfather", 0),
                new Movie("The Dark Knight", 0),
                new Movie("The Godfather Part II", 0),
                new Movie("12 Angry Men", 0),
                new Movie("Schindler's List", 0),
                new Movie("The Lord of the Rings: The Return of the King", 0),
                new Movie("Pulp Fiction", 0),
                new Movie("The Lord of the Rings: The Fellowship of the Ring", 0),
                new Movie("The Good, the Bad and the Ugly", 0),
                new Movie("Forest Gump", 0),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
