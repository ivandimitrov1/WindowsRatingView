namespace RatingViewControl.Controls
{
    public interface IRatingView : IView
    {
        public Color? Color { get; set; }
        public int Value { get; set; }
    }
}
