using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRIALG_INTERNAL_SORT
{
    public partial class Form1 : Form
    {
        const int GapSize = 3;

        public static Font NumberFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular, GraphicsUnit.Pixel);
        public static Font HighLightFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold, GraphicsUnit.Pixel);
        public static Brush NumberBrush = new SolidBrush(Color.Black);
        public static Brush HighLightBrush = new SolidBrush(Color.Red);

        RadixSort Sorter = new RadixSort();
        int[] MainArray;
        PictureBox[] ArrayImage;

        public Form1()
        {
            InitializeComponent();

            //Sorter.BeginSplit += (o, e) => Threader(HighLightBucket, e);
            //Sorter.EndSplit += (o, e) => Threader(UnHighLightBucket, e);

            GenerateArrayStrip.Click += (ob, ev) => GenerateArray();
            DoSortStrip.Click += (ob, ev) => Sort();
        }

        void Threader(Action<object> method, object ev)
        {
            var t = new Thread(new ParameterizedThreadStart(method));
            t.Start(ev);
            t.Join();
        }

        void HighLightBucket(object ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            for (int i = e.Start; i < e.End; i++)
            {
                var loc = ArrayImage[i].Location;
                //Invoke(new Delegate(() => ArrayImage[i].Location = new Point(loc.X + 10, loc.Y)));
            }
            Thread.Sleep(1000);
        }

        void UnHighLightBucket(object ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            for (int i = e.Start; i < e.End; i++)
            {
                var loc = ArrayImage[i].Location;
                ArrayImage[i].Location = new Point(loc.X - 10, loc.Y);
            }
            Thread.Sleep(1000);
        }

        void GenerateArray()
        {
            GenerateArrayForm tmp = new GenerateArrayForm();
            if (tmp.ShowDialog(this) == DialogResult.OK)
            {
                MainArray = tmp.Result;
                InitializeArray();
            }
        }

        void InitializeArray()
        {
            if (ArrayImage != null)
            {
                foreach (var item in ArrayImage)
                {
                    item?.Dispose();
                }
            }

            ArrayImage = new PictureBox[MainArray.Length];
            var size = CalculateSize();

            for (int i=0; i< MainArray.Length; i++)
            {
                ArrayImage[i] = new PictureBox()
                {
                    Parent = ArrayBox,
                    Location = new Point(10, 15 + i * (size.Height + GapSize)),
                    Height = size.Height,
                    Width = size.Width,
                    BackColor = Color.White
                };
                DrawNumber(ref ArrayImage[i], MainArray[i], -1);
            }
        }

        void UpdateArray(int highlightedbit)
        {
            for (int i = 0; i < MainArray.Length; i++)
            {
                DrawNumber(ref ArrayImage[i], MainArray[i], highlightedbit);
            }
        }

        Size CalculateSize()
        {
            int h = Math.Min((ArrayBox.Height - 15) / MainArray.Length - GapSize, 60);
            NumberFont = new Font(FontFamily.GenericMonospace, h / 2, FontStyle.Regular, GraphicsUnit.Pixel);
            HighLightFont = new Font(FontFamily.GenericMonospace, h / 2, FontStyle.Bold, GraphicsUnit.Pixel);

            Bitmap _tmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(_tmp);

            int w = g.StringLength(MainArray[0].ToBitWise(), false);

            return new Size(w, h);
        }

        void DrawNumber(ref PictureBox pic, int num, int highlightedbit)
        {
            Bitmap img = new Bitmap(pic.Width, pic.Height);
            Graphics graphics = Graphics.FromImage(img);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            graphics.Write(num, false, new Point(0, 0));
            if (highlightedbit < 0 || highlightedbit > 31)
            {
                graphics.Write(num.ToBitWise(), false, new Point(0, pic.Height / 2));
            }
            else
            {
                string initial = num.ToBitWise();
                string before = initial.Substring(0, 33 - highlightedbit);
                char bit = initial[33 - highlightedbit];
                string after = initial.Substring(34 - highlightedbit);

                int beforelength = graphics.StringLength(before, false);
                int bitlength = beforelength + graphics.StringLength(bit, true);

                graphics.Write(before, false, new Point(0, pic.Height / 2));
                graphics.Write(bit, true, new Point(beforelength, pic.Height / 2));
                if (after != "") graphics.Write(after, false, new Point(bitlength, pic.Height / 2));
            }
            
            pic.Image = img;
        }

        void Sort()
        {
            Sorter.Sort(ref MainArray);
            UpdateArray(-1);
        }
    }

    public static class DrawingExtension
    {
        public static int StringLength(this Graphics @this, object what, bool highlight) => (int)@this.MeasureString(what.ToString(), highlight ? Form1.HighLightFont : Form1.NumberFont, int.MaxValue, StringFormat.GenericTypographic).Width;

        public static void Write(this Graphics @this, object what, bool highlight, Point p) => @this.DrawString(what.ToString(), highlight ? Form1.HighLightFont : Form1.NumberFont, highlight ? Form1.HighLightBrush : Form1.NumberBrush, p, StringFormat.GenericTypographic);
    }
}
