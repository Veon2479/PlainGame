using Avalonia.Controls;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;

namespace PlainGame.Views
{
    

    

    public partial class MainWindow : Window
    {
        public Line get_Line(Pen pen,Point p1,Point p2)
        {

            Line line = new Line();
            line.StartPoint = p1;
            line.EndPoint = p2;
            line.Stroke =pen.Brush;
            line.StrokeThickness = pen.Thickness;
            return line;
        }


        public void shape_print(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var pen = new Pen(new SolidColorBrush(),3);
            pen.Brush=Brushes.Black;
            Point p1 = new Point(y1, x1);
            Point p2 = new Point(y2, x2);
            Point p3 = new Point(y3, x3);
            Point p4 = new Point(y4, x4);
            Console.WriteLine(Convert.ToString(x1), Convert.ToString(y1),Convert.ToString(x2),Convert.ToString(y2));
            Console.WriteLine(Convert.ToString(x3), Convert.ToString(y3), Convert.ToString(x4), Convert.ToString(y4));
            MainScene.Children.Add(get_Line(pen,p1,p2));
            MainScene.Children.Add(get_Line(pen,p2, p3));
            MainScene.Children.Add(get_Line(pen,p3, p4));
            MainScene.Children.Add(get_Line(pen,p4, p1));


        }
        public void print()
        {
            double h = MainScene.Height;
            double w = MainScene.Width;
            double nh = MainScene.Height/4;
            double nw = MainScene.Width/4;
            
            for(int i = 0; i < 3; i++)
            {
                shape_print(h-i*nh,i*nw/2,h-i*nh,w-i*nw/2, h - (i+1) * nh, w - (i+1) * nw / 2, h - (i+1) * nh, (i+1) * nw / 2);
                shape_print(h - i * nh, i * nw / 2, h - (i + 1) * nh, (i + 1) * nw / 2, h - (i + 1) * nh - (175 - (i + 1) * 25), (i + 1) * nw / 2, h - i * nh-(175-i*25), i * nw / 2);
                shape_print(h - (i + 1) * nh, w - (i + 1) * nw / 2, h - i * nh, w - i * nw / 2, h - i * nh - (175 - i * 25), w - i * nw / 2, h - (i + 1) * nh - (175 - (i+1) * 25), w - (i + 1) * nw / 2);

            }




        }


        public MainWindow()
        {
            InitializeComponent();
            print();
        }
    }
}