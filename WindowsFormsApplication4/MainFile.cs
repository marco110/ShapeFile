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
    class MainFile
    {
        public string FilePath;
        public int FileCode, FileLength, Version, ShapeType, RecordNumber, ContentLength;
        public double[] Box = new double[8];
        int[] unused = new int[5];
        public void Read(string FilePath)
        {
            Shape Shape = new Shape();
            FileStream File = new FileStream(FilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(File);
            FileCode = br.ReadInt32();
            unused[0] = br.ReadInt32();
            unused[1] = br.ReadInt32();
            unused[2] = br.ReadInt32();
            unused[3] = br.ReadInt32();
            unused[4] = br.ReadInt32();
            FileLength = br.ReadInt32();
            Version = br.ReadInt32();
            Shape.ShapeType = br.ReadInt32();
            Box[0] = br.ReadDouble();
            Box[1] = -1 * br.ReadDouble();
            Box[2] = br.ReadDouble();
            Box[3] = -1 * br.ReadDouble();
            Box[4] = br.ReadDouble();
            Box[5] = br.ReadDouble();
            Box[6] = br.ReadDouble();
            Box[7] = br.ReadDouble();
            switch (ShapeType)
            { 
                case 1:
                    while (br.PeekChar() != -1)
                    {
                        Point Point = new Point();
                        RecordNumber = br.ReadInt32();
                        ContentLength = br.ReadInt32();
                        ShapeType = br.ReadInt32();                        
                        Point.X = br.ReadDouble();
                        Point.Y = -1 * br.ReadDouble();
                    }                   
                    break;
                case 3:
                    while(br.PeekChar()!=-1)
                    {
                        Polyline Polyline = new Polyline();
                        RecordNumber = br.ReadInt32();
                        ContentLength = br.ReadInt32();
                        ShapeType = br.ReadInt32();
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
                    }
                    break;
                case 5:
                    while (br.PeekChar() != -1)
                    {
                        Polygon Polygon = new Polygon();
                        RecordNumber = br.ReadInt32();
                        ContentLength = br.ReadInt32();
                        ShapeType = br.ReadInt32();
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
                    }
                    break;
            }
            br.Close();
        }
        public void Write() { }
       
    }
}
