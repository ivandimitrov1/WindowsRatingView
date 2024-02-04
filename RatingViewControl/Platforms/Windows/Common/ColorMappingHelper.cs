namespace RatingViewControl.PlatformImplementations
{
    public static class ColorMappingHelper
    {
        public static Windows.UI.Color? MapToWinColor(Color? color)
        {
            if (color != null)
            {
                color.ToRgba(out var r, out var g, out var b, out var a);
                var winColor = new Windows.UI.Color();
                winColor.A = a;
                winColor.R = r;
                winColor.G = g;
                winColor.B = b;
                return winColor;
            }

            return null;
        }
    }
}
