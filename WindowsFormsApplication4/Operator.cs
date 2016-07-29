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
    class Operator
    {     
        public Shape[] Split(BoundingBox BoundingBox, Shape Shape,Canvas Bitmap)
        {
            Shape[]NewShape=new Shape[2];
            NewShape[0] = new Shape(Shape.ShapeType,Shape.Box);
            NewShape[1] = new Shape(Shape.ShapeType,Shape.Box);
            switch (Shape.ShapeType)
            { 
                case 1:                    
                    foreach (Point Point in Shape.Points)
                    {
                        if ((Point.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) > Math.Min((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (Point.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) < Math.Max((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (Point.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) > Math.Min((int)BoundingBox.Ymin, (int)BoundingBox.Ymax) &&
                                                  (Point.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) < Math.Max((int)BoundingBox.Ymin, (int)BoundingBox.Ymax))
                        {
                            NewShape[0].Points.Add(Point);
                        }
                        else
                        {
                            NewShape[1].Points.Add(Point);
                        }
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
                            for (int j = startpoint; j < endpoint; j++)
                            {
                                Point poi = (Point)p.Point[j];
                                if ((poi.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) > Math.Min((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (poi.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) < Math.Max((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (poi.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) > Math.Min((int)BoundingBox.Ymin, (int)BoundingBox.Ymax) &&
                                                  (poi.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) < Math.Max((int)BoundingBox.Ymin, (int)BoundingBox.Ymax))
                                {
                                    NewShape[0].Polylines.Add(p);
                                }
                                else
                                {
                                    NewShape[1].Polylines.Add(p);
                                }
                            }
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
                            for (int j = startpoint; j < endpoint; j++)
                            {
                                Point poi = (Point)p.Point[j];
                                if ((poi.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) > Math.Min((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (poi.X - Shape.Box[0]) * (float)(Bitmap.Width / (Shape.Box[2] - Shape.Box[0])) < Math.Max((int)BoundingBox.Xmin, (int)BoundingBox.Xmax) &&
                                                  (poi.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) > Math.Min((int)BoundingBox.Ymin, (int)BoundingBox.Ymax) &&
                                                  (poi.Y - Shape.Box[1]) * (float)(Bitmap.Height / (Shape.Box[3] - Shape.Box[1])) < Math.Max((int)BoundingBox.Ymin, (int)BoundingBox.Ymax))
                                {
                                    NewShape[0].Polygons.Add(p);
                                }
                                else
                                {
                                    NewShape[1].Polygons.Add(p);
                                }
                            }
                        }
                    }
                    break;
            }
            return NewShape;
            
        }
        
    }
}
