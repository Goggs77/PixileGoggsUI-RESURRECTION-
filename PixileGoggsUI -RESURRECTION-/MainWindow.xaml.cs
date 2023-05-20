using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Z.Expressions;
using System.Diagnostics;
using System.Globalization;
using static System.Math;
using Path = System.IO.Path;


namespace PixileGoggsUI__RESURRECTION_
{
    



    public partial class MainWindow
    {
        public static readonly decimal dPi = new decimal(3.1415926535897932384626433832);
        public static readonly decimal dE = new decimal(2.718281828459045235360287471);
        public static int Windowindex = 2;
        public static int OperationIndex = 1;
        public static ComplexPlot ComplexPlot = new ComplexPlot();
        public static LinearARender LinearARender = new LinearARender();

        public MainWindow()
        {
            
            InitializeComponent();
            ComplexPlot.Hide();
            TestYFunction.Click += TestFunction;
            TestRFunction.Click += TestPolarFunction;
            TestPFunction.Click += TestParametric;
            TestEquation.Click += TestEquationPlot;
            Plot.Click += PlotAnyMajor;
            Refresh.Click += RefreshList;
            CopyNoBackup.Click += Copy;
            Check.Click += CheckStatus;
            Clear.Click += ClearSaveFile;
            ClearBackup.Click += ClearAllBackup;
            Backup.Click += BackupAll;
            RecClw.Click += DrawRectangleLw;
            DrawText.Click += DrawTextFromInput;
            ViewSaveFileTxt.Click += ViewSaveFile;
            DebugAllParts.Click += TestAllParts;
            OpenComplex.Click += OpenComplexWindow;
            Open3D.Click += Open3DWindow;
            RndS.Click += RandomSs;
            ShapePlotPanel.Visibility = Visibility.Hidden;
            TextRenderPanel.Visibility = Visibility.Hidden;
            GC.KeepAlive(ComplexPlot);
            int index = 1;
            string[] array = new string[256];
            foreach (string file in Directory.EnumerateFiles(
                         @"C:\\Users\" + Environment.UserName +
                         @"\AppData\LocalLow\Rovio\新创Unity\contraptionsB",
                         "*.*"))
            {
                var length = new FileInfo(file).Length;
                double size = Convert.ToDouble(length)/1024d;
                SavesListView.Items.Add(newItem: new { Id = index, Name = Path.GetFileName(file), FileSize = Convert.ToString(size)+"Kb" });
                //File.Copy(Path.GetFullPath(file),@"I:\Goggs\Works\csharp\PixileGoggsUI -RESURRECTION-\PixileGoggsUI -RESURRECTION-\Resources\Backup");
                array.SetValue(file, index);
                index++;
            }//refresh savefile selector
            GC.Collect();

            
        }

        private void RandomSs(object sender, RoutedEventArgs e)
        {
            try
            {
                ShapeLib.RandomShell(
                    new Point2(Convert.ToDouble(RndSx1.Text),
                        Convert.ToDouble(RndSy1.Text)),
                    Convert.ToInt32(RndSize.Text),
                    Convert.ToInt32(RndStep.Text),
                    Convert.ToInt32(RndSeed.Text),
                    Convert.ToInt32(RndSColor.Text),
                    Convert.ToDouble(RndYsf.Text));
            }
            catch (Exception exception)
            {
                if (exception is System.IO.IOException)
                {
                    MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                    return;
                }
                Console.WriteLine(exception);
                MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
            }
        }

        private void Open3DWindow(object sender, RoutedEventArgs e)
        {
            if (LinearARender.IsVisible)
            {
                MessageBox.Show("There exists a same window");
                return;
            }
            else
            {
                LinearARender.Show();
            }
        }

        public void AddItem(string context)
        {
            
            OperationListView.Items.Add(newItem: new
            {
                Id = OperationIndex,
                Name = context
            });
            OperationIndex++;
        }

        private static void OpenComplexWindow(object sender, RoutedEventArgs e)
        {
            if (ComplexPlot.IsVisible)
            {
                MessageBox.Show("There exists a same window");
                return;
            }
            else
            {
                ComplexPlot.Show();
            }
        }

        private static void ViewSaveFile(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            FileView window = new FileView("savefile.txt");
            window.Show();
            GC.Collect();
        }

        public static string TryParseCode(string mathExpr)
        {
            /*string[] termSeparator = {"-","+"};
            string[] terms = mathExpr.Split(termSeprator, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            foreach (string term in terms)
            {
                string first = term
                    .Replace("sin", "Sin")
                    .Replace("cos","Cos")
                    .Replace("tan","Tan")
                    .Replace("cot","Cot")
                    .Replace("%pi","PI")
                    .Replace("%e","E")
                    ;
                if (first.Contains('^'))
                {
                    string[] second = first.Split('^', StringSplitOptions.RemoveEmptyEntries);
                    if (second.Length==1)
                    {
                        throw new InvalidExpressionException();
                    }
                    else
                    if (second.Length == 2)
                    {
                        first = $"Pow({second[0]},{second[1]})";
                    }
                    else
                    if (second.Length == 3)
                    {
                        first = $"Pow({second[0]},Pow({second[1]},{second[2]}))";
                    }
                    else
                    {
                        throw new ArgumentException(message:"Cannot have more than 2 layers of power");
                    }
                }

                result += first;

            }

            return result;*/
            //TODO: make this thing eat math(academical) expression out put c# expressions
            //      e.g. sin(2x)tan(log(x))^x/e ==this==> Pow(Sin(2*x)*Tan(Log(x)),x)/Math.E  (for ∀x∈Double)
            return mathExpr;
        }

        private void DrawTextFromInput(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_5b5PG.IsChecked ?? false)
                {
                    TextEngine5X5.Print5X5Words(TextRenderContent.Text,
                        Convert.ToInt32(TextRenderPixelLimit.Text),
                        Convert.ToInt32(TextRenderStartX.Text),
                        Convert.ToInt32(TextRenderStartY.Text),
                        Convert.ToInt32(TextRenderColor.Text)
                    );
                    OperationListView.Items.Add(newItem: new
                    {
                        Id = OperationIndex,
                        Name =
                            $"[5x5 Text\"{TextRenderContent.Text}\" at ({Convert.ToInt32(TextRenderStartX.Text)},{Convert.ToInt32(TextRenderStartX.Text)}) Color:{Convert.ToDouble(TextRenderColor.Text)}"
                    });
                    OperationIndex++;
                }else if (_9b16PA.IsChecked ?? false)
                {
                    TextEngineAlleX16.PrintAlleX16Words(TextRenderContent.Text,
                        Convert.ToInt32(TextRenderPixelLimit.Text),
                        Convert.ToInt32(TextRenderStartX.Text),
                        Convert.ToInt32(TextRenderStartY.Text),
                        Convert.ToInt32(TextRenderColor.Text)
                    );
                    OperationListView.Items.Add(newItem: new
                    {
                        Id = OperationIndex,
                        Name =
                            $"[9x16 Text\"{TextRenderContent.Text}\" at ({Convert.ToInt32(TextRenderStartX.Text)},{Convert.ToInt32(TextRenderStartX.Text)}) Color:{Convert.ToDouble(TextRenderColor.Text)}"
                    });
                    OperationIndex++;
                }
                else
                {
                    MessageBox.Show("Select a Font!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
            }
            GC.Collect();
        }

        private void DrawRectangleLw(object sender, RoutedEventArgs e)
        {
            try
            {
                ShapeLib.Rectangle(Convert.ToDouble(RecClwX1.Text),
                    Convert.ToDouble(RecClwY1.Text),
                    Convert.ToDouble(RecClwL.Text),
                    Convert.ToDouble(RecClwW.Text),
                    Convert.ToInt32(RecClwColor.Text),
                    Convert.ToInt32(RecClwPt.Text),
                    RecCorFill.IsChecked ?? true);
                OperationListView.Items.Add(newItem: new
                {
                    Id = OperationIndex,
                    Name =
                        $"Rectangle {Convert.ToDouble(RecClwX1.Text)},{Convert.ToDouble(RecClwY1.Text)},{Convert.ToDouble(RecClwL.Text)},{Convert.ToDouble(RecClwW.Text)},{RecCorFill.IsChecked ?? true}"
                });
                OperationIndex++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageBoxText:ex+"\nPlease check and remove any invalid inputs!","Error!");
            }
            GC.Collect();
        }
        private void TestEquationPlot(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Canvas.Children.Clear();
            Canvas.MaxWidth = 158;
            Etp.Text = $"ETP: unavailable";
            double left;
            double right;
            PointCollection points = new PointCollection();
            try
            {
                var xrange = EquationXRange.Text.Split(',');
                var yrange = EquationYRange.Text.Split(',');
                bool isLeftVar = EquationLeft.Text.Contains('x') || EquationLeft.Text.Contains('y');
                bool isRightVar = EquationRight.Text.Contains('x') || EquationRight.Text.Contains('y');
                Func<double, double, double> delL;
                Func<double, double, double> delR;
                if (isLeftVar)
                {
                    delL = Eval.Compile<Func<double, double, double>>(EquationLeft.Text, "x", "y");
                }
                else
                {
                    delL = delegate { return Convert.ToDouble(EquationLeft.Text); };
                }
                if (isRightVar)
                {
                    delR = Eval.Compile<Func<double, double, double>>(EquationRight.Text, "x", "y");
                }
                else
                {
                    delR = delegate { return Convert.ToDouble(EquationRight.Text); };
                }

                for (double y = Convert.ToDouble(yrange[0]); Convert.ToDouble(yrange[0]) <= y && y <= Convert.ToDouble(yrange[1]); y+=0.1)
                {
                    for (double x = Convert.ToDouble(xrange[0]); Convert.ToDouble(xrange[0]) <= x && x <= Convert.ToDouble(xrange[1]); x+=0.1)
                    {
                    
                        left = delL(x, y);
                        right = delR(x, y);
                        if (Abs((left / right)-1) <= Convert.ToDouble(Threshold.Text))
                        {
                            points.Add(new Point(x*Convert.ToInt32(EquationScaleFactor.Text)+79, -y*Convert.ToInt32(EquationScaleFactor.Text)+195));
                            //same as fs.WriteLine(......);
                        }
                    }
                    GC.Collect();
                }
            }
            catch (Exception exception)
            {
                if (exception.Source == "Z.Expressions.Eval")
                {
                    MessageBox.Show(e.ToString(),$"Expired!");
                }
                //ignored as real number isn't closures
            }

            var line = new Polyline
            {
                Stroke = Brushes.RoyalBlue,
                MaxHeight = 302,
                MinHeight = 0,
                MaxWidth = 158,
                StrokeThickness = 1.37,
                Points = points
            };
            Canvas.Children.Add(line);
            GC.Collect();
        }

        private void TestParametric(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Canvas.Children.Clear();
            Canvas.MaxWidth = 158;
            double steplength = 0.771 / (0.77 * Pow((0.114514d*Convert.ToDouble(PScaleFactor.Text + 1)),E/2));
            if (SlowMode.IsChecked ?? false)
            {
                steplength /= 20d;
            }

            Etp.Text = $"ETP: {(long)((Convert.ToDouble(UpperLimit.Text)-Convert.ToDouble(LowerLimit.Text))/steplength)}part(s)";
            PointCollection points = new PointCollection();
            //PointCollection correction = new PointCollection();
            double x;
            string xfunc = TryParseCode(XpFunction.Text);
            string yfunc = TryParseCode(YpFunction.Text);
            //int index = 0;
            Polyline line = new Polyline
            {
                Stroke = Brushes.RoyalBlue,
                Fill = Brushes.AliceBlue,
                MaxHeight = 302,
                MinHeight = 0,
                MaxWidth = 158,
                StrokeThickness = 1.37
            };

            for ( x = -51; x <= 51; x += 0.03f)
            {
                try
                {
                    decimal px = Eval.Execute<decimal>(xfunc, new {t=x})*Convert.ToInt32(PScaleFactor.Text)+79;
                    decimal py = -Eval.Execute<decimal>(yfunc, new {t=x})*Convert.ToInt32(PScaleFactor.Text)+195;
                    Point p = new Point((int)px, (int)py);
                    if (px >= 0)
                    {
                        points.Add(p);
                    }
                }
                catch (Exception exception)
                {
                    if (exception.Source == "Z.Expressions.Eval")
                    {
                        MessageBox.Show(e.ToString(),$"Expired!");
                    }
                    
                }
                
            }
            if(PlotOrigin != null && (bool)PlotOrigin.IsChecked)
            {
                Canvas.Children.Add(new Line {Stroke = Brushes.GreenYellow,Fill = Brushes.GreenYellow, X1 = 79, Y1 = 195, X2 = 79, Y2 = 195, StrokeThickness = 6});
            }
            line.Points = points;
            Canvas.Children.Add(line);
        }

        private void TestPolarFunction(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Canvas.Children.Clear();
            double steplength = 0.771 / (0.77 * Pow((0.114514d*Convert.ToDouble(RScaleFactor.Text + 1)),E/2));
            if (SlowMode.IsChecked ?? false)
            {
                steplength /= 20d;
            }

            Etp.Text = $"ETP: {(long)((Convert.ToDouble(UpperLimit.Text)-Convert.ToDouble(LowerLimit.Text))/steplength)}part(s)";
            PointCollection points = new PointCollection();
            //PointCollection correction = new PointCollection();
            double x;
            string func = TryParseCode(RFunction.Text);
            //int index = 0;
            Polyline line = new Polyline
            {
                Stroke = Brushes.RoyalBlue,
                Fill = Brushes.AliceBlue,
                MaxHeight = 302,
                MinHeight = 0,
                MaxWidth = 158,
            };

            for ( x = -51; x <= 51; x += 0.01f)
            {
                try
                {
                    decimal radius = (Eval.Execute<decimal>(func, new { a = x }) *
                                   Convert.ToInt32(RScaleFactor.Text));
                    
                    
                        decimal px = radius*(decimal)Cos(x)+79;
                        decimal py = (decimal)-Sin(x)*radius+195;
                        Point p = new Point((double)px, (double)py);
                        points.Add(p);
                    
                }
                catch (Exception exception)
                {
                    if (exception.Source == "Z.Expressions.Eval")
                    {
                        MessageBox.Show(e.ToString(),$"Expired!");
                    }
                    
                }
                
            }
            
            line.Points = points;
            Canvas.Children.Add(line);
            GC.Collect();
        }

        

        private bool _isCleared = true;
        private void ClearAllBackup(object sender, RoutedEventArgs e)
        {
            if (!_isCleared)
            {
                
                Directory.Delete(
                    new Uri("Resources/Backup",UriKind.Relative).ToString(),
                    true);
                Directory.CreateDirectory(
                    new Uri("Resources/Backup",UriKind.Relative).ToString());
                _isCleared = true;
                MessageBox.Show("Cleared all backups");
            }
            else
            {
                MessageBox.Show("No backups to clean");
            }
        }

        private void ClearSaveFile(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Delete("savefile.txt");
                File.Create("savefile.txt");
                OperationListView.Items.Clear();
                OperationIndex = 1;
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

        private static void CheckStatus(object sender, RoutedEventArgs e)
        {
            var length = new FileInfo("savefile.txt");
            GC.Collect();
            MessageBox.Show($"Current savefile.txt's size is {length.Length/1024d} kb\nAbout {(int)(length.Length/23d)} Parts", "Status");
            
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            if (SavesListView.SelectedIndex == -1)
            {
                return; 
            }

            int fileindex = SavesListView.SelectedIndex;
            SavesListView.Items.Clear();
            int index = 1;
            string[] array = new string[256];
            foreach (string file in Directory.EnumerateFiles(
                         @"C:\\Users\" + Environment.UserName +
                         @"\AppData\LocalLow\Rovio\新创Unity\contraptionsB",
                         "*.*"))
            {
                var length = new FileInfo(file).Length;
                double size = Convert.ToDouble(length)/1024d;
                SavesListView.Items.Add(newItem: new { Id = index, Name = Path.GetFileName(file), FileSize = Convert.ToString(size)+"Kb" });
                //File.Copy(Path.GetFullPath(file),@"I:\Goggs\Works\csharp\PixileGoggsUI -RESURRECTION-\PixileGoggsUI -RESURRECTION-\Resources\Backup");
                //string backup = Library.RandomString(7);
                //Not needed backup code
                //Remained scan \ refresh
                //File.Copy(file, @$"I:\Goggs\Works\csharp\PixileGoggsUI -RESURRECTION-\PixileGoggsUI -RESURRECTION-\Resources\Backup\{dir}\{backup}.txt");
                array.SetValue(file, index);
                index++;
            }

            try
            {
                File.Delete(array[fileindex+1]);
            }
            catch (Exception exception)
            {
                if (exception is System.IO.IOException)
                {
                    MessageBox.Show($"Hey! {array[fileindex+1]} is being used by another process, try again later","Hold it");
                }
            }
            File.Copy("savefile.txt",array[fileindex+1]);
            MessageBox.Show("Copy completed", "Completed");
            RefreshList(sender,e);
            

        }

        private void BackupAll(object sender, RoutedEventArgs e)
        {
            SavesListView.Items.Clear();
            int index = 1;
            string dir = Library.RandomString(9);
            Directory.CreateDirectory(
                new Uri($"Resources/Backup/{dir}",UriKind.Relative).ToString());
            string[] array = new string[256];
            foreach (string file in Directory.EnumerateFiles(
                         @"C:\\Users\" + Environment.UserName +
                         @"\AppData\LocalLow\Rovio\新创Unity\contraptionsB",
                         "*.*"))
            {
                var length = new FileInfo(file).Length;
                double size = Convert.ToDouble(length)/1024d;
                SavesListView.Items.Add(newItem: new { Id = index, Name = Path.GetFileName(file), FileSize = Convert.ToString(size)+"Kb" });
                //File.Copy(Path.GetFullPath(file),@"I:\Goggs\Works\csharp\PixileGoggsUI -RESURRECTION-\PixileGoggsUI -RESURRECTION-\Resources\Backup");
                string backup = Library.RandomString(7);
                
                
                File.Copy(file, new Uri($"Resources/Backup/{dir}/{backup}",UriKind.Relative).ToString());
                array.SetValue(file, index);
                index++;
            }

            _isCleared = false;
            MessageBox.Show("Backed up every saves");
        }

        public void RefreshList(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            SavesListView.Items.Clear();
            int index = 1;
            string[] array = new string[256];
            foreach (string file in Directory.EnumerateFiles(
                         @"C:\\Users\" + Environment.UserName +
                         @"\AppData\LocalLow\Rovio\新创Unity\contraptionsB",
                         "*.*"))
            {
                var length = new FileInfo(file).Length;
                double size = Convert.ToDouble(length)/1024d;
                SavesListView.Items.Add(newItem: new { Id = index, Name = Path.GetFileName(file), FileSize = Convert.ToString(size, CultureInfo.CurrentCulture)+"Kb" });
                //File.Copy(Path.GetFullPath(file),@"I:\Goggs\Works\csharp\PixileGoggsUI -RESURRECTION-\PixileGoggsUI -RESURRECTION-\Resources\Backup");
                array.SetValue(file, index);
                index++;
            }
        }

        

        private void PlotAnyMajor(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            var ti = (PlottingPanel.SelectedItem as TabItem)!;
            switch ((string)ti.Header)
            {
                case "Function Plotting":
                    try
                    {
                        Library.FunctionMaker(TryParseCode(YFunction.Text),
                            Color.Text,
                            Convert.ToInt32(YOriginX.Text),
                            Convert.ToInt32(YOriginY.Text),
                            Convert.ToDouble(YScaleFactor.Text),
                            Convert.ToInt32(Rotation.Text),
                            Convert.ToInt32(PartType.Text),
                            Convert.ToDouble(UpperLimit.Text),
                            Convert.ToDouble(LowerLimit.Text),
                            PlotOrigin.IsChecked ?? true,
                            SlowMode.IsChecked ?? false);
                        OperationListView.Items.Add(newItem: new
                        {
                            Id = OperationIndex,
                            Name =
                                $"y={YFunction.Text} at ({Convert.ToInt32(YOriginX.Text)},{Convert.ToInt32(YOriginY.Text)}) Size factor:{Convert.ToDouble(YScaleFactor.Text)}"
                        });
                        OperationIndex++;
                        MessageBox.Show($"Plotting y={YFunction.Text} Completed", "Completed");
                    }
                    catch (Exception exception)
                    {
                        if (exception is System.IO.IOException)
                        {
                            MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                        }
                        Console.WriteLine(exception);
                        MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
                    }

                    break;
                case "Polar Function Plotting":
                    try
                    {
                        Library.PolarPlot(TryParseCode(RFunction.Text),
                            Color.Text,
                            Convert.ToInt32(ROriginX.Text),
                            Convert.ToInt32(ROriginY.Text),
                            Convert.ToDouble(RScaleFactor.Text),
                            Convert.ToInt32(Rotation.Text),
                            Convert.ToInt32(PartType.Text),
                            SlowMode.IsChecked ?? false,
                            PlotOrigin.IsChecked ?? true,
                            Convert.ToDouble(UpperLimit.Text),
                            Convert.ToDouble(LowerLimit.Text));
                        OperationListView.Items.Add(newItem: new
                        {
                            Id = OperationIndex,
                            Name =
                                $"r={RFunction.Text} at ({Convert.ToInt32(ROriginX.Text)},{Convert.ToInt32(ROriginY.Text)}) Size factor:{Convert.ToDouble(RScaleFactor.Text)}"
                        });
                        OperationIndex++;
                        MessageBox.Show($"Plotting r={RFunction.Text} Completed", "Completed");
                    }
                    catch (Exception exception)
                    {
                        if (exception is System.IO.IOException)
                        {
                            MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                        }
                        Console.WriteLine(exception);
                        MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
                        
                    }

                    break;
                case "Parametric Function Plotting":
                    try
                    {
                        Library.ParametricEq(TryParseCode(XpFunction.Text),
                            TryParseCode(YpFunction.Text),
                            Color.Text,
                            Convert.ToInt32(POriginX.Text),
                            Convert.ToInt32(POriginY.Text),
                            Convert.ToDouble(PScaleFactor.Text),
                            Convert.ToInt32(Rotation.Text),
                            Convert.ToInt32(PartType.Text),
                            PlotOrigin.IsChecked ?? true,
                            SlowMode.IsChecked ?? false,
                            Convert.ToDouble(UpperLimit.Text),
                            Convert.ToDouble(LowerLimit.Text));
                        OperationListView.Items.Add(newItem: new
                        {
                            Id = OperationIndex,
                            Name =
                                $"[x={XpFunction.Text},y={YpFunction.Text}] at ({Convert.ToInt32(POriginX.Text)},{Convert.ToInt32(POriginY.Text)}) Size factor:{Convert.ToDouble(PScaleFactor.Text)}"
                        });
                        OperationIndex++;
                        MessageBox.Show($"Plotting x={XpFunction.Text}, y={YpFunction.Text} Completed", "Completed");
                    }
                    catch (Exception exception)
                    {
                        if (exception is System.IO.IOException)
                        {
                            MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                        }
                        Console.WriteLine(exception);
                        MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
                    }

                    break;
                case "Equation Plotting":
                    try
                    {
                        Stopwatch s = Stopwatch.StartNew();
                        Library.EquationPlot(EquationLeft.Text,
                            EquationRight.Text,
                            Color.Text,
                            Convert.ToInt32(EquationX1.Text),
                            Convert.ToInt32(EquationY1.Text),
                            Convert.ToDouble(EquationScaleFactor.Text),
                            Convert.ToInt32(Rotation.Text),
                            Convert.ToInt32(PartType.Text),
                            PlotOrigin.IsChecked ?? true,
                            SlowMode.IsChecked ?? false,
                            EquationXRange.Text,
                            EquationYRange.Text,
                            Convert.ToDouble(Threshold.Text));
                        s.Stop();
                        OperationListView.Items.Add(newItem: new
                        {
                            Id = OperationIndex,
                            Name =
                                $"{EquationLeft.Text}={EquationRight.Text} at ({Convert.ToInt32(YOriginX.Text)},{Convert.ToInt32(YOriginY.Text)}) Size factor:{Convert.ToDouble(YScaleFactor.Text)}"
                        });
                        OperationIndex++;
                        MessageBox.Show($"Plotting {EquationLeft.Text}={EquationRight.Text} Completed\nTook {s.ElapsedMilliseconds/1000d} seconds", "Completed");
                    }
                    catch (Exception exception)
                    {
                        if (exception is System.IO.IOException)
                        {
                            MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                        }
                        Console.WriteLine(exception);
                        MessageBox.Show(messageBoxText:exception+"\nPlease check and remove any invalid inputs!","Error!");
                    }
                    break;
            }
        }

        private bool _isPlaying;
        private bool _isLoaded;
        private MediaPlayer _mp = new MediaPlayer();
        private void Stasis(object sender, MouseButtonEventArgs e)
        {
            GC.Collect();
            if (_isPlaying || _mp.Position == TimeSpan.MaxValue)
            {
                _mp.Pause();
                _isPlaying = false;
            }
            else
            {
                _isPlaying = true;
                if (!_isLoaded)
                {
                    _mp.Open(new Uri(@"Resources/Stasis/Stasis.mp3", UriKind.Relative));
                    _isLoaded = true;
                }
                _mp.Play();
            }
        }

        private void TestFunction(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            Canvas.Children.Clear();
            double steplength = 0.022 / 0.77 * Log(0.77 * Convert.ToDouble(YScaleFactor.Text) + 1);
            long parts = Convert.ToInt64((Convert.ToDouble(UpperLimit.Text) - Convert.ToDouble(LowerLimit.Text)) / steplength);
            Etp.Text = $"ETP: {parts}part(s)";
            PointCollection points = new PointCollection();
            //PointCollection correction = new PointCollection();
            float x;
            //int index = 0;
            Polyline line = new Polyline
            {
                Stroke = Brushes.RoyalBlue,
                Fill = Brushes.AliceBlue,
                MaxHeight = 302,
                MinHeight = 0,
                MaxWidth = 158,
            };
            string func = TryParseCode(YFunction.Text);
            for ( x = -51; x <= 51; x += 0.06f)
            {
                try
                {
                    decimal px = new decimal(Round(6*x+79));
                    decimal py = Round(Eval.Execute<decimal>(func, new { x }) *-6*
                        Convert.ToInt32(YScaleFactor.Text)+195);
                    Point p = new Point((double)px, (double)py);
                    //if (py is < 286 and > 0)
                    points.Add(p);
                    //  line.X1 = px;
                    //  line.X2 = MathF.Round(x+50);
                    //  line.Y1 = py;
                    //  line.Y2 = MathF.Round(Eval.Execute<float>(YFunction.Text, new { x = x+1.618 })*
                    //      Convert.ToInt32(YScaleFactor.Text)+100);
                    //  line.Stroke=Brushes.RoyalBlue;
                    //  line.StrokeThickness = 10;
                    //  Canvas.Children.Add(line);
                    
                    // //else
                    // {
                    //     //correction.Add(p);
                    //     //xs.SetValue(x,index);
                    //     index++;
                    // }

                }
                catch (Exception exception)
                {
                    //
                }
                
            }
        
            /*Line correction = new Line();
            correction.X1 =  xs.Min()+25;
            correction.X2 =  xs.Max()+25;
            correction.Y1 = MathF.Round(Eval.Execute<float>(YFunction.Text, new { x = xs.Min()}) * -.06f *
                Convert.ToInt32(YScaleFactor.Text) + 156f);
            correction.Y1 = MathF.Round(Eval.Execute<float>(YFunction.Text, new { x = xs.Max()}) * -.06f *
                Convert.ToInt32(YScaleFactor.Text) + 156f);
            correction.Fill = Brushes.Black;
            correction.Stroke = Brushes.Black;
            correction.StrokeThickness = 10;*/
            //Correction.Points = correction;
            line.Points = points;
            Canvas.Children.Add(line);
            
        }
        /*public void RefreshConfig(object sender, RoutedEventArgs e)
        {
            string MaxPart = ConfigurationManager.AppSettings["MaxParts"] ?? "20000";
            string MinStepLength = ConfigurationManager.AppSettings["MinStepLength"] ?? "0.0001";
            string UpperLimit = ConfigurationManager.AppSettings["UpperLimit"] ?? "200.0";
            string LowerLimit = ConfigurationManager.AppSettings["LowerLimit"] ?? "-200.0";
            string DesiredStepLength = ConfigurationManager.AppSettings["DesiredStepLength"] ?? "default";
            string SuperSecretInformationThatYouWillNeverFindOrRead = ConfigurationManager.AppSettings["SuperSecretInformationThatYouWillNeverFindOrRead"] ?? "default";
        }*/

        private void About(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(HelpStrings.About,"About this program");
            
        }

        private void Switch(object sender, MouseButtonEventArgs e)
        {
            if (Windowindex % 3 == 1)
            {
                MajorPlotPanel.Visibility = Visibility.Visible;
                ShapePlotPanel.Visibility = Visibility.Hidden;
                TextRenderPanel.Visibility = Visibility.Hidden;
                Windowindex++;
            }
            else if(Windowindex % 3 == 2)
            {
                MajorPlotPanel.Visibility = Visibility.Hidden;
                ShapePlotPanel.Visibility = Visibility.Visible;
                TextRenderPanel.Visibility = Visibility.Hidden;
                Windowindex++;
            }
            else if(Windowindex % 3 == 0)
            {
                TextRenderPanel.Visibility = Visibility.Visible;
                MajorPlotPanel.Visibility = Visibility.Hidden;
                ShapePlotPanel.Visibility = Visibility.Hidden;
                Windowindex++;
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            InstructionBox.Text =
                "Available Functions:    \n" +
                "Abs()                   \n" +
                "Acos()                  \n" +
                "Acosh()                 \n" +
                "Asin()                  \n" +
                "Asinh()                 \n" +
                "Atan()                  \n" +
                "Atan2()                 \n" +
                "Atanh()                 \n" +
                "BigMul()                \n" +
                "BitDecrement()          \n" +
                "BitIncrement()          \n" +
                "Cbrt()                  \n" +
                "Ceiling()               \n" +
                "Clamp()                 \n" +
                "CopySign()              \n" +
                "Cos()                   \n" +
                "Cosh()                  \n" +
                "DivRem()                \n" +
                "Exp()                   \n" +
                "Floor()                 \n" +
                "FusedMultiplyAdd()      \n" +
                "IEEERemainder()         \n" +
                "ILogB()                 \n" +
                "Log()                   \n" +
                "Log10()                 \n" +
                "Log2()                  \n" +
                "Max()                   \n" +
                "MaxMagnitude()          \n" +
                "Min()                   \n" +
                "MinMagnitude()          \n" +
                "Pow()                   \n" +
                "ReciprocalEstimate()    \n" +
                "ReciprocalSqrtEstimate()\n" +
                "Round()                 \n" +
                "ScaleB()                \n" +
                "Sign()                  \n" +
                "Sin()                   \n" +
                "SinCos()                \n" +
                "Sinh()                  \n" +
                "Sqrt()                  \n" +
                "Tan()                   \n" +
                "Tanh()                  \n" +
                "Truncate()              \n" +
                "Constant Table:         \n" +
                "E                       \n" +
                "PI                      \n";
        }

        
        
        public void TestAllParts(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            MessageBoxResult result = MessageBox.Show("This action will delete all parts from current savefile.txt!\n" +
                                                      "Proceed?", "Warning!", MessageBoxButton.YesNo,
                MessageBoxImage.Exclamation);
            if (result != MessageBoxResult.Yes) return;
            OperationIndex = 1;
            OperationListView.Items.Clear();
            File.WriteAllText("savefile.txt",
                File.ReadAllText(@"Resources/Stasis/AllPartsAllTypes"));
            GC.Collect();
        }

        private void MainBoarder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void Help(object sender, RoutedEventArgs e)
        {
            HelpPage help = new HelpPage();
            help.Show();
        }

        private void Quit(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SavesListView_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SavesListView.SelectedIndex == -1)
            {
                return; 
            }

            int fileindex = SavesListView.SelectedIndex;
            SavesListView.Items.Clear();
            int index = 1;
            string[] array = new string[256];
            foreach (string file in Directory.EnumerateFiles(
                         @"C:\\Users\" + Environment.UserName +
                         @"\AppData\LocalLow\Rovio\新创Unity\contraptionsB",
                         "*.*"))
            {
                var length = new FileInfo(file).Length;
                double size = Convert.ToDouble(length)/1024d;
                SavesListView.Items.Add(newItem: new { Id = index, Name = Path.GetFileName(file), FileSize = Convert.ToString(size)+"Kb" });
                
                array.SetValue(file, index);
                index++;
            }

            FileView view = new FileView(array[fileindex + 1]);
            view.Show();
        }
    }
}