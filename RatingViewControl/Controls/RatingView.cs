namespace RatingViewControl.Controls
{
    public class RatingView : View, IRatingView
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int), typeof(RatingView), 0, BindingMode.TwoWay);

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(RatingView), default(Color?), BindingMode.TwoWay);

        public Color? Color
        {
            get => (Color?)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
