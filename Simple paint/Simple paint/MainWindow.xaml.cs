using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;

namespace Simple_paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Layer screen;
        private Point mDown, mMove;
        private bool capture;
        private ContentControl curControl;
        private System.Windows.Shapes.Shape curShape;
        private Line curLine;
        private Color penColor;
        private double penThickness;
        private PathGeometry pathGeometry;
        private Path path;
        private PathFigure pathFigure;
        private string curFilePath;
        private ContentControl selectedControl;
        private TextBox focusedTextbox;
        //text
        private FontFamily fontFamily;
        private double fontSize;
        private FontStyle fontStyle;
        private FontWeight fontWeight;
        private TextDecorationCollection decoration;
        private Color fontColor;
        bool bold = false, italic = false, underlined = false;
        float oldLineCount;

        public MainWindow()
        {
            InitializeComponent();
            screen = new Layer(paintCanvas);
            capture = false;
            penColor = Colors.Black;
            penThickness = 1;
        }
        private void SimplePaint_Loaded(object sender, RoutedEventArgs e)
        {
            fontSize = 8;
            fontColor = Colors.Black;
            fontStyle = FontStyles.Normal;
            fontWeight = FontWeights.Normal;
            decoration = null;

        }
        #region Pencil and Brush
        private void btnPencil_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.pencil;
            paintCanvas.Cursor = Cursors.Pen;
        }

        private void btnBrush_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.brush;
            penThickness = 3;
            paintCanvas.Cursor = Cursors.Pen;
        }
        #endregion
        #region Draw simple picture
        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.line;
            paintCanvas.Cursor = Cursors.Cross;
            
        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.ellipse;
            paintCanvas.Cursor = Cursors.Cross;

        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.rectangle;
            paintCanvas.Cursor = Cursors.Cross;
        }
        private void btnErazer_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.erase;
            paintCanvas.Cursor = Cursors.Arrow;
        }
        private void btnTriangle_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.triangle;
            paintCanvas.Cursor = Cursors.Cross;
        }

        private void btnArrow_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.arrow;
            paintCanvas.Cursor = Cursors.Cross;
        }

        private void btnHeart_Click(object sender, RoutedEventArgs e)
        {
            screen.drawType = DrawType.heart;
            paintCanvas.Cursor = Cursors.Cross;
        }
        #endregion
        #region MouseDown
        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            mDown = e.GetPosition(this.paintCanvas);
            capture = true;
            if (screen.drawType == DrawType.brush || screen.drawType == DrawType.pencil || screen.drawType == DrawType.erase)
            {
                pathGeometry = new PathGeometry();
                pathFigure = new PathFigure();
                pathFigure.StartPoint = mDown;
                pathFigure.IsClosed = false;
                pathGeometry.Figures.Add(pathFigure);
                path = new Path();
                path.Stroke = new SolidColorBrush(penColor);
                if (screen.drawType == DrawType.erase)
                {
                    path.Stroke = new SolidColorBrush(Colors.White);
                }
                if (screen.drawType == DrawType.brush || screen.drawType == DrawType.erase)
                {
                    path.StrokeThickness = penThickness;
                }
                else if (screen.drawType == DrawType.pencil)
                {
                    path.StrokeThickness = 1;
                }
                path.Data = pathGeometry;
                screen.DrawShape(path);
            }
        }

       
        #endregion
        #region MouseMove
        private void paintCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            mMove = e.GetPosition(this.paintCanvas);
            bool addShape = false;
            if ((screen.drawType == DrawType.ellipse || screen.drawType == DrawType.rectangle || screen.drawType == DrawType.triangle || screen.drawType == DrawType.arrow || screen.drawType == DrawType.heart) && capture)
            {

                if (curShape == null)
                {

                    if (screen.drawType == DrawType.ellipse)
                    {
                        curShape = new Ellipse();
                    }
                    else if (screen.drawType == DrawType.rectangle)
                    {
                        curShape = new Rectangle();
                    }
                    else if (screen.drawType == DrawType.triangle)
                    {

                        curShape = new Triangle();
                        ((Triangle)curShape).Start = mDown;
                    }
                    else if (screen.drawType == DrawType.arrow)
                    {

                        curShape = new Arrow();
                        ((Arrow)curShape).Start = mDown;
                    }
                    else
                    {
                        curShape = new Heart();
                        ((Heart)curShape).Start = mDown;
                    }
                    addShape = true;
                    curShape.StrokeThickness = penThickness;
                    curShape.Stroke = new SolidColorBrush(penColor);
                }

                if (mMove.X <= mDown.X && mMove.Y <= mDown.Y)  //Góc phần tư thứ nhất
                {
                    curShape.Margin = new Thickness(mMove.X, mMove.Y, 0, 0);
                }
                else if (mMove.X >= mDown.X && mMove.Y <= mDown.Y)
                {
                    curShape.Margin = new Thickness(mDown.X, mMove.Y, 0, 0);
                }
                else if (mMove.X >= mDown.X && mMove.Y >= mDown.Y)
                {
                    curShape.Margin = new Thickness(mDown.X, mDown.Y, 0, 0);
                }
                else if (mMove.X <= mDown.X && mMove.Y >= mDown.Y)
                {
                    curShape.Margin = new Thickness(mMove.X, mDown.Y, 0, 0);
                }

                curShape.Width = Math.Abs(mMove.X - mDown.X);
                curShape.Height = Math.Abs(mMove.Y - mDown.Y);


                if (addShape)
                {
                    screen.DrawCapture(curShape);
                }
            }
            else if (screen.drawType == DrawType.line && capture)
            {
                if (curLine == null)
                {
                    curLine = new Line();
                    addShape = true;
                }
                curLine.X1 = mDown.X;
                curLine.Y1 = mDown.Y;
                curLine.X2 = mMove.X;
                curLine.Y2 = mMove.Y;
                curLine.StrokeThickness = penThickness;
                curLine.Stroke = new SolidColorBrush(penColor);
                if (addShape)
                {
                    screen.DrawCapture(curLine);

                }
            }
            else if ((screen.drawType == DrawType.brush || screen.drawType == DrawType.pencil || screen.drawType == DrawType.erase) && capture)
            {
                LineSegment ls = new LineSegment();
                ls.Point = mMove;
                pathFigure.Segments.Add(ls);
            }
        }
        #endregion
        #region MouseLeftButtonUp
        private void paintCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            capture = false;
            if (curShape != null)
            {
                if (screen.drawType == DrawType.ellipse || screen.drawType == DrawType.rectangle || screen.drawType == DrawType.triangle || screen.drawType == DrawType.arrow || screen.drawType == DrawType.heart)
                {
                    Shape temp;
                    if (screen.drawType == DrawType.ellipse)
                    {
                        temp = new Ellipse();
                    }
                    else if (screen.drawType == DrawType.rectangle)
                    {
                        temp = new Rectangle();
                    }
                    else if (screen.drawType == DrawType.triangle)
                    {
                        temp = new Triangle();
                    }
                    else if (screen.drawType == DrawType.arrow)
                    {
                        temp = new Arrow();
                    }
                    else
                    {
                        temp = new Heart();
                    }
                    temp.Stroke = new SolidColorBrush(penColor);
                    temp.StrokeThickness = penThickness;
                    curControl = new ContentControl();
                    temp.IsHitTestVisible = true;
                    if (screen.drawType == DrawType.triangle)
                    {
                        ((Triangle)temp).Start = ((Triangle)curShape).Start;
                        temp.Width = curShape.Width;
                        temp.Height = curShape.Height;
                    }
                    if (screen.drawType == DrawType.arrow)
                    {
                        ((Arrow)temp).Start = ((Arrow)curShape).Start;
                        temp.Width = curShape.Width;
                        temp.Height = curShape.Height;
                    }
                    if (screen.drawType == DrawType.heart)
                    {
                        ((Heart)temp).Start = ((Heart)curShape).Start;
                        temp.Width = curShape.Width;
                        temp.Height = curShape.Height;
                    }
                    Canvas.SetLeft(curControl, curShape.Margin.Left);
                    Canvas.SetTop(curControl, curShape.Margin.Top);
                    curControl.Width = curShape.Width;
                    curControl.Height = curShape.Height;
                    curControl.Content = temp;
                    curControl.Background = new SolidColorBrush(Colors.White);
                    screen.DrawShape(curControl);
                }
                curShape = null;
            }
            else if (screen.drawType == DrawType.line && curLine != null)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(penColor);
                line.StrokeThickness = penThickness;
                line.X1 = curLine.X1;
                line.X2 = curLine.X2;
                line.Y1 = curLine.Y1;
                line.Y2 = curLine.Y2;
                screen.DrawShape(line);
                curLine = null;
            }

        }
        #endregion
        #region Change Thickness
        private void cbxThickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbxThickness.SelectedIndex == 0)
            {
                penThickness = 1;
            }
            else if (cbxThickness.SelectedIndex == 1)
            {
                penThickness = 3;
            }
            else if (cbxThickness.SelectedIndex == 2)
            {
                penThickness = 5;
            }
            else if (cbxThickness.SelectedIndex == 3)
            {
                penThickness = 7;
            }
        }
        #endregion
        #region Change Color
        void btnColor_Click(object sender, RoutedEventArgs e)
        {
            Button btnColor = (Button)sender;
            Color color = ((SolidColorBrush)btnColor.Background).Color;
            btnColor1.Background = new SolidColorBrush(color);
            penColor = color;
        }

        private void btnEditColors_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.AllowFullOpen = true;
            dlg.ShowDialog();
            Color color = new Color();
            color.A = dlg.Color.A;
            color.R = dlg.Color.R;
            color.G = dlg.Color.G;
            color.B = dlg.Color.B;
            btnColor1.Background = new SolidColorBrush(color);
            penColor = color;
        }
        #endregion
        #region Exit 
        private void SimplePaint_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
        private void File_New_Click(object sender, RoutedEventArgs e)
        {
            screen.canvas.Children.RemoveRange(0, paintCanvas.Children.Count);
            screen.canvas.Background = new SolidColorBrush(Colors.White);
            screen = new Layer(paintCanvas);
            capture = false;
            penColor = Colors.Black;
            penThickness = 1;
            btnColor1.Background = new SolidColorBrush(Colors.Black);
            curFilePath = null;
            cbxThickness.SelectedIndex = 0;
        }
        private void Menu_Open_File(object sender, RoutedEventArgs e)
        {
            curFilePath = screen.openFile();
        }
    }
}
