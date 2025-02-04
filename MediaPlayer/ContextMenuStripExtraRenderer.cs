using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MediaPlayer
{
    internal class ContextMenuStripExtraRenderer : ToolStripProfessionalRenderer
    {
        //protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) 
        //{
        //    //base.OnRenderButtonBackground(e);
        //}
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) //полоска на левом краю
        {
            // base.OnRenderToolStripBackground(e);
            using (Pen p = new Pen(Color.Blue))
            {
                e.Graphics.DrawEllipse(p, e.ToolStrip.ClientRectangle);
            }
            using (Brush backgroundBrush = new LinearGradientBrush(
                       e.ToolStrip.ClientRectangle,
                       SystemColors.ControlLightLight,
                       SystemColors.ControlDark,
                       90,
                       true))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.AffectedBounds);
            }
        }

        //protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        //{
        //    //base.OnRenderToolStripContentPanelBackground(e);
        //}
        //protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        //{
        //    //base.OnRenderItemBackground(e);
        //}
        //protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        //{
        //    //base.OnRenderLabelBackground(e);
        //}
        //protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        //{
        //    //base.OnRenderItemImage(e);
        //}
        //protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        //{
        //    //base.OnRenderStatusStripSizingGrip(e);
        //}

        //protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        //{
        //   // base.OnRenderToolStripPanelBackground(e);
        //}


        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) //работает
        {
            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(ProfessionalColors.GripDark))
                {
                    e.Graphics.FillRectangle(b, 2, 0, 22, 20);
                }
            }
            //else
            //{
            //    using (Pen p = new Pen(ProfessionalColors.GripDark))
            //    {
            //        e.Graphics.DrawRectangle(p, 2, 0, 20, 20);
            //    }
            //}
        }
    }
}