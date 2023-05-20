using System;

using System.IO;
using System.Windows;
using System.Windows.Input;
using Z.Expressions;
using static PixileGoggsUI__RESURRECTION_.LinearAlgebra;


namespace PixileGoggsUI__RESURRECTION_;

public partial class LinearARender : Window
{
    public bool InRange(double x, double num1, double num2)
    {
        return num1 <= x && x <= num2;
    }

    private void
        Giufkljofiuciheehebhefgnjjidfvjivdjbndcnjfbnjbfnjvicjifvnbmmccnbkdnbmbbnbbvbjbmddvdfvmivmdkokvnmvmdmvbnfnvndf()
    {
        _context.UnregisterAll();
        _context.RegisterType(typeof(LinearAlgebra));
        _context.RegisterType(typeof(Math));
        _context.RegisterType(typeof(Complex));
        _context.RegisterType(typeof(Vector3));
        _context.RegisterType(typeof(Line));
        _context.RegisterType(typeof(Segment));
        _context.RegisterType(typeof(Plane));
        _context.RegisterType(typeof(Triangle));
        _context.RegisterType(typeof(Sphere));
        _context.RegisterStaticMethod(typeof(Array));
    }
    
    private readonly EvalContext _context = new EvalContext();
    public Scene SceneF =new Scene();
    
    public LinearARender()
    {
        InitializeComponent();
        Giufkljofiuciheehebhefgnjjidfvjivdjbndcnjfbnjbfnjvicjifvnbmmccnbkdnbmbbnbbvbjbmddvdfvmivmdkokvnmvmdmvbnfnvndf();
        Help.Click += ShowHelp;
        DrawScene.Click += Draw;
        SceneBox.Text =
            "Line l = new Line(new Vector3(1,7,-8),new Vector3(0,0,1));\n" +
            "scene.Load(l);\n" +
            "Sphere s = new Sphere(new Vector3(0,8,7),7);\n" +
            "scene.Load(s);";
    }

    private void ShowHelp(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(owner: this, 
            "This is a window with a text box which allows you to input c# codes to build a 3d geometric scene in bad piggies.\n" +
            "This window comes with following classes:\n" +
            "1) LinearAlgebra\n" +
            "2) Math\n" +
            "3) Complex\n" +
            "while LinearAlgebra contains geometric objects:\n" +
            "Line, (line, of course, ) Segment, Plane, Triangle, Sphere,\n" +
            "along with a 3-by-3 Matrix" +
            "All geometric object except Plane can be loaded to scene using scene.Load(); command\n" +
            "Examples: \n" +
            "Line l = new Line(new Vector3(1,7,-8),new Vector3(0,0,1));\n" +
            "scene.Load(l);\n" +
            "Sphere s = new Sphere(new Vector3(0,8,7),7);\n" +
            "scene.Load(s);" +
            "//(this is a comment in code)notice that if you want to transform a scene you should always do Matrix3Trans after geometric objects were loaded\n" +
            "scene.Matrix3Trans(new Matrix3(new double[,]{ \n{ 4, 3, 2 }, \n{ 0, 8, 4 }, \n{ 5, 1, 4 } \n}));\n\n\n" +
            "For usages of the class, go to the Help Page on the Main Window.",
            "Introduction to 3d rendering");
    }

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        //var a = new Matrix3(new double[,]{ { 4, 3, 2 }, { 0, 8, 4 }, { 5, 1, 4 } });
        DragMove();
    }

    private void Close(object sender, MouseButtonEventArgs e)
    {/*
        Vector3[] function = new Vector3[1145];
        int index = 0;
        double i = -25;
        while (i<25)
        {
            function.SetValue(new Vector3(i,i*i,i),index);
            index++;
            i += 0.1;
        }*/

        //scene.Load(function);
        Hide();
    }

    

    private void Draw(object sender, RoutedEventArgs routedEventArgs)
    {
        

        try
        {
            GC.Collect();
            using StreamWriter fs = new StreamWriter("savefile.txt",true);
            SceneF.Clear();
            SceneF = _context.Execute<Scene>("GC.Collect();\nScene scene = new Scene();\n"+SceneBox.Text+"\nreturn scene;\n");
            Plane screen = new Plane(new Vector3(0, 0, -1), SceneF.ScreenOffset);
            
            if (Orthographic.IsChecked ?? true)
            {
                /*Matrix3 m = new Matrix3
                {
                    Values = new double[,] {{1,0,0},{0,1,0},{0,0,0}}
                };*/
                foreach (Vector3 vector3 in Scene.Export(SceneF))
                {
                    fs.WriteLine($"6,42,{(int)(vector3.X+SceneF.InGameOffset.X)},{(int)(vector3.Y+SceneF.InGameOffset.Y)},0,0");
                }
            }else if (Perspective.IsChecked ?? false)
            {
                foreach (Vector3 vector3 in Scene.Export(SceneF))
                {
                    if (vector3.Z >= SceneF.ScreenOffset.Z)
                    {
                        Line a = Line.GetLine(SceneF.CameraOffset, vector3);
                        Vector3 v = Plane.GetIntersection(screen, a);
                        //if (InRange(v.Y,-Scene.GetUpFrame(SceneF),Scene.GetUpFrame(SceneF))&&InRange(vector3.X,-Scene.GetLeftFrame(SceneF),Scene.GetLeftFrame(SceneF)))
                        {
                            fs.WriteLine($"6,42,{(int)(v.X+SceneF.InGameOffset.X)},{(int)(v.Y+SceneF.InGameOffset.Y)},0,0");
                        }
                    }
                }
            }
            fs.WriteLine($"1,0,{(int)(SceneF.InGameOffset.X)},{(int)(SceneF.InGameOffset.X)},0,0");
            fs.Close();
        }
        catch (Exception e)
        {
            if (e is IOException)
            {
                MessageBox.Show("Hey! savefile.txt is being used by another process, try again later","Hold it");
                return;
            }

            

            MessageBox.Show(e.ToString(),$"Exception {e.Message}");
            
        }
    }

    private void SceneBox_OnDrop(object sender, DragEventArgs e)
    {
        SceneBox.Text = (string)e.Data.GetData(typeof(string));
    }
}