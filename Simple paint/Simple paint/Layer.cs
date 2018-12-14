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
using System.Windows.Forms;

namespace Simple_paint
{

    enum DrawType { nothing, pencil, brush, line, ellipse, rectangle, triangle, arrow, heart,  erase, text}

    class Layer
    {
        public Stack<UIElement> undoStack = new Stack<UIElement>();
        public Stack<UIElement> redoStack = new Stack<UIElement>();
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
           // RefreshCanvas();
            canvas.Children.Add(control);
        }
        public void DrawShape(System.Windows.Shapes.Shape shape)
        {
           // RefreshCanvas();
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
        private string CreateTempFile()
        {
            string fileName = string.Empty;

            try
            {
                fileName = System.IO.Path.GetTempFileName();

                // Create a FileInfo object to set the file's attributes
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);

                // Set the Attribute property of this file to Temporary. 
                fileInfo.Attributes = System.IO.FileAttributes.Temporary;

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Unable to create tempfile\nDetail: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return fileName;
        }
        public string openFile()
        {
            canvas.Children.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open";
            ofd.Filter = "Bitmap files (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|All files (*.*)|*.*";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImageBrush brush = new ImageBrush();
                    BitmapImage img = new BitmapImage(new Uri(ofd.FileName, UriKind.Relative));
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    string tempPath = CreateTempFile();
                    using (var stream = File.Open(tempPath, FileMode.Open))
                    {
                        encoder.Save(stream);
                        stream.Close();
                    }
                    BitmapImage temp = new BitmapImage(new Uri(tempPath, UriKind.Relative));
                    brush.ImageSource = temp;
                    canvas.Background = brush;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ofd.FileName + "\nSimple paint cannot read this file.\nThis is not a valid bitmap file, or its format is not currently supported.", "Simple paint", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return ofd.FileName;
        }
        public string SaveFile(string path)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(canvas);
            double dpi = 96d;


            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);


            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(canvas);
                dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), bounds.Size));
            }
            rtb.Render(dv);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);

                ms.Close();
                ms.Dispose();
                System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
                dlg.Title = "Save as";
                dlg.Filter = "Bitmap files (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|All files (*.*)|*.*";
                if (path == null)
                {
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        string fileName = dlg.FileName;
                        System.IO.File.WriteAllBytes(fileName, ms.ToArray());
                        return fileName;
                    }
                }
                else
                {
                    System.IO.File.WriteAllBytes(path, ms.ToArray());
                }

            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return path;

        }
    }
}
