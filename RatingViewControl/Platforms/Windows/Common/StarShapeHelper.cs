using Microsoft.UI.Xaml.Shapes;

namespace RatingViewControl.PlatformImplementations
{
    public static class StarShapeHelper
    {
        public static int Default_Star_Radius = 10;
        public static int Default_Star_Margin = 10;

        public static Polygon GetStarShape(
            int startId,
            bool fill,
            Windows.UI.Color? fillColor = null)
        {
            var color = fillColor ?? new Windows.UI.Color { A = 250, R = 229, G = 245, B = 39 };
            var strokeColor = new Windows.UI.Color { A = 140, R = 0, G = 0, B = 0 };
            var strokeSolidBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(strokeColor);
            var fillSolidBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(color);
            Polygon starPolygon = new Polygon
            {
                Stroke = strokeSolidBrush,
                StrokeThickness = 3
            };

            var fillBrush = fill ? fillSolidBrush : strokeSolidBrush;
            starPolygon.Fill = fillBrush;

            int starCenter = (Default_Star_Radius * 2) + Default_Star_Margin;
            starPolygon.Points = GetStarPoints(Default_Star_Radius, new Windows.Foundation.Point(starCenter * startId, 20), 5);
            return starPolygon;
        }

        private static Microsoft.UI.Xaml.Media.PointCollection GetStarPoints(float radius, Windows.Foundation.Point center, int points)
        {
            Microsoft.UI.Xaml.Media.PointCollection pts = new Microsoft.UI.Xaml.Media.PointCollection();
            double angle = Math.PI / points;

            for (int i = 0; i < 2 * points; i++)
            {
                double r = radius * (i % 2 + 1) / 2.0;
                double theta = i * angle;

                var x = center.X + (float)(r * Math.Cos(theta));
                var y = center.Y - (float)(r * Math.Sin(theta));

                pts.Add(new Windows.Foundation.Point(x, y));
            }

            return pts;
        }
    }
}
