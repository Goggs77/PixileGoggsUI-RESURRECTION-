using System;
using System.IO;
using static System.Math;
namespace PixileGoggsUI__RESURRECTION_;

public class ShapeLib
{
    public static double Length(double x1, double x2, double y1, double y2)
    {
        return Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }

    public static void rope(double r, double l, double originx, double originy)
    {
        double a = l / (Cosh(r) - 1d);
        string function = $"a*Cosh(x-{originx})-a+{originy}";
        double upperLimit = originx + r;
        double lowerLimit = originx - r;
        //WIP
    }

    public static void Rectangle(double x1, double y1, double length, double height, int color, int parttype, bool fill)
    {
        using StreamWriter fs = new StreamWriter("savefile.txt",true);
        if (fill)
        {
            
            for (double x = x1; x < x1+length; x++)
            {
                for (double y = y1; y < y1+height; y++)
                {
                    fs.WriteLine($"{parttype},{color},{(int)x},{(int)y},0,0");
                }
            }
        }else if(!fill)
        {
            Library.LineMaker(x1,y1,x1+length,y1,color,parttype,fs);
            Library.LineMaker(x1,y1,x1,y1+height,color,parttype,fs);
            Library.LineMaker(x1+length,y1,x1+length,y1+height,color,parttype,fs);
            Library.LineMaker(x1,y1+height,x1+length,y1+height,color,parttype,fs);
        }
        fs.Close();
    }
    public static void BezierCurve(
        Point2 pos1,
        Point2 pos2,
        Point2 adj1,
        Point2 adj2,
        int color,
        StreamWriter fs,
        double ysf=1d)
    {
        for (double t = 0.0; t < 1.0; t += 0.01)
        {
            Point2 res = Math.Pow((1.0 - t), 3) * pos1 + 3.0 * t * Math.Pow((1.0 - t), 2) * adj1 + 3.0 * t * t * (1.0 - t) * adj2 + t * t * t * pos2;
            res.Y *= ysf;
            string point = $"6,{color},{Point2.ToIString(res)},0,0"; 
            Console.WriteLine(point);
            fs.WriteLine(point);
        }
    }
    public static void RandomShell(
        Point2 start,
        int size,
        int steps,
        int seed,
        int color,
        double yScaleFactor)
    {
        using (StreamWriter fs = new StreamWriter("savefile.txt", true))
        {
            start.Y /= yScaleFactor;
            Random rnd = new Random(seed);
            Point2 next = Point2.RandomPoint2(start,size,rnd);
            Point2 prev = new Point2();
            fs.WriteLine($"\n1,0,{Point2.ToIString(new Point2(){X = start.X,Y = start.Y*yScaleFactor})},0,0");
            for (int i = 0; i < steps; i++)
            {
                if (i == 0)
                {
                    BezierCurve(start, next, Point2.RandomPoint2(start, size / 3, rnd),
                        Point2.RandomPoint2(next, size / 3, rnd), color, fs,yScaleFactor);
                    next = Point2.RandomPoint2(next, size, rnd);
                    prev = Point2.RandomPoint2(next,size,rnd);
                }
                BezierCurve(prev, next, Point2.RandomPoint2(prev, size / 3, rnd),
                    Point2.RandomPoint2(next, size / 3, rnd), color, fs,yScaleFactor);
                next = Point2.RandomPoint2(next, size, rnd);
                BezierCurve(prev, next, Point2.RandomPoint2(prev, size / 3, rnd),
                    Point2.RandomPoint2(next, size / 3, rnd), color, fs,yScaleFactor);
                prev = Point2.RandomPoint2(next,size,rnd);
            }
            BezierCurve(prev, start, Point2.RandomPoint2(prev, size / 3, rnd),
                Point2.RandomPoint2(start, size / 3, rnd), color, fs,yScaleFactor);
            fs.Close();
        }
    }
}

public class Point2
{
    public double X;
    public double Y;

    public Point2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Point2()
    {
        
    }

    public static Point2 RandomPoint2(Random rnd)
    {
        return new Point2(rnd.NextDouble() * rnd.Next(), rnd.NextDouble() * rnd.Next());
    }
    public static Point2 RandomPoint2(Point2 near, int threshold,Random rnd)
    {
        return new Point2(near.X + rnd.NextDouble() * rnd.Next(-threshold,threshold), near.Y + rnd.NextDouble() * rnd.Next(-threshold,threshold));
    }

    public static string ToString(Point2 a)
    {
        return $"{a.X},{a.Y}";
    }
    public static string ToIString(Point2 a)
    {
        return $"{(int)a.X},{(int)a.Y}";
    }

    public static bool Equals(Point2 a, Point2 b)
    {
        return (a.X.Equals(b.X)) && (b.Y.Equals(a.Y));
    }

    public static Point2 operator +(Point2 a, Point2 b)
    {
        return new Point2(a.X + b.X, b.Y + a.Y);
    }
    public static Point2 operator -(Point2 a, Point2 b)
    {
        return new Point2(a.X - b.X, - b.Y + a.Y);
    }
    public static Point2 operator *(Point2 a, double b)
    {
        return new Point2(a.X * b,a.Y * b );
    }
    public static Point2 operator *(double b, Point2 a)
    {
        return new Point2(a.X * b,a.Y * b );
    }
    public static Point2 operator /(Point2 a, double b)
    {
        return new Point2(a.X / b,a.Y / b );
    }
    public static Point2 operator /(double b, Point2 a)
    {
        return new Point2(a.X / b,a.Y / b );
    }
}