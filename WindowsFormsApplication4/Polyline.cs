using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication4
{
    class Polyline:Shape
    {
        public int Numparts, Numpoints;
        public ArrayList Parts = new ArrayList();
        public ArrayList Point = new ArrayList();
    }
}
