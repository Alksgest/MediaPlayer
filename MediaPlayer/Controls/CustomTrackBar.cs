#pragma warning disable CA1416

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MediaPlayer.Controls
{
    [ToolboxItem(true)]
    public class CustomTrackBar : TrackBar
    {
        private const int ThumbRadius = 5;
        private bool _isDragging;

        public CustomTrackBar()
        {
            TickStyle = TickStyle.None;

            SetStyle(ControlStyles.UserPaint 
                | ControlStyles.ResizeRedraw 
                | ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(BackColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Do not call base.OnPaint(e) so that the default painting is skipped.
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using var trackPen = new Pen(Color.Black, 3);
            float range = Maximum - Minimum;
            // Protect against division by zero:
            var percent = range > 0 ? (float)(Value - Minimum) / range : 0f;

            if (Orientation == Orientation.Horizontal)
            {
                // For horizontal orientation:
                var trackY = Height / 2;
                // Draw the track line from thumbRadius to Width - thumbRadius.
                e.Graphics.DrawLine(trackPen,
                    new Point(ThumbRadius, trackY),
                    new Point(Width - ThumbRadius, trackY));

                // Calculate the thumb’s X position within the available width.
                var availableWidth = Width - 2 * ThumbRadius;
                var thumbX = (int)(percent * availableWidth) + ThumbRadius;

                // Define the rectangle in which the thumb (a circle) is drawn.
                var thumbRect = new Rectangle(
                    thumbX - ThumbRadius,
                    trackY - ThumbRadius,
                    ThumbRadius * 2,
                    ThumbRadius * 2);

                using var thumbBrush = new SolidBrush(Color.Black);
                e.Graphics.FillEllipse(thumbBrush, thumbRect);
            }
            else // Vertical orientation
            {
                var trackX = Width / 2;
                e.Graphics.DrawLine(trackPen,
                    new Point(trackX, ThumbRadius),
                    new Point(trackX, Height - ThumbRadius));

                var availableHeight = Height - 2 * ThumbRadius;
                // var thumbY = (int)(percent * availableHeight) + ThumbRadius;
                var thumbY = Height - ThumbRadius - (int)(percent * availableHeight);

                var thumbRect = new Rectangle(
                    trackX - ThumbRadius,
                    thumbY - ThumbRadius,
                    ThumbRadius * 2,
                    ThumbRadius * 2);

                using var thumbBrush = new SolidBrush(Color.Black);
                e.Graphics.FillEllipse(thumbBrush, thumbRect);
            }
        }

        // Raise Invalidate on value changes.
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            Invalidate();
        }

        // Begin tracking when the user presses the mouse button.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                Capture = true;
                UpdateValueFromPosition(e.Location);
            }
        }

        // Update the value while dragging.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDragging)
            {
                UpdateValueFromPosition(e.Location);
            }
        }

        // End tracking when the user releases the mouse button.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
                Capture = false;
            }
        }

        // Helper method: convert a mouse coordinate into a new Value.
        private void UpdateValueFromPosition(Point p)
        {
            if (Orientation == Orientation.Horizontal)
            {
                var minX = ThumbRadius;
                var maxX = Width - ThumbRadius;
                var x = p.X;

                // Clamp the mouse position to the valid range.
                if (x < minX) x = minX;
                if (x > maxX) x = maxX;

                var percent = (float)(x - minX) / (maxX - minX);
                var newValue = Minimum + (int)(percent * (Maximum - Minimum));

                if (newValue != Value)
                {
                    Value = newValue;
                }
            }
            else // Vertical
            {
                var minY = ThumbRadius;
                var maxY = Height - ThumbRadius;
                var y = p.Y;

                if (y < minY) y = minY;
                if (y > maxY) y = maxY;

                var percent = (float)(y - minY) / (maxY - minY);
                var newValue = Minimum + (int)(percent * (Maximum - Minimum));

                if (newValue != Value)
                {
                    Value = newValue;
                }
            }
            
            OnScroll(EventArgs.Empty);
        }
    }
}