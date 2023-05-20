using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using static PixileGoggsUI__RESURRECTION_.ColorStuff;
using static PixileGoggsUI__RESURRECTION_.ComplexLibrary;

namespace PixileGoggsUI__RESURRECTION_;

public partial class ComplexPlot : Window
{
    public ComplexPlot()
    {
        InitializeComponent();
        Epoiuhsdflgkjbwpriougddflkhjbrgiolyhsbvediolusgbhjaer();
        openFileDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|All Files|*.*";
        PlotFunction.Click += PlotComplexFunction;
        SelectPic.Click += SelectPicture;
        DrawPic.Click += DrawPicture;
    }

    private void DrawPicture(object sender, RoutedEventArgs e)
    {
        int width = Src.PixelWidth;
        int height = Src.PixelHeight;
        string[] origin = PicOrigin.Text.Split(',');
        int ox = Convert.ToInt32(origin[0]);
        int oy = Convert.ToInt32(origin[1]);
        int num;
        Color[,] pixels = new Color[width, height];
        BitmapSourceHelper.CopyPixels(Src,pixels,width*4,0);
        if (!EnableTrans.IsChecked??false)
        {
            try
            {
                using StreamWriter fs = new StreamWriter("savefile.txt",true);
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {

                        num = PartFromColor(pixels[x, y], saturationThresholdA: 0.308377f, saturationThresholdB: 0.175667f,
                            litenessThresholdA: 0.999997f, litenessThresholdB: 0.322799f, litenessThresholdC: 0.107773f);
                        if (num >= 0)
                        {
                            fs.WriteLine($"6,{num},{x+ox},{-y+oy},0,0");
                        }
                    }
                }
                fs.WriteLine($"1,0,{ox},{oy},0,0");
                fs.Flush();
                fs.Close();
                MessageBox.Show($"Finished drawing picture");
            }
            catch (Exception exception)
            {
                GC.Collect();
                if (exception is System.IO.IOException)
                {
                    MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                }
            }
        }
        else
        {
            try
            {
                using StreamWriter fs = new StreamWriter("savefile.txt",true);
                Func<Complex, Complex> function = CompileFunc(TransFunction.Text);
                Complex point;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        point = function(Complex.ToComplex(x, -y));
                        num = PartFromColor(pixels[x, y], saturationThresholdA: 0.308377f, saturationThresholdB: 0.175667f,
                            litenessThresholdA: 0.999997f, litenessThresholdB: 0.342799f, litenessThresholdC: 0.077773f);
                        if (num >= 0)
                        {
                            fs.WriteLine($"6,{num},{(int)(point.Real+ox)},{(int)(point.Imaginary+oy)},0,0");
                        }
                    }
                }
                fs.WriteLine($"1,0,{ox},{oy},0,0");
                fs.Flush();
                fs.Close();
                MessageBox.Show($"Finished drawing picture");
                GC.Collect();
            }
            catch (Exception exception)
            {
                GC.Collect();
                if (exception is System.IO.IOException)
                {
                    MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                }
                else
                {
                    MessageBox.Show(exception.Message + "\nplease check and remove invalid inputs", "Error");
                }
            }
        }

    }

    
    
    public static OpenFileDialog openFileDialog = new();
    public static WriteableBitmap Src = new(new BitmapImage(uriSource: new Uri(@"Resources/Images/test.png",UriKind.Relative)));
    
    
    private void SelectPicture(object sender, RoutedEventArgs e)
    {
        BitmapImage bmp = new BitmapImage();
        bool? b = openFileDialog.ShowDialog();
        if (b == true)
        {
            // Open document 
            string filename = openFileDialog.FileName;
            CurrentPic.Text = filename;
            bmp.BeginInit();
            bmp.BaseUri = new Uri(filename,UriKind.Absolute);
            bmp.UriSource = new Uri(filename,UriKind.Absolute);
            bmp.EndInit();
            PicPreview.Source = bmp;
            Src = new WriteableBitmap(bmp);
            GC.Collect();
        }
        
    }

    
    private void PlotComplexFunction(object sender, RoutedEventArgs e)
    {
        if (AlPixileGoggs.IsChecked ?? true)
        {
            if (RbRealAxis.IsChecked ?? true)
            {
                try
                {
                    PlotFunctionRealAxis(CFunction.Text,
                        CColor.Text,
                        OriginCoord.Text,
                        Convert.ToDouble(CScaleFactor.Text),
                        Convert.ToInt32(CRotation.Text),
                        Convert.ToInt32(CPartType.Text),
                        CRealRange.Text,
                        StepLengthSlider.Value,
                        IsPlotOrigin.IsChecked ?? true
                    );
                    MessageBox.Show($"Plotting {CFunction.Text} from Real-Number Axis completed");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error!");
                }
            }
            else if (RbImaginaryAxis.IsChecked ?? false)
            {
                try
                {

                    PlotFunctionImaginaryAxis(CFunction.Text,
                        CColor.Text,
                        OriginCoord.Text,
                        Convert.ToDouble(CScaleFactor.Text),
                        Convert.ToInt32(CRotation.Text),
                        Convert.ToInt32(CPartType.Text),
                        CRealRange.Text,
                        StepLengthSlider.Value,
                        IsPlotOrigin.IsChecked ?? true
                    );

                    MessageBox.Show($"Plotting {CFunction.Text} from Imaginary-Number Axis completed");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error!");
                }
            }
            else if (RbComplexRange.IsChecked ?? false)
            {
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    PlotFunctionRange(CFunction.Text,
                        CColor.Text,
                        OriginCoord.Text,
                        Convert.ToDouble(CScaleFactor.Text),
                        Convert.ToInt32(CRotation.Text),
                        Convert.ToInt32(CPartType.Text),
                        CRealRange.Text,
                        CImRange.Text,
                        Convert.ToDouble(CModRange.Text),
                        Math.Clamp(StepLengthSlider.Value, 0.1, 1.77),
                        IsPlotOrigin.IsChecked ?? true
                    );
                    stopwatch.Stop();
                    MessageBox.Show(
                        $"Plotting {CFunction.Text} in given range completed.\nTook {stopwatch.ElapsedMilliseconds / 1000d} seconds");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error!");
                }
            }
            else if (RbUnitCircle.IsChecked ?? false)
            {
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    PlotFunctionUnitCircle(CFunction.Text,
                        CColor.Text,
                        OriginCoord.Text,
                        Convert.ToDouble(CScaleFactor.Text),
                        Convert.ToInt32(CRotation.Text),
                        Convert.ToInt32(CPartType.Text),
                        Convert.ToDouble(CModRange.Text),
                        StepLengthSlider.Value,
                        IsPlotOrigin.IsChecked ?? true
                    );
                    stopwatch.Stop();
                    MessageBox.Show(
                        $"Plotting {CFunction.Text} in given range completed.\nTook {stopwatch.ElapsedMilliseconds / 1000d} seconds");
                }
                catch (Exception exception)
                {
                    GC.Collect();
                    MessageBox.Show(exception.Message, "Error!");
                }
            }
        }else if (AlMandelbrot.IsChecked ?? false)
        {
            try
            {
                MdbPlot(CompileFunc(CFunction.Text),
                    OriginCoord.Text,
                    Convert.ToInt32(CRotation.Text),
                    CRealRange.Text,
                    CImRange.Text,
                    Convert.ToDouble(CScaleFactor.Text));
            }
            catch (Exception exception)
            {
                GC.Collect();
                MessageBox.Show(exception.Message, "Error!");
            }
        }
    }

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void HideWindow(object sender, MouseButtonEventArgs e)
    {
        Hide();
    }

    private void StepLengthSlider_OnMouseLeave(object sender, MouseEventArgs e)
    {
        double divisor = StepLengthSlider.Value;
        CurrentStepLength.Text = $"Current: {divisor}";
    }

    
}