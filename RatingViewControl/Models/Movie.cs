namespace RatingViewControl.Models
{
    public class Movie
    {
        public Movie(string title, int rating)
        {
            Title = title;
            Rating = rating;
        }

        public string Title { get; set; }
        public int Rating { get; set; }
    }
}
