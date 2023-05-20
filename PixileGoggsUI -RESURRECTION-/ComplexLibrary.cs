using System;
using System.IO;
using System.Windows;
using complex= PixileGoggsUI__RESURRECTION_.Complex;
using static PixileGoggsUI__RESURRECTION_.Complex;
using Z.Expressions;
namespace PixileGoggsUI__RESURRECTION_;

public static class ComplexLibrary
{
    private static EvalContext _context = new EvalContext();

    public static void Epoiuhsdflgkjbwpriougddflkhjbrgiolyhsbvediolusgbhjaer()
    {
        _context.RegisterStaticMethod(typeof(Complex));
        _context.RegisterStaticMember(typeof(Complex));
        _context.UnregisterType(typeof(File));
        _context.UnregisterType(typeof(Path));
        _context.UnregisterType(typeof(Window));
        
    }
    public static bool IsEmptyOrNullOrWhitespace(string a)
    {
        return string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a);
    }

    public static double Lerp(double a, double b, double t)
    {
        t = Math.Clamp(t, 0, 1);
        return a + t * (b - a);
    }

    public static bool IsIt<T>(string input) 
    {
        try
        {
            Convert.ChangeType(input, typeof(T));
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public static Func<Complex, Complex> CompileFunc(string complexFunction)//here using w=f(z)
    {
        return _context.Compile<Func<Complex, Complex>>(complexFunction, "z");
    }

    public static void MdbPlot(
        Func<Complex, Complex> convergenceFunc, 
        string originCoordinates, 
        int rotation,
        string realLimits,
        string imLimits,
        double scaleFactor)
    {
        int Mandelbrot(Complex c)
        {
            Complex z = ToComplex(0,0);
            Complex previous;
            int i = 0;
            for (; i <= 750 && Modulus(z)<=2; i++)
            {
                //previous = z;
                z = convergenceFunc(z) + c;
                //if (Math.Abs(Modulus(z) - Modulus(previous)) <= 0.25d &&
                //    Math.Abs(Argument(z) - Argument(previous)) <= 0.25d)
                //{
                //    break;
                //}
            }
            return i;
        }

        (bool isConvergence, int steps) CheckConvergence(Complex z)
        {
            int iterations = Mandelbrot(z);
            return iterations <= 750 ? (false, -1) : (true, iterations);
        }
        GC.Collect();
        string[] rlimits = realLimits.Split(',');
        if (rlimits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"X range must be in -100,100 like format, not {realLimits}");
        }

        string[] ilimits = imLimits.Split(',');
        if (ilimits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Y range must be in -100,100 like format, not {imLimits}");
        }

        string[] coords = originCoordinates.Split(',');
        if (coords.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Coordinates must be in -2221,2221 like format, not {originCoordinates}");
        }

        using (var fs = new StreamWriter("savefile.txt",true))
        {
            
            for (double real = Convert.ToDouble(rlimits[0]); real <= Convert.ToDouble(rlimits[1]); real+=1/(scaleFactor+1))
            {
                for (double im = Convert.ToDouble(ilimits[0]); im <= Convert.ToDouble(ilimits[1]); im+=1/(scaleFactor+1))
                {
                    var p = CheckConvergence(ToComplex(real, im));
                    
                    if (p.isConvergence)
                    {
                        fs.WriteLine(
                            $"6,{(int)Lerp(129,120,p.steps/750D)},{(int)(scaleFactor*(real))+Convert.ToInt32(coords[0])},{(int)(scaleFactor*(im))+Convert.ToInt32(coords[1])},{rotation},0");
                    }
                    else if (!p.isConvergence)
                    {
                        //fs.WriteLine(
                        //    $"6,{128},{(int)(scaleFactor*(real + Convert.ToDouble(coords[0])))},{(int)(scaleFactor*(im + Convert.ToDouble(coords[1])))},{rotation},0");
                    }
                }
                GC.Collect();
            }
            fs.WriteLine(
                $"1,0,{(int)(Convert.ToDouble(coords[0]))},{(int)(Convert.ToDouble(coords[1]))},{rotation},0\n");
            fs.Close();
        }
    }

    public static void PlotFunctionRealAxis(string function,
        string color,
        string originCoordinates,
        double scaleFactor,
        int rotation,
        int partType,
        string realLimits,
        double slowModeScale,
        bool plotOrigin = true)
    {
        GC.Collect();
        string[] limits = realLimits.Split(',');
        if (limits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"X range must be in -100,100 like format, not {realLimits}");
        }
        string[] coords = originCoordinates.Split(',');
        if (coords.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Coordinates must be in -2221,2221 like format, not {originCoordinates}");
        }
        
        double steplength = 0.022 / 0.77 * Math.Log(0.77 * Math.Abs(scaleFactor) + 1);
        steplength /= slowModeScale;
        Random rnd = new Random();
        int index = 12;
        using (var fs = new StreamWriter("savefile.txt", true))
        {
            for (double real = Convert.ToDouble(limits[0]); real < Convert.ToDouble(limits[1]); real += steplength)
            {
                complex point = _context.Execute<complex>(function, new {z = ToComplex(real)});
                point *= scaleFactor;
                if (color.ToLower() == "noise")
                {
                    fs.WriteLine($"{partType},{rnd.Next(12,120)},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(color.ToLower() == "order")
                {
                    if (index == 120) index = 12;
                    fs.WriteLine($"{partType},{index},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(IsIt<int>(color))
                {
                    fs.WriteLine(
                        $"{partType},{color},{(int)(point.Real + Convert.ToDouble(coords[0]))},{(int)(point.Imaginary + Convert.ToDouble(coords[1]))},{rotation},0");
                }

                index++;
            }

            if (plotOrigin)
            {
                fs.WriteLine($"\n1,0,{Convert.ToInt32(coords[0])},{Convert.ToInt32(coords[1])},0,0");
            }
            fs.Close();
        }
        GC.Collect();
    }

    public static void PlotFunctionImaginaryAxis(string function,
        string color,
        string originCoordinates,
        double scaleFactor,
        int rotation,
        int partType,
        string realLimits,
        double slowModeScale,
        bool plotOrigin = true)
    {
        GC.Collect();
        string[] limits = realLimits.Split(',');
        if (limits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"X range must be in -100,100 like format, not {realLimits}");
        }
        string[] coords = originCoordinates.Split(',');
        if (coords.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Coordinates must be in -2221,2221 like format, not {originCoordinates}");
        }
        
        double steplength = 0.022 / 0.77 * Math.Log(0.77 * Math.Abs(scaleFactor) + 1);
        steplength /= slowModeScale;
        Random rnd = new Random();
        int index = 12;
        using (var fs = new StreamWriter("savefile.txt", true))
        {
            for (double real = Convert.ToDouble(limits[0]); real < Convert.ToDouble(limits[1]); real += steplength)
            {
                complex point = _context.Execute<complex>(function, new {z = I(real)});
                point *= scaleFactor;
                if (color.ToLower() == "noise")
                {
                    fs.WriteLine($"{partType},{rnd.Next(12,120)},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(color.ToLower() == "order")
                {
                    if (index == 120) index = 12;
                    fs.WriteLine($"{partType},{index},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(IsIt<int>(color))
                {
                    fs.WriteLine(
                        $"{partType},{color},{(int)(point.Real + Convert.ToDouble(coords[0]))},{(int)(point.Imaginary + Convert.ToDouble(coords[1]))},{rotation},0");
                }

                index++;
            }

            if (plotOrigin)
            {
                fs.WriteLine($"\n1,0,{Convert.ToInt32(coords[0])},{Convert.ToInt32(coords[1])},0,0\n");
            }
            fs.Close();
        }
        GC.Collect();
    }

    public static void PlotFunctionRange(string function,
        string color,
        string originCoordinates,
        double scaleFactor,
        int rotation,
        int partType,
        string realLimits,
        string imLimits,
        double modulusLimit,
        double slowModeScale,
        bool plotOrigin = true)
    {
        GC.Collect();
        string[] rlimits = realLimits.Split(',');
        if (rlimits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"X range must be in -100,100 like format, not {realLimits}");
        }

        string[] ilimits = imLimits.Split(',');
        if (ilimits.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"X range must be in -100,100 like format, not {imLimits}");
        }

        string[] coords = originCoordinates.Split(',');
        if (coords.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Coordinates must be in -2221,2221 like format, not {originCoordinates}");
        }

        using (var fs = new StreamWriter("savefile.txt", true))
        {
            double steplength = 0.022 / 0.77 * Math.Log(0.77 * Math.Abs(scaleFactor) + 1);
            steplength /= slowModeScale;
            var compiled = _context.Compile<Func<Complex, Complex>>(function, "z");
            int index = 12;
            Random rnd = new Random();
            complex p;
            for (double real = Convert.ToDouble(rlimits[0]); real <= Convert.ToDouble(rlimits[1]); real += steplength)
            {
                for (double im = Convert.ToDouble(ilimits[0]); im <= Convert.ToDouble(ilimits[1]); im += steplength)
                {
                    p = compiled(ToComplex(real, im));
                    p *= scaleFactor;
                    if (Modulus(p) <= modulusLimit)
                    {
                        if (color.ToLower() == "noise")
                        {
                            fs.WriteLine($"{partType},{rnd.Next(12,120)},{(int)(p.Real+Convert.ToDouble(coords[0]))},{(int)(p.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                        }
                        else if(color.ToLower() == "order")
                        {
                            if (index == 120) index = 12;
                            fs.WriteLine($"{partType},{index},{(int)(p.Real+Convert.ToDouble(coords[0]))},{(int)(p.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                        }
                        else if(IsIt<int>(color))
                        {
                            fs.WriteLine(
                                $"{partType},{color},{(int)(p.Real + Convert.ToDouble(coords[0]))},{(int)(p.Imaginary + Convert.ToDouble(coords[1]))},{rotation},0");
                        }
                        GC.Collect();
                        index++;
                    }
                }
            }
            if (plotOrigin)
            {
                fs.WriteLine($"\n1,0,{Convert.ToInt32(coords[0])},{Convert.ToInt32(coords[1])},0,0\n");
            }
            fs.Close();
        }
        GC.Collect();
    }
    public static void PlotFunctionUnitCircle(string function,
        string color,
        string originCoordinates,
        double scaleFactor,
        int rotation,
        int partType,
        double modulusLimit,
        double slowModeScale,
        bool plotOrigin = true)
    {
        GC.Collect();
        string[] coords = originCoordinates.Split(',');
        if (coords.Length != 2)
        {
            throw new ArgumentOutOfRangeException($"Coordinates must be in -2221,2221 like format, not {originCoordinates}");
        }
        
        double steplength = 0.022 / 0.77 * Math.Log(0.77 * Math.Abs(scaleFactor) + 1);
        Random rnd = new Random();
        int index = 12;
        steplength /= slowModeScale;
        Func<Complex, Complex> arc = _context.Compile<Func<Complex, Complex>>(function, "z");
        using (var fs = new StreamWriter("savefile.txt", true))
        {
            for (double theta = -Math.Tau; theta <= Math.Tau; theta += steplength)
            {
                complex point = arc(ToComplex(modulusLimit*Math.Cos(theta),modulusLimit*Math.Sin(theta)));
                point *= scaleFactor;
                if (color.ToLower() == "noise")
                {
                    fs.WriteLine($"{partType},{rnd.Next(12,120)},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(color.ToLower() == "order")
                {
                    if (index == 120) index = 12;
                    fs.WriteLine($"{partType},{index},{(int)(point.Real+Convert.ToDouble(coords[0]))},{(int)(point.Imaginary+Convert.ToDouble(coords[1]))},{rotation},0");
                }
                else if(IsIt<int>(color))
                {
                    fs.WriteLine(
                        $"{partType},{color},{(int)(point.Real + Convert.ToDouble(coords[0]))},{(int)(point.Imaginary + Convert.ToDouble(coords[1]))},{rotation},0");
                }

                index++;
            }

            if (plotOrigin)
            {
                fs.WriteLine($"\n1,0,{Convert.ToInt32(coords[0])},{Convert.ToInt32(coords[1])},0,0\n");
            }
            fs.Close();
        }
        GC.Collect();
    }
}