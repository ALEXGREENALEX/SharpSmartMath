using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSmartMathLib;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace ExtMethods
{
    public static class ExtensionMethods
    {
        public static void Dump(this Object obj)
        {
            if (obj == null)
                DynamicCompile.VirtualConsoleOutput.Add("'null'");
            else if (obj.GetType() == typeof(string))
                DynamicCompile.VirtualConsoleOutput.Add("\"" + obj.ToString() + "\"");
            else
                DynamicCompile.VirtualConsoleOutput.Add(obj.ToString());
        }

        public static void LogError(this Object obj)
        {
            if (obj == null)
                DynamicCompile.VirtualConsoleErrorsOutput.Add("'null'");
            else if (obj.GetType() == typeof(string))
                DynamicCompile.VirtualConsoleErrorsOutput.Add("\"" + obj.ToString() + "\"");
            else
                DynamicCompile.VirtualConsoleErrorsOutput.Add(obj.ToString());
        }

        public static int length(this Array arr)
        {
            return arr.Length;
        }

        #region Plots
        public static void PlotDraw(this float[] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.Length];

                for (int i = 0; i < Points.Length; i++)
                    DataPoints[i] = new DataPoint(i, Points[i]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotDraw(this double[] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.Length];

                for (int i = 0; i < Points.Length; i++)
                    DataPoints[i] = new DataPoint(i, Points[i]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotDraw(this int[] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.Length];

                for (int i = 0; i < Points.Length; i++)
                    DataPoints[i] = new DataPoint(i, Points[i]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotDraw(this float[,] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.GetLength(0)];

                for (int i = 0; i < DataPoints.Length; i++)
                    DataPoints[i] = new DataPoint(Points[i, 0], Points[i, 1]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotDraw(this double[,] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.GetLength(0)];

                for (int i = 0; i < DataPoints.Length; i++)
                    DataPoints[i] = new DataPoint(Points[i, 0], Points[i, 1]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotDraw(this int[,] Points)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[Points.GetLength(0)];

                for (int i = 0; i < DataPoints.Length; i++)
                    DataPoints[i] = new DataPoint(Points[i, 0], Points[i, 1]);

                DynamicCompile.VirtualPlotModel.Series.Add(new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.White,
                    ItemsSource = DataPoints
                });
            }
            catch { }
        }

        public static void PlotClear()
        {
            DynamicCompile.VirtualPlotModel.Series.Clear();
        }
        #endregion
    }
}

namespace LibExtMethods
{
    public static class ExtensionMethods
    {
        public static int CountStringOccurrences(this string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}