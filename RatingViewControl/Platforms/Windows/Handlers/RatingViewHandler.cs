using RatingViewControl.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace RatingViewControl.PlatformImplementations
{
    public partial class RatingViewHandler : ViewHandler<IRatingView, Canvas>
    {
        private static int Star_Count = 5;
        public static PropertyMapper<IRatingView, RatingViewHandler> CustomEntryMapper
                = new PropertyMapper<IRatingView, RatingViewHandler>(ViewMapper)
                {
                    [nameof(IRatingView.Color)] = MapColor,
                    [nameof(IRatingView.Value)] = MapValue,
                };
        public RatingViewHandler() : base(CustomEntryMapper)
        {
        }

        protected override Canvas CreatePlatformView()
        {
            var canvas = new Canvas();
            canvas.Tapped += Tapped;
            return canvas;
        }

        private void Tapped(object sender, TappedRoutedEventArgs e)
        {
            var canvas = sender as Canvas;
            var selectedStarId = GetSelectedStarId(canvas, e);
            DrawRatingStars(
                canvas,
                selectedStarId,
                ColorMappingHelper.MapToWinColor(VirtualView.Color));
        }

        private int GetSelectedStarId(Canvas canvas, TappedRoutedEventArgs e)
        {
            var position = e.GetPosition(canvas);
            var starLength = StarShapeHelper.Default_Star_Radius * 2;
            var length = Star_Count * starLength + (Star_Count * StarShapeHelper.Default_Star_Margin) + StarShapeHelper.Default_Star_Margin * 2;
            var percentage = (position.X / length) * 100;

            // TO:DO 
            // make it dynamic
            return percentage switch
            {
                > 85 => 5,
                > 65 => 4,
                > 45 => 3,
                > 25 => 2,
                > 15 => 1,
                _ => 0,
            };
        }

        private static void DrawRatingStars(
            Canvas canvas,
            int selectedStarId = 0,
            Windows.UI.Color? fillColor = null)
        {
            canvas.Children.Clear();
            for (int starId = 1; starId <= Star_Count; starId++)
            {
                bool fillStar = starId <= selectedStarId;
                var star = StarShapeHelper.GetStarShape(starId, fillStar, fillColor);
                canvas.Children.Add(star);
            }
        }

        static void MapColor(RatingViewHandler handler, IRatingView entry)
        {
            DrawRatingStars(
                handler.PlatformView,
                entry.Value,
                ColorMappingHelper.MapToWinColor(entry.Color));
        }

        static void MapValue(RatingViewHandler handler, IRatingView entry)
        {
            DrawRatingStars(
                handler.PlatformView,
                entry.Value,
                ColorMappingHelper.MapToWinColor(entry.Color));
        }
    }
}
