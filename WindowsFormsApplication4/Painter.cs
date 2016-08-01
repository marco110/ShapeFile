using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WindowsFormsApplication4
{
    class Painter
    {
        public Canvas Canvas;
        public Style Style;
        public Painter() { }
        public Painter(Canvas canvas)
        {
            this.Canvas = canvas;
        }
        public Painter(Style Style)
        {
            this.Style = Style;
        }
        public Painter(Canvas Canvas, Style Style)
        {
            this.Style = Style;
            this.Canvas = Canvas;
        }
       
        public void Draw(BoundingBox BoundingBox)
        {
            var bitmap = Canvas.GetCanvas();
            Graphics g = Graphics.FromImage(bitmap);            
            g.Clear(Color.Transparent);
            Rectangle Rectangle = new Rectangle();
            Rectangle = new Rectangle(Math.Min((int)BoundingBox.Xmin, (int)BoundingBox.Xmax), Math.Min((int)BoundingBox.Ymin, (int)BoundingBox.Ymax),
                Math.Max((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) - Math.Min((int)BoundingBox.Xmin, (int)BoundingBox.Xmax),
                Math.Max((int)BoundingBox.Ymin, (int)BoundingBox.Ymax) - Math.Min((int)BoundingBox.Ymin, (int)BoundingBox.Ymax));                      
            g.DrawRectangle(new Pen(Color.Red, 1),Rectangle);            
        }
        
        public void Draw(Shape Shape)
        {
            var bitmap = Canvas.GetCanvas();
            switch (Shape.ShapeType)
            { 
                case 1:
                    foreach (Point p in Shape.Points)
                    {
                        PointF point = new PointF();
                        point.X = (float)((p.X - Shape.Box[0]) * (bitmap.Width / (Shape.Box[2] - Shape.Box[0])));
                        point.Y = (float)((p.Y - Shape.Box[1]) * (bitmap.Height / (Shape.Box[3] - Shape.Box[1])));
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawEllipse(new Pen(Color.Blue, 1), point.X, point.Y, 3, 3);
                    }
                    break;
                case 3:
                    foreach (Polyline p in Shape.Polylines)
                    {
                        for (int i = 0; i < p.Numparts; i++)
                        {
                            int startpoint, endpoint;
                            if (i != p.Numparts - 1)
                            {
                                startpoint = (int)p.Parts[i];
                                endpoint = (int)p.Parts[i + 1];
                            }
                            else
                            {
                                startpoint = (int)p.Parts[i];
                                endpoint = p.Numpoints;
                            }
                            PointF[] point = new PointF[endpoint - startpoint];
                            for (int k = 0, j = startpoint; j < endpoint; j++, k++)
                            {
                                Point poi = (Point)p.Point[j];
                                point[k].X = (float)((poi.X - Shape.Box[0]) * (bitmap.Width / (Shape.Box[2] - Shape.Box[0])));
                                point[k].Y = (float)((poi.Y - Shape.Box[1]) * (bitmap.Height / (Shape.Box[3] - Shape.Box[1])));
                            }
                            Graphics g = Graphics.FromImage(bitmap);
                            g.DrawLines(new Pen(Color.Blue, 1), point);
                        }
                    }
                    break;
                case 5:
                    foreach (Polygon p in Shape.Polygons)
                    {
                        for (int i = 0; i < p.Numparts; i++)
                        {
                            int startpoint, endpoint;
                            if (i != p.Numparts - 1)
                            {
                                startpoint = (int)p.Parts[i];
                                endpoint = (int)p.Parts[i + 1];
                            }
                            else
                            {
                                startpoint = (int)p.Parts[i];
                                endpoint = p.Numpoints;
                            }
                            PointF[] point = new PointF[endpoint - startpoint];
                            for (int k = 0, j = startpoint; j < endpoint; j++, k++)
                            {
                                Point poi = (Point)p.Point[j];
                                point[k].X = (float)((poi.X - Shape.Box[0]) * (bitmap.Width / (Shape.Box[2] - Shape.Box[0])));
                                point[k].Y = (float)((poi.Y - Shape.Box[1]) * (bitmap.Height / (Shape.Box[3] - Shape.Box[1])));
                            }
                            Graphics g = Graphics.FromImage(bitmap);
                            g.DrawPolygon(new Pen(Color.Blue, 1), point);
                        }
                    }
                    break;
            }
           // return bitmap;
        }
    }
}
