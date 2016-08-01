using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication4
{
    class Style
    {
        public int BorderWidth;
        public Color BorderColor;
        public Style(int BorderWidth,Color BorderColor)
        {
            this.BorderColor = BorderColor;
            this.BorderWidth = BorderWidth;
        }
    }
}
