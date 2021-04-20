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
        static int CurrentStart = 0;
        static int CurrentEnd = 0;
        static int CurrentBit = 0;

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

            Sorter.BeginSplit += (o, e) => Invoke(new EventHandler(HighLightBucket), o, e);
            Sorter.EndSplit += (o, e) => Invoke(new EventHandler(UnHighLightBucket), o, e);

            Sorter.LeftValidated += (o, e) => Invoke(new EventHandler(HighLightLeft), o, e);
            Sorter.RightValidated += (o, e) => Invoke(new EventHandler(HighLightRight), o, e);

            Sorter.LeftNotValidated += (o, e) => Invoke(new EventHandler(UnHighLightLeft), o, e);
            Sorter.RightNotValidated += (o, e) => Invoke(new EventHandler(UnHighLightRight), o, e);

            Sorter.BeginSwap += (o, e) => Invoke(new EventHandler(HighLightSwapped), o, e);
            Sorter.EndSwap += (o, e) => Invoke(new EventHandler(UnHighLightSwapped), o, e);

            GenerateArrayStrip.Click += (ob, ev) => GenerateArray();
            DoSortStrip.Click += (ob, ev) => Sort();
        }

        void HighLightBucket(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;

            CurrentStart = e.Start;
            CurrentEnd = e.End;
            CurrentBit = e.Rank;
            UpdateArray();

            for (int j = 0; j < 10; j++)
            {
                for (int i = e.Start; i < e.End; i++)
                {
                    var loc = ArrayImage[i].Location;
                    ArrayImage[i].Location = new Point(loc.X + 3, loc.Y);
                }
                Thread.Sleep(40);
            }
            Thread.Sleep(50);
            ArrayBox.Refresh();
        }

        void UnHighLightBucket(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;

            UpdateArray();

            for (int j = 0; j < 10; j++)
            {
                for (int i = e.Start; i < e.End; i++)
                {
                    var loc = ArrayImage[i].Location;
                    ArrayImage[i].Location = new Point(loc.X - 3, loc.Y);
                }
                Thread.Sleep(20);
            }
            Thread.Sleep(50);
            ArrayBox.Refresh();
        }

        void HighLightLeft(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            if (e.CurrentLeft > e.Start)
            {
                ArrayImage[e.CurrentLeft - 1].BackColor = Color.White;
                ArrayImage[e.CurrentLeft - 1].Refresh();
            }
            ArrayImage[e.CurrentLeft].BackColor = Color.Cyan;
            ArrayImage[e.CurrentLeft].Refresh();
            Thread.Sleep(400);
        }

        void HighLightRight(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            if (e.CurrentRight < e.End)
            {
                ArrayImage[e.CurrentRight].BackColor = Color.White;
                ArrayImage[e.CurrentRight].Refresh();
            }
            ArrayImage[e.CurrentRight - 1].BackColor = Color.Cyan;
            ArrayImage[e.CurrentRight - 1].Refresh();
            Thread.Sleep(400);
        }

        void UnHighLightLeft(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            if (e.CurrentLeft > e.Start)
            {
                ArrayImage[e.CurrentLeft - 1].BackColor = Color.White;
                ArrayImage[e.CurrentLeft - 1].Refresh();
            }
            ArrayImage[e.CurrentLeft].BackColor = Color.Yellow;
            ArrayImage[e.CurrentLeft].Refresh();
            Thread.Sleep(200);
        }

        void UnHighLightRight(object sender, EventArgs ev)
        {
            SplitEventArgs e = ev as SplitEventArgs;
            if (e.CurrentRight < e.End)
            {
                ArrayImage[e.CurrentRight].BackColor = Color.White;
                ArrayImage[e.CurrentRight].Refresh();
            }
            ArrayImage[e.CurrentRight - 1].BackColor = Color.Yellow;
            ArrayImage[e.CurrentRight - 1].Refresh();
            Thread.Sleep(200);
        }
        
        void HighLightSwapped(object sender, EventArgs ev)
        {
            SwapEventArgs e = ev as SwapEventArgs;
            for (int j = 0; j < 10; j++)
            {
                var first = ArrayImage[e.First].Location;
                var last = ArrayImage[e.Last].Location;
                ArrayImage[e.First].Location = new Point(first.X + 3, first.Y);
                ArrayImage[e.Last].Location = new Point(last.X + 3, last.Y);
                Thread.Sleep(50);
            }
            ArrayBox.Refresh();
        }

        void UnHighLightSwapped(object sender, EventArgs ev)
        {
            Thread.Sleep(100);
            UpdateArray();
            Thread.Sleep(100);

            SwapEventArgs e = ev as SwapEventArgs;
            for (int j = 0; j < 10; j++)
            {
                var first = ArrayImage[e.First].Location;
                var last = ArrayImage[e.Last].Location;
                ArrayImage[e.First].Location = new Point(first.X - 3, first.Y);
                ArrayImage[e.Last].Location = new Point(last.X - 3, last.Y);
                Thread.Sleep(20);
            }
            ArrayImage[e.First].BackColor = Color.Cyan;
            ArrayImage[e.Last].BackColor = Color.Cyan;
            Thread.Sleep(50);
            ArrayBox.Refresh();
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
            CurrentStart = 0;
            CurrentEnd = 0;
            CurrentBit = -1;
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

        void UpdateArray()
        {
            int i = 0;
            for (; i < CurrentStart; i++)
            {
                DrawNumber(ref ArrayImage[i], MainArray[i], -1);
                ArrayImage[i].BackColor = Color.White;
            }
            for (; i < CurrentEnd; i++)
            {
                DrawNumber(ref ArrayImage[i], MainArray[i], CurrentBit);
                ArrayImage[i].BackColor = Color.White;
            }
            for (; i < MainArray.Length; i++)
            {
                DrawNumber(ref ArrayImage[i], MainArray[i], -1);
                ArrayImage[i].BackColor = Color.White;
            }
            Refresh();
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

            CurrentStart = CurrentEnd = 0;
            CurrentBit = -1;
            UpdateArray();
        }
    }

    public static class DrawingExtension
    {
        public static int StringLength(this Graphics @this, object what, bool highlight) => (int)@this.MeasureString(what.ToString(), highlight ? Form1.HighLightFont : Form1.NumberFont, int.MaxValue, StringFormat.GenericTypographic).Width;

        public static void Write(this Graphics @this, object what, bool highlight, Point p) => @this.DrawString(what.ToString(), highlight ? Form1.HighLightFont : Form1.NumberFont, highlight ? Form1.HighLightBrush : Form1.NumberBrush, p, StringFormat.GenericTypographic);
    }
}
