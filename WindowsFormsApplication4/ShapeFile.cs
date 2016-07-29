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
    class ShapeFile
    {
        public string FilePath;
        public ShapeFile(){}
        public ShapeFile(string FilePath)
        {
            this.FilePath = FilePath;
        }
        public Shape GetShapesInfo(string FilePath)
        {
            Shape Shape=new Shape();
            FileStream File = new FileStream(FilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(File);
            br.ReadBytes(32);
            Shape.ShapeType =br.ReadInt32();
            Shape.Box[0] = br.ReadDouble();
            Shape.Box[1] = -1 * br.ReadDouble();
            Shape.Box[2] = br.ReadDouble();
            Shape.Box[3] = -1 * br.ReadDouble();
            Shape.Box[4] = br.ReadDouble();
            Shape.Box[5] = br.ReadDouble();
            Shape.Box[6] = br.ReadDouble();
            Shape.Box[7] = br.ReadDouble();
            switch (Shape.ShapeType)
            { 
                case 1:
                    Shape.Points.Clear();
                    while (br.PeekChar() != -1)
                    {
                        Point Point = new Point();
                        br.ReadInt32();
                        br.ReadInt32();
                        br.ReadInt32();
                        Point.X = br.ReadDouble();
                        Point.Y = -1 * br.ReadDouble();
                        Shape.Points.Add(Point);
                    }
                    break;
                case 3:
                    Shape.Polylines.Clear();
                    while (br.PeekChar() != -1)
                    {
                        Polyline Polyline = new Polyline();
                        br.ReadInt32();
                        br.ReadInt32();
                        Shape.ShapeType = br.ReadInt32();
                        Polyline.Box[0] = br.ReadDouble();
                        Polyline.Box[1] = br.ReadDouble();
                        Polyline.Box[2] = br.ReadDouble();
                        Polyline.Box[3] = br.ReadDouble();
                        Polyline.Numparts = br.ReadInt32();
                        Polyline.Numpoints = br.ReadInt32();
                        for (int i = 0; i < Polyline.Numparts; i++)
                        {
                            Polyline.Parts.Add(br.ReadInt32());
                        }
                        for (int i = 0; i < Polyline.Numpoints; i++)
                        {
                            Point point = new Point();
                            point.X = br.ReadDouble();
                            point.Y = -1 * br.ReadDouble();
                            Polyline.Point.Add(point);
                        }
                        Shape.Polylines.Add(Polyline);
                    }
                    break;
                case 5:
                    Shape.Polygons.Clear();
                    while (br.PeekChar() != -1)
                    {
                        Polygon Polygon = new Polygon();
                        br.ReadInt32();
                        br.ReadInt32();
                        br.ReadInt32();
                        Polygon.Box[0] = br.ReadDouble();
                        Polygon.Box[1] = br.ReadDouble();
                        Polygon.Box[2] = br.ReadDouble();
                        Polygon.Box[3] = br.ReadDouble();
                        Polygon.Numparts = br.ReadInt32();
                        Polygon.Numpoints = br.ReadInt32();
                        for (int i = 0; i < Polygon.Numparts; i++)
                        {
                            Polygon.Parts.Add(br.ReadInt32());
                        }
                        for (int i = 0; i < Polygon.Numpoints; i++)
                        {
                            Point point = new Point();
                            point.X = br.ReadDouble();
                            point.Y = br.ReadDouble();
                            Polygon.Point.Add(point);
                        }
                        Shape.Polygons.Add(Polygon);
                    }
                    break;           
            }
            br.Close();
            return Shape;
        }
    }
}
