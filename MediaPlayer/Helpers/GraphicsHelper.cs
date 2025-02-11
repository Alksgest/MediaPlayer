#pragma warning disable CA1416

using System.Drawing;
using System.Drawing.Drawing2D;

namespace MediaPlayer.Helpers;

public static class GraphicsHelper
{
    public static GraphicsPath CreateRoundedBorders(int width, int height, int borderRadius = 20)
    {
        var bounds = new Rectangle(0, 0, width, height);
        return  GetRoundedRect(bounds, borderRadius);
    }

    private static GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
        var diameter = radius * 2;
        var path = new GraphicsPath();

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

        path.CloseFigure();
        
        return path;
    }
}