using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication4
{
    class Shape
    {
        public int ShapeType;
        public double[] Box = new double[8];
        public ArrayList Points = new ArrayList();
        public ArrayList Polylines = new ArrayList();
        public ArrayList Polygons = new ArrayList();
        public Shape() {}
        public Shape(int ShapeType,double []Box)
        {
            this.ShapeType = ShapeType;
            this.Box = Box;
        }        
    }
}
