using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client
{
    public class CustomPanel : Panel
    {

        [Browsable(true)]
        public Color BorderColor { get; set; } = Color.Black; // Цвет окантовки

        public int BorderSize { get; set; } = 2; // Толщина окантовки

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем окантовку
            using (var pen = new Pen(BorderColor, BorderSize))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
