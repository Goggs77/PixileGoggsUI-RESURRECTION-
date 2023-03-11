using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Z.Expressions;
using System.Configuration;
using System.Windows;
using static System.Math;
using org.mariuszgromada.math.mxparser;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace PixileGoggsUI__RESURRECTION_;

public class Library
{
    

    public static bool IsEmptyOrNullOrWhitespace(string a)
    {
        return string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a);
    }
    public static bool IsIt<T>(string input) 
    {
        try
        {
            T result = (T)Convert.ChangeType(input, typeof(T));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    
    




    public static void ParametricEq(string xFunc, string yFunc, string color, int startX, int startY, double sizeFactor,
        int rotation,int parttype,bool plotorigin,bool slowmode, double upperLimit, double lowerLimit)
    {
        const string funcPath = "savefile.txt";
        using StreamWriter fs = new StreamWriter(funcPath,true);
        double steplength = 1 / (0.67 * Pow((0.114514d*sizeFactor + 1),E/2));
        if (slowmode)
        {
            steplength /= 20d;
        }

        bool isNoiseMode = false;
        if(!IsIt<int>(color))
        {
            if (color.ToLower() == "noise")
            {
                isNoiseMode = true;
            }
            else
            {
                color = "23";
            }
        }
        //if (MinStepLength != "default" && IsIt<double>(MinStepLength))
        //{
        //    if (steplength <= Convert.ToDouble(MinStepLength))
        //    {
        //        steplength = Convert.ToDouble(MinStepLength);
        //    }
        //}
        //
        //if (DesiredStepLength != "default" && IsIt<double>(DesiredStepLength))
        //{
        //    steplength = Convert.ToDouble(DesiredStepLength);
        //}
        int index = 0;
        for (double t = lowerLimit; t <= upperLimit; t += steplength)
        {
            try
            {
                string point;
                double pointY = (Eval.Execute<double>(yFunc, new { t })) * sizeFactor;
                double pointX = (Eval.Execute<double>(xFunc, new { t })) * sizeFactor;
                if (isNoiseMode){
                    point = $"{parttype},{index%120},{(int)pointX + startX},{(int)pointY+ startY},0,{rotation}";
                }
                else
                {
                    point = $"{parttype},{color},{(int)pointX + startX},{(int)pointY+ startY},0,{rotation}";
                }

                if (pointY >= Int32.MaxValue || pointY <= Int32.MinValue)
                {
                    
                }
                else
                {
                    Console.WriteLine(point);
                    fs.WriteLine(point);
                }
                
            }
            catch (Exception)
            {
                // ignored
            }

            index++;
        }

        if (plotorigin)
        {
            fs.Write($"\n1,0,{startX},{startY},0,0\n");
        }
        fs.Write("\n");

        Console.WriteLine($"[LOGGER]Plotting [x={xFunc}, y={yFunc}] is completed");
        fs.Close();
    }

    public static void EquationPlot(string EquationLeft, string EquationRight, string color, int startX, int startY, double scaleFactor,
        int rotation, int parttype, bool plotorigin, bool slowmode, string xRange, string yRange, double threshold)
    {
        bool isNoiseMode = false;
        int index = 0;
        if(!IsIt<int>(color))
        {
            if (color.ToLower() == "noise")
            {
                isNoiseMode = true;
            }
            else
            {
                color = "23";
            }
        }

        Random random = new Random();
        double steplength = (1 / (0.67 * Pow((0.114514d*scaleFactor + 1),E/2)));
        if (slowmode)
        {
            steplength /= 20d;
        }

        
        var xrange = xRange.Split(',');
        var yrange = yRange.Split(',');
        string point;
        bool isLeftVar = EquationLeft.Contains('x') || EquationLeft.Contains('y');
        bool isRightVar = EquationRight.Contains('x') || EquationRight.Contains('y');
        using (StreamWriter fs = new StreamWriter("savefile.txt", true))
        {
            
            try
            {
                for (double ty = Convert.ToDouble(yrange[0]);
                     Convert.ToDouble(yrange[0]) <= ty && ty <= Convert.ToDouble(yrange[1]);
                     ty += steplength)
                {
                    for (double tx = Convert.ToDouble(xrange[0]);
                         Convert.ToDouble(xrange[0]) <= tx && tx <= Convert.ToDouble(xrange[1]);
                         tx += steplength)
                    {
                        
                        var left = isLeftVar
                            ? Eval.Execute<double>(EquationLeft, new { x=tx, y=ty })
                            : Convert.ToDouble(EquationLeft);
                        var right = isRightVar
                            ? Eval.Execute<double>(EquationRight, new { x=tx, y=ty })
                            : Convert.ToDouble(EquationRight);
                        if (Abs(Abs(left / right) - 1) <= Convert.ToDouble(threshold))
                        {
                            point = isNoiseMode
                                ? $"{parttype},{random.Next(0, 120)},{(int)(tx * scaleFactor + startX)},{(int)(ty * scaleFactor + startY)},{rotation},0"
                                : $"{parttype},{color},{(int)(tx * scaleFactor + startX)},{(int)(ty * scaleFactor + startY)},{rotation},0";

                            if ((ty * scaleFactor + startY) >= Int32.MaxValue ||
                                (ty * scaleFactor + startY) <= Int32.MinValue)
                            {
                                //ignored
                            }
                            else
                            {
                                Console.WriteLine(point);
                                fs.WriteLine(point);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                // ignored
            }
            if (plotorigin)
            {
                fs.Write($"\n1,0,{startX},{startY},0,0\n");
            }
            fs.Write("\n");
            fs.Close();
            Console.WriteLine($"[LOGGER]Plotting {EquationLeft}={EquationRight} completed");
        }
        
    }

    public static void PolarPlot(string rFunc, string color, int startX, int startY, double sizeFactor,
        int rotation,int parttype, bool slowmode, bool plotorigin, double upperLimit, double lowerLimit)
    {
        if (IsEmptyOrNullOrWhitespace(rFunc))
        {
            throw new ArgumentException($"Can't eval empty input [{rFunc}]");
        }else
        if (!rFunc.Contains('a'))
        {
            throw new ArgumentException($"Can't find variable a in [{rFunc}]");
        }
        if (IsEmptyOrNullOrWhitespace(color.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{color}]");
        }
        if (IsEmptyOrNullOrWhitespace(startX.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startX}]");
        }
        if (IsEmptyOrNullOrWhitespace(startY.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startY}]");
        }
        if (IsEmptyOrNullOrWhitespace(sizeFactor.ToString(CultureInfo.CurrentCulture)))
        {
            throw new ArgumentException($"Can't eval empty input [{sizeFactor}]");
        }
        if (IsEmptyOrNullOrWhitespace(rotation.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{rotation}]");
        }
        if (IsEmptyOrNullOrWhitespace(parttype.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{parttype}]");
        }
        const string funcPath = "savefile.txt";
        using StreamWriter fs = new StreamWriter(funcPath,true);
        double steplength = 1 / (0.67 * Pow((0.114514d*sizeFactor + 1),E/2));
        if (slowmode)
        {
            steplength /= 20d;
        }
        //if (steplength <= Convert.ToDouble(MinStepLength)){steplength = Convert.ToDouble(MinStepLength);}
        //if (DesiredStepLength != "default" && IsIt<double>(DesiredStepLength))
        //{
        //    steplength = Convert.ToDouble(DesiredStepLength);
        //}
        bool isNoiseMode = false;
        int index = 0;
        if(!IsIt<int>(color))
        {
            if (color.ToLower() == "noise")
            {
                isNoiseMode = true;
            }
            else
            {
                color = "23";
            }
        }
        for (double a = lowerLimit; a <= upperLimit; a += steplength)
        {
            try
            {
                double pointY = Sin(a) * Eval.Execute<double>(rFunc, new { a }) * sizeFactor + startY;
                double pointX = Cos(a) * Eval.Execute<double>(rFunc, new { a }) * sizeFactor + startX;
                string point = "";
                if (isNoiseMode)
                {
                    point = $"{parttype},{index%120},{(int)pointX + startX},{(int)pointY+ startY},{rotation},0";
                }
                else
                {
                    point = $"{parttype},{color},{(int)pointX},{(int)pointY},{rotation},0";;
                }
                if (pointY >= Int32.MaxValue || pointY <= Int32.MinValue)
                {

                }
                else
                {
                    Console.WriteLine(point);
                    fs.WriteLine(point);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            index++;
        }
        if (plotorigin)
        {
            fs.Write($"\n1,0,{startX},{startY},0,0\n");
        }
        fs.Write("\n");
        fs.Close();
        Console.WriteLine($"[LOGGER]Plotting r={rFunc} is completed");
    }
    
    public static void FunctionMaker(string function, string color, int startX, int startY, double sizeFactor,int rotation, int parttype,double upperLimit, double lowerLimit, bool plotorigin = true,bool slowmode = false)
    {
        const string funcPath = "savefile.txt";
        if (IsEmptyOrNullOrWhitespace(function))
        {
            throw new ArgumentException($"Can't eval empty input [{function}]");
        }else
        if (!function.Contains('x'))
        {
            throw new ArgumentException($"Can't find variable x in [{function}]");
        }
        if (IsEmptyOrNullOrWhitespace(color.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{color}]");
        }
        if (IsEmptyOrNullOrWhitespace(startX.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startX}]");
        }
        if (IsEmptyOrNullOrWhitespace(startY.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startY}]");
        }
        if (IsEmptyOrNullOrWhitespace(sizeFactor.ToString(CultureInfo.CurrentCulture)))
        {
            throw new ArgumentException($"Can't eval empty input [{sizeFactor}]");
        }
        if (IsEmptyOrNullOrWhitespace(rotation.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{rotation}]");
        }
        if (IsEmptyOrNullOrWhitespace(parttype.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{parttype}]");
        }
        bool isNoiseMode = false;
        int index = 0;
        if(!IsIt<int>(color))
        {
            if (color.ToLower() == "noise")
            {
                isNoiseMode = true;
            }
            else
            {
                color = "23";
            }
        }
        using StreamWriter fs = new StreamWriter(funcPath,true);
        double steplength = 0.022 / 0.77 * Log(0.77 * Abs(sizeFactor) + 1);
        if (slowmode)
        {
            steplength /= 10;
        }
        for (double cx = lowerLimit; cx <= upperLimit; cx += steplength)
        {
            try
            {
                double pointY = (Eval.Execute<double>(function, new
                {
                    x = cx
                }) ) * sizeFactor+ startY;
                double pointX = (cx) * sizeFactor+startX;
                string point = "";
                if (isNoiseMode)
                {
                    point = $"{parttype},{index%120},{(int)pointX},{(int)pointY},{rotation},0";
                }
                else
                {
                    point = $"{parttype},{color},{(int)pointX},{(int)pointY},{rotation},0";;
                }
                if (pointY >= Int32.MaxValue || pointY <= Int32.MinValue)
                {

                }
                else
                {
                    Console.WriteLine(point);
                    fs.WriteLine(point);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            fs.WriteLine("\n");
        }
        if (plotorigin)
        {
            fs.Write($"\n1,0,{startX},{startY},0,0\n");
        }
        Console.WriteLine("[LOGGER]Graphing " + function + " is completed");
        fs.WriteLine("\n");
        fs.Close();
    }
    public static void FunctionMakerLimit(string function, int color, int startX, int startY, double sizeFactor,int rotation, int parttype
    , double uLimit, double lLimit)
    {
        const string funcPath = "savefile.txt";
        if (IsEmptyOrNullOrWhitespace(function))
        {
            throw new ArgumentException($"Can't eval empty input [{function}]");
        }else
        if (!function.Contains('x'))
        {
            throw new ArgumentException($"Can't find variable x in [{function}]");
        }
        if (IsEmptyOrNullOrWhitespace(color.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{color}]");
        }
        if (IsEmptyOrNullOrWhitespace(startX.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startX}]");
        }
        if (IsEmptyOrNullOrWhitespace(startY.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{startY}]");
        }
        if (IsEmptyOrNullOrWhitespace(sizeFactor.ToString(CultureInfo.CurrentCulture)))
        {
            throw new ArgumentException($"Can't eval empty input [{sizeFactor}]");
        }
        if (IsEmptyOrNullOrWhitespace(rotation.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{rotation}]");
        }
        if (IsEmptyOrNullOrWhitespace(parttype.ToString()))
        {
            throw new ArgumentException($"Can't eval empty input [{parttype}]");
        }

        using StreamWriter fs = new StreamWriter(funcPath,true);
        double steplength = 0.022 / 0.77 * Log(0.77 * sizeFactor + 1);
        
        for (double cx = lLimit; cx < uLimit; cx += steplength)
        {
            try
            {
                double pointY = (Eval.Execute<double>(function, new
                {
                    x = cx
                }) - startY) * sizeFactor;
                double pointX = (startX + cx) * sizeFactor;
                string point = $"{parttype},{color},{(int)pointX},{(int)pointY},0,{rotation}";
                Console.WriteLine(point);
                fs.WriteLine(point);
            }
            catch (Exception)
            {
                // ignored
            }
            fs.WriteLine("\n");
        }
        Console.WriteLine("[LOGGER]Graphing " + function + " is completed");
        fs.WriteLine("\n");
        fs.Close();
    }
    public static void LineMaker(int startX, int startY, int endX, int endY, int color, int parttype)
    {
        string funcPath = "savefile.txt";
        using StreamWriter fs = new StreamWriter(funcPath);
        bool flag = startX == endX;
        if (flag)
        {
            for (int ax = (int)MathF.Min(startY, endY); ax <= (int)MathF.Max(startY, endY); ax++)
            {
                double pointY = ax;
                string point = $"{parttype},{color},{(int)ax},{(int)pointY},0,0";
                Console.WriteLine(point);
                fs.WriteLine(point);
            }
            Console.WriteLine(string.Concat("[LOGGER]Graphing Line Segment from ",
                MathF.Min(startY, endY).ToString(), " to ", MathF.Max(startY, endY).ToString(), " is completed"));
        }
        else
        {
            double i = endY - startY / endX - startX;
            for (int cx = (int)MathF.Min(startX, endX); cx <= (int)MathF.Max(startX, endX); cx++)
            {
                try
                {
                    double pointX = startX + cx;
                    double pointY2 = i * pointX;
                    string point2 = $"{parttype},{color},{(int)pointX},{(int)pointY2},0,0";
                    Console.WriteLine(point2);
                    fs.WriteLine(point2);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            Console.WriteLine($"[LOGGER]Graphing line {i}x+(" + MathF.Min(startY, endY) + ") is completed");
            fs.Close();
        }
    }
    public static void LineMaker(double startX, double startY, double endX, double endY, int color, int parttype)
    {
        string funcPath = "savefile.txt";
        using StreamWriter fs = new StreamWriter(funcPath,true);
        bool flag = startX == endX;
        if (flag)
        {
            for (int ax = (int)Math.Min(startY, endY); ax <= (int)Math.Max(startY, endY); ax++)
            {
                double pointY = ax;
                string point = $"{parttype},{color},{(int)ax},{(int)pointY},0,0";
                Console.WriteLine(point);
                fs.WriteLine(point);
            }
            Console.WriteLine(string.Concat("[LOGGER]Graphing Line Segment from ",
                Math.Min(startY, endY).ToString(), " to ", Math.Max(startY, endY).ToString(), " is completed"));
        }
        else
        {
            double i = endY - startY / endX - startX;
            for (int cx = (int)Math.Min(startX, endX); cx <= (int)Math.Max(startX, endX); cx++)
            {
                try
                {
                    double pointX = startX + cx;
                    double pointY2 = i * pointX;
                    string point2 = $"{parttype},{color},{(int)pointX},{(int)pointY2},0,0";
                    Console.WriteLine(point2);
                    fs.WriteLine(point2);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            Console.WriteLine($"[LOGGER]Graphing line {i}x+(" + Math.Min(startY, endY) + ") is completed");
            fs.Close();
        }
    }
    public static void BezierCurve(float pos1X, float pos2X, float pos1Y, float pos2Y, float adj1X, float adj2X, float adj1Y, float adj2Y, int color, bool isConnectingPoSandAdj)
    {
        string funcPath = "savefile.txt";
        using (StreamWriter fs = new StreamWriter(funcPath))
        {
            for (double t = 0.0; t < 1.0; t += 0.001)
            {
                double xB = Math.Pow((1.0 - t), 3) * pos1X + 3.0 * t * Math.Pow((1.0 - t), 2) * adj1X + 3.0 * t * t * (1.0 - t) * adj2X + t * t * t * pos2X;
                double yB = Math.Pow((1.0 - t), 3) * pos1Y + 3.0 * t * Math.Pow((1.0 - t), 2) * adj1Y + 3.0 * t * t * (1.0 - t) * adj2Y + t * t * t * pos2Y;
                string point = $"6,{color},{(int)xB},{(int)yB},0,0"; 
                Console.WriteLine(point);
                fs.WriteLine(point);
            }
        }
        Console.WriteLine("[LOGGER]Graphing Bezier Curve " +
                          $"{pos1X},{pos1Y}|{pos2X},{pos2Y}|{adj1X},{adj1Y}|{adj2X},{adj2Y} is completed");
        bool flag = !isConnectingPoSandAdj;
        if (!flag)
        {
            LineMaker((int)pos1X, (int)pos1Y, (int)adj1X, (int)adj1Y, 0,6);
            LineMaker((int)pos2X, (int)pos2Y, (int)adj2X, (int)adj2Y, 0,6);
        }
    }
    public static string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
        }
			
        if (string.IsNullOrEmpty(allowedChars))
        {
            throw new ArgumentException("allowedChars may not be empty.");
        }
        char[] allowedCharSet = new HashSet<char>(allowedChars).ToArray();
			
        if (256 < allowedCharSet.Length)
        {
            throw new ArgumentException($"allowedChars may contain no more than {256} characters.");
        }

        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        StringBuilder result = new StringBuilder();
        byte[] buf = new byte[128];
        while (result.Length < length)
        {
            rng.GetBytes(buf);
            int i = 0;
            while (i < buf.Length && result.Length < length)
            {
                int outOfRangeStart = 256 - 256 % allowedCharSet.Length;
                bool flag4 = outOfRangeStart <= buf[i];
                if (!flag4)
                {
                    result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                }
                i++;
            }
        }
        var result2 = result.ToString();
        return result2;
    }
}