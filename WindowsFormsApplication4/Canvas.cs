using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication4
{
    class Canvas
    {
        public int Width;
        public int Height;
        public Bitmap Bitmap;
        public Canvas(int Width,int Height)
        {
            this.Width = Width;
            this.Height = Height;            
        }
        public Bitmap GetCanvas()
        {
            Bitmap = new Bitmap(Width, Height);
            return Bitmap;
        }
       
    }
}
