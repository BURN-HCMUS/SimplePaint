using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using System.IO;

namespace Simple_paint
{

    enum DrawType { nothing, pencil, brush, line, ellipse, rectangle, triangle, arrow, heart,  erase, text}

    class Layer
    {
        public Canvas canvas;
        public DrawType drawType;
        public Layer(Canvas c)
        {
            drawType = DrawType.nothing;
            canvas = c;
        }
        private ImageSource BitmapToImageSource(Bitmap bm)
        {
            System.Windows.Media.Imaging.BitmapSource b = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(bm.Width, bm.Height));
            return b;
        }
        public Bitmap CanvasToBitmap(Canvas cv)
        {
            Bitmap bm;
            Rect bounds = VisualTreeHelper.GetDescendantBounds(cv);
            double dpi = 96d;
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);


            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(cv);
                dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), bounds.Size));
            }
            renderBitmap.Render(dv);

            MemoryStream stream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            encoder.Save(stream);
            bm = new System.Drawing.Bitmap(stream);
            return bm;
        }
        public void DrawShape(ContentControl control)
        {
            canvas.Children.RemoveAt(canvas.Children.Count - 1);
            RefreshCanvas();
            canvas.Children.Add(control);
        }
        public void DrawShape(System.Windows.Shapes.Shape shape)
        {
            RefreshCanvas();
            canvas.Children.Add(shape);
        }

        public void DrawCapture(Shape shape) //Vẽ hình được kéo ra lúc chưa nhả chuột
        {
            double[] dashes = { 2, 2 };
            shape.StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);

            canvas.Children.Add(shape);
        }
        public void RefreshCanvas()
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Width = canvas.ActualWidth;
            img.Height = canvas.ActualHeight;
            img.Source = BitmapToImageSource(CanvasToBitmap(canvas));
            canvas.Children.Clear();
            canvas.Children.Add(img);
        }
    }
}
