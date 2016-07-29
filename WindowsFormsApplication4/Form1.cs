using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        Painter Painter = new Painter();
        BoundingBox BoundingBox = new BoundingBox();       
        Shape Shape = new Shape();
        ShapeFile ShapeFile = new ShapeFile();
        MainFile MainFile = new MainFile();
        bool ReadyDraw = false;
        bool StartDraw = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Open_Click(object sender, EventArgs e)
        {
            ReadyDraw = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            OpenFileDialog File = new OpenFileDialog();
            File.Filter = "shapefiles(*.shp)|*.shp|All files(*.*)|*.*";
            if (File.ShowDialog() == DialogResult.OK)
            {                             
                string FilePath = File.FileName;
                MainFile.Read(FilePath);
                Shape = ShapeFile.GetShapesInfo(FilePath);
                Canvas b = new Canvas(pictureBox1.Width, pictureBox1.Height);
                var Image = Painter.Draw(Shape,b);
                pictureBox1.BackgroundImage = Image;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ReadyDraw && StartDraw)
            {               
                BoundingBox.Xmax = e.X;
                BoundingBox.Ymax = e.Y;
                Canvas b = new Canvas(pictureBox1.Width, pictureBox1.Height);
                var Image= Painter.Draw(BoundingBox,b);
                pictureBox1.Image = Image;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ReadyDraw)
            {
                StartDraw = true;
                BoundingBox.Xmin = e.X;
                BoundingBox.Ymin = e.Y;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ReadyDraw && StartDraw)
            {
                StartDraw = false;
                BoundingBox.Xmax = e.X;
                BoundingBox.Ymax = e.Y;
                Canvas Bitmap = new Canvas(pictureBox1.Width, pictureBox1.Height);
                Canvas InBoxBitmap = new Canvas(pictureBox2.Width, pictureBox2.Height);
                Canvas OutBoxBitmap = new Canvas(pictureBox3.Width, pictureBox3.Height);
                var Image = Painter.Draw(BoundingBox, Bitmap);
                pictureBox1.Image =Image;
                Operator Operator = new Operator();
                var NewShape = Operator.Split(BoundingBox, Shape, Bitmap);
                var Image2 = Painter.Draw(NewShape[0], InBoxBitmap);
                var Image3 = Painter.Draw(NewShape[1], OutBoxBitmap);
                pictureBox2.Image = Image2;
                pictureBox3.Image = Image3;
            }
        }
        private void DrawBoundingBox_Click(object sender, EventArgs e)
        {
            ReadyDraw = true;
        }
    }
}
