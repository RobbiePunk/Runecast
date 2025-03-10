using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuneCast
{
    public partial class Form1 : Form
    {

        bool isCasting = false;
        int bias = 15;
        int RuneSize = 400;

        Bitmap castBmp;
        Bitmap normalizedBmp;

        Graphics castGR;
        Graphics normalizedGR;

        public List<Point> castedRune = new List<Point>();
        public List<Point> loadedRune = new List<Point>();


        public Form1()
        {
            InitializeComponent();

            castBmp = new Bitmap(castingWindowPB.Width, castingWindowPB.Height);
            normalizedBmp = new Bitmap(debugPB.Width, debugPB.Height);

            castGR = Graphics.FromImage(castBmp);
            normalizedGR = Graphics.FromImage(normalizedBmp);
        }

        void Norm()
        {
            while (castedRune.Count < 50)
            {
                int ind = 1;

                double maxDistance = 0;

                for (int i = 1; i < castedRune.Count; i++)
                {
                    double dist = GetDistance(castedRune[i - 1], castedRune[i]);
                    if (dist > maxDistance)
                    {
                        maxDistance = dist;
                        ind = i;
                    }
                }
                castedRune.Insert(ind,
                    new Point((castedRune[ind - 1].X + castedRune[ind].X) / 2, (castedRune[ind - 1].Y + castedRune[ind].Y) / 2));
            }

            while (castedRune.Count > 50)
            {
                int ind = 1;

                double minDistance = 10000;

                for (int i = 1; i < castedRune.Count - 1; i++)
                {
                    double dist = GetDistance(castedRune[i - 1], castedRune[i]) + GetDistance(castedRune[i], castedRune[i + 1]);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        ind = i;
                    }
                }
                castedRune.RemoveAt(ind);
            }

            int maxY = 0;
            int minY = castBmp.Height;
            int maxX = 0;
            int minX = castBmp.Width;

            for (int i = 0; i < castedRune.Count; i++)
            {
                if (castedRune[i].X < minX)
                    minX = castedRune[i].X;
                if (castedRune[i].X > maxX)
                    maxX = castedRune[i].X;
                if (castedRune[i].Y < minY)
                    minY = castedRune[i].Y;
                if (castedRune[i].Y > maxY)
                    maxY = castedRune[i].Y;
            }

            double coef = (double)RuneSize / (double)(Math.Max(maxX - minX, maxY - minY));

            for (int i = 0; i < castedRune.Count; i++)
            {
                castedRune[i] = new Point((int)Math.Floor(coef * (double)(castedRune[i].X - minX)), (int)Math.Floor(coef * (double)(castedRune[i].Y - minY)));
            }

            //return;

            Point center = new Point(RuneSize / 2, RuneSize / 2);

            for (int i = 0; i < castedRune.Count; i++)
            {
                center = new Point(center.X + castedRune[i].X, center.Y + castedRune[i].Y);
            }

            center = new Point(center.X / castedRune.Count, center.Y / castedRune.Count);

            Point shift = new Point(RuneSize / 2 - center.X, RuneSize / 2 - center.Y);

            for (int i = 0; i < castedRune.Count; i++)
            {
                castedRune[i] = new Point(shift.X + castedRune[i].X, shift.Y + castedRune[i].Y);
            }


        }

        double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        void DrawDebug(List<Point> rune)
        {
            SolidBrush BR = new SolidBrush(Color.Black);

            normalizedGR.Clear(Color.White);

            foreach(Point p in rune)
                normalizedGR.FillRectangle(BR, p.X + bias, p.Y + bias, 4, 4);
            debugPB.Image = normalizedBmp;

        }

        private void StartCasting(object sender, MouseEventArgs e)
        {
            castedRune.Clear();
            castGR.Clear(Color.White);
            isCasting = true;
        }

        private void StopCasting(object sender, MouseEventArgs e)
        {
            isCasting = false;
            //NormalizeDistance();

            DrawDebug(castedRune);
        }

        private void Casting(object sender, MouseEventArgs e)
        {
            if (!isCasting)
                return;

            Point newPoint = new Point(e.Location.X, e.Location.Y);

            castedRune.Add(newPoint);

            SolidBrush BR = new SolidBrush(Color.Black);

            castGR.FillRectangle(BR, newPoint.X, newPoint.Y, 4, 4);
            castingWindowPB.Image = castBmp;
        }

        private void SaveRune(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SaveFileName = saveFileDialog1.FileName;

                SaveCurrentRune(SaveFileName);
                //label1.Text = saveTime;
            }
            //DrawDebug();
        }

        private void distanceBT_Click(object sender, EventArgs e)
        {
            //NormalizeDistance();
            Norm();
            DrawDebug(castedRune);
        }

        void SaveCurrentRune(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            for (int i = 0; i < castedRune.Count; i++)
            {
                sw.WriteLine(castedRune[i].X.ToString());
                sw.WriteLine(castedRune[i].Y.ToString());
            }

            sw.Dispose();
        }

        private void LoadRune(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                LoadRune(path);
            }
            DrawDebug(loadedRune);
        }

        void FindBestRune()
        {
            int minDif = 1000000000;
            int ind = 0;

            string path = Directory.GetCurrentDirectory() + "/Runes";

            for (int i = 0; i < Directory.GetFiles(path).Length; i++)
            {
                LoadRune($"{path}/{i}");
                int dif = CountDif();
                if(dif < minDif)
                {
                    minDif = dif;
                    ind = i;
                }
            }

            LoadRune($"{path}/{ind}");
            DrawDebug(loadedRune);
        }

        int FindBestDotIndex(List<Point> buf, int castedRuneDotIndex)
        {
            double minDist = 10000;
            int ind = 0;
            for (int i = 0; i < buf.Count; i++)
            {
                double dist = GetDistance(castedRune[castedRuneDotIndex], buf[i]);
                if(dist < minDist)
                {
                    minDist = dist;
                    ind = i;
                }
            }
            return ind;
        }

        int CountDif()
        {
            List<Point> buf = new List<Point>();
            foreach(Point p in loadedRune)
                buf.Add(p);

            int dif = 0;
            for (int i = 0; i < castedRune.Count; i++)
            {
                int ind = FindBestDotIndex(buf, i);
                dif += (int)GetDistance(castedRune[i], buf[ind]);

                buf.RemoveAt(ind);

            }

            return dif;
        }

        void LoadRune(string path)
        {
            String[] Str = File.ReadAllLines(path);

            loadedRune.Clear();
            for (int i = 0; i < Str.Length / 2; i++)
            {
                loadedRune.Add(new Point(int.Parse(Str[2 * i]), int.Parse(Str[2 * i + 1])));
            }
        }

        private void FindBT_Click(object sender, EventArgs e)
        {
            Norm();
            FindBestRune();
        }
    }
}