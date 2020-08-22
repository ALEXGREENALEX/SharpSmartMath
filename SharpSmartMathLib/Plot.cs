using System;
using System.Collections.Generic;
using System.Text;

using OxyPlot;
using OxyPlot.Series;

public static class Plot
{
    public static PlotModel Model = new PlotModel();

    public static LineSeries NewLine(double[] PointsA = null, double[] PointsB = null, string ColorStr = null)
    {
        LineSeries Series = new LineSeries();

        if (PointsA != null)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[PointsA.Length];

                if (PointsB != null)
                {
                    for (int i = 0; i < PointsA.Length; i++)
                        DataPoints[i] = new DataPoint(i, PointsA[i]);
                }
                else
                {
                    for (int i = 0; i < Math.Min(PointsA.Length, PointsB.Length); i++)
                        DataPoints[i] = new DataPoint(PointsA[i], PointsB[i]);
                }

                Series.ItemsSource = DataPoints;
            }
            catch { }
        }

        Series.StrokeThickness = 2;
        Series.Color = ParseColor(ColorStr);
        Model.Series.Add(Series);
        return Series;
    }

    public static LineSeries NewLine(float[] PointsA, float[] PointsB = null, string ColorStr = null)
    {
        LineSeries Series = new LineSeries();

        if (PointsA != null)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[PointsA.Length];

                if (PointsB != null)
                {
                    for (int i = 0; i < PointsA.Length; i++)
                        DataPoints[i] = new DataPoint(i, PointsA[i]);
                }
                else
                {
                    for (int i = 0; i < Math.Min(PointsA.Length, PointsB.Length); i++)
                        DataPoints[i] = new DataPoint(PointsA[i], PointsB[i]);
                }

                Series.ItemsSource = DataPoints;
            }
            catch { }
        }

        Series.StrokeThickness = 2;
        Series.Color = ParseColor(ColorStr);
        Model.Series.Add(Series);
        return Series;
    }

    public static LineSeries NewLine(int[] PointsA, int[] PointsB = null, string ColorStr = null)
    {
        LineSeries Series = new LineSeries();

        if (PointsA != null)
        {
            try
            {
                DataPoint[] DataPoints = new DataPoint[PointsA.Length];

                if (PointsB != null)
                {
                    for (int i = 0; i < PointsA.Length; i++)
                        DataPoints[i] = new DataPoint(i, PointsA[i]);
                }
                else
                {
                    for (int i = 0; i < Math.Min(PointsA.Length, PointsB.Length); i++)
                        DataPoints[i] = new DataPoint(PointsA[i], PointsB[i]);
                }

                Series.ItemsSource = DataPoints;
            }
            catch { }
        }

        Series.StrokeThickness = 2;
        Series.Color = ParseColor(ColorStr);
        Model.Series.Add(Series);
        return Series;
    }

    public static void ClearLines()
    {
        Model.Series.Clear();
        NewLine();
    }

    public static void Add(double Y)
    {
        try
        {
            LineSeries LS = GetLastLineSeries();
            LS.Points.Add(new DataPoint(LS.Points.Count - 1, Y));
        }
        catch { }
    }

    public static void Add(double X, double Y)
    {
        try
        {
            GetLastLineSeries().Points.Add(new DataPoint(X, Y));
        }
        catch { }
    }

    public static void Clear()
    {
        GetLastLineSeries().Points.Clear();
    }

    static LineSeries GetLastLineSeries()
    {
        for (int i = Model.Series.Count - 1; i >= 0; i--)
        {
            if (Model.Series[i] is LineSeries) ;
            return Model.Series[i] as LineSeries;
        }

        return NewLine();
    }

    static OxyColor ParseColor(string ColorStr)
    {
        if (ColorStr == null)
            return OxyColors.White;

        try
        {
            return OxyColor.Parse(ColorStr);
        }
        catch
        {
            return OxyColors.White;
        }
    }
}