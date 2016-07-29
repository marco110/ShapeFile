using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Point:Shape
    {
        public double X;
        public double Y;
        public Point() { }
        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
