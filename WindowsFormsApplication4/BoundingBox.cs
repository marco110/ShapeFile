using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class BoundingBox
    {
        public double Xmin;
        public double Xmax;
        public double Ymin;
        public double Ymax;
        public BoundingBox()
        {            
        }
        public BoundingBox(double Xmin,double Xmax,double Ymin,double Ymax)
        {
            this.Xmin = Xmin;
            this.Xmax = Xmax;
            this.Ymin = Ymin;
            this.Ymax = Ymax;
        }
    }
}
