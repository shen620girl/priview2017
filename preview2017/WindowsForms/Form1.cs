using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        #region 画曲线
        private void cllii(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建GDI对像
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            Point[] curvePoints =
            {
 new Point( 50, 250),
 new Point(100, 25),
 new Point(200, 250),
 new Point(250, 50),
 new Point(300, 75),
 new Point(350, 200),
 new Point(400, 150)
 };
            // e.Graphics.DrawLines(redPen, curvePoints);
            g.DrawCurve(greenPen, curvePoints);



        }
        #endregion

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region 图形验证码
        private void button2_Click(object sender, EventArgs e)
        {
            CreateCodeImage();
        }
        public void CreateCodeImage()
        {
            string[] str = new string[4];
            string serverCode = "";
            //生成随机生成器
            Random random = new Random();
            string _code = "";
            for (int i = 0; i < 4; i++)
            {
                str[i] = random.Next(10).ToString().Substring(0, 1);
                _code += str[i];
            }

            CreateCodeImage(str);
        }
        private void CreateCodeImage(string[] checkCode)
        {
            if (checkCode == null || checkCode.Length <= 0)
                return;
            int Width = 89;
            int Height = 135;

            //System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), this.CodePictureBox.Height);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(Width, Height);
            System.Drawing.Graphics g = Graphics.FromImage(image);

            try
            {
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);

                //画图片的背景噪音线
                for (int i = 0; i < 20; i++)
                {
                    int x1 = random.Next(image.Width);
                }
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), 5, 6, 52, 32);
                //定义颜色
                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                //定义字体
                string[] f = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

                for (int k = 0; k <= checkCode.Length - 1; k++)
                {
                    int cindex = random.Next(7);
                    int findex = random.Next(5);

                    Font drawFont = new Font(f[findex], 16, (System.Drawing.FontStyle.Bold));
                    SolidBrush drawBrush = new SolidBrush(c[cindex]);

                    float x = 3.0F;
                    float y = 0.0F;
                    float width = 20.0F;

                    float height = 25.0F;
                    int sjx = random.Next(10);
                    int sjy = random.Next(image.Height - (int)height);

                    RectangleF drawRect = new RectangleF(x + sjx + (k * 14), y + sjy, width, height);

                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;

                    g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);

                }
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                this.pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                g.Dispose();
                image.Dispose();
            }
        } 
        #endregion
    }
}
