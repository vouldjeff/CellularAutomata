using System.Drawing;
using System.Windows.Forms;
using CellularAutomata.Framework;

namespace CellularAutomata.Controls
{
    public partial class PatternsViewControl : UserControl
    {
        public PatternCollection Patterns
        {
            get; set;
        }

        public PatternsViewControl()
        {
            InitializeComponent();
        }

        public void LoadPatterns(PatternCollection patternCollection)
        {
            Patterns = patternCollection;

            //This should be a property
            int imageSize = 40;

            int max, ratio;
            Bitmap bitmap;
            Graphics graphics;
            foreach (Pattern pattern in Patterns)
            {
                max = 0;
                foreach (Cell cell in pattern.Cells)
                {
                    if (cell.Location.X > max) max = cell.Location.X;
                    if (cell.Location.Y > max) max = cell.Location.Y;
                }
                max++;
                ratio = imageSize / max;
                bitmap = new Bitmap(imageSize, imageSize);
                graphics = Graphics.FromImage(bitmap);

                foreach (Cell cell in pattern.Cells)
                {
                    graphics.FillRectangle(Brushes.Black, cell.Location.X * ratio, cell.Location.Y * ratio, ratio, ratio);
                }
                graphics.DrawImageUnscaled(bitmap, 0, 0);
                patternsImages.Images.Add(bitmap);
            }


            patternsView.LargeImageList = patternsImages;
            patternsView.LargeImageList.ImageSize = new Size(imageSize, imageSize);
            patternsView.View = View.LargeIcon;

            for (int i = 0; i < patternsImages.Images.Count; i++)
            {
                patternsView.Items.Add(Patterns[i].Name, i);
                patternsView.Items[i].ToolTipText = Patterns[i].Description;
                patternsView.Items[i].Tag = i;
            }
        }

        private void patternsView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var info = patternsView.HitTest(e.Location);
                if (info.Item != null)
                {
                    patternsView.DoDragDrop(Patterns[(int) info.Item.Tag], DragDropEffects.Move);
                }
            }
        }
    }
}
