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
        bool ReadyDraw = false;
        bool StartDraw = false;
        Shape Shape;
        BoundingBox BoundingBox = new BoundingBox(); 
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
                MainFile MainFile = new MainFile();
                MainFile.Read(FilePath);
                ShapeFile ShapeFile = new ShapeFile();
                Shape = ShapeFile.GetShapes(FilePath);
                Canvas Canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
                Painter Painter = new Painter(Canvas);
                Painter.Draw(Shape);
                pictureBox1.BackgroundImage = Canvas.Bitmap;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ReadyDraw && StartDraw)
            {               
                BoundingBox.Xmax = e.X;
                BoundingBox.Ymax = e.Y;
                Canvas Canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
                Painter Painter = new Painter(Canvas);
                Painter.Draw(BoundingBox);
                pictureBox1.Image = Canvas.Bitmap;
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
                Canvas Canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
                Canvas InBoxCanvas = new Canvas(pictureBox2.Width, pictureBox2.Height);
                Canvas OutBoxCanvas = new Canvas(pictureBox3.Width, pictureBox3.Height);
                Painter Painter = new Painter(Canvas);
                Painter Painter1 = new Painter(InBoxCanvas);
                Painter Painter2 = new Painter(OutBoxCanvas);
                Painter.Draw(BoundingBox);
                pictureBox1.Image = Canvas.Bitmap;
                Operator Operator = new Operator();
                var NewShape = Operator.Split(BoundingBox, Shape, Canvas);
                Painter1.Draw(NewShape[0]);
                Painter2.Draw(NewShape[1]);
                pictureBox2.Image = InBoxCanvas.Bitmap;
                pictureBox3.Image = OutBoxCanvas.Bitmap;
            }
        }
        private void DrawBoundingBox_Click(object sender, EventArgs e)
        {
            ReadyDraw = true;
        }
    }
}
