using System;
using static PixileGoggsUI__RESURRECTION_.LinearAlgebra;
using static PixileGoggsUI__RESURRECTION_.LinearAlgebra.Vector3;
using static PixileGoggsUI__RESURRECTION_.LinearAlgebra.Line;
using Line = PixileGoggsUI__RESURRECTION_.LinearAlgebra.Line;

namespace PixileGoggsUI__RESURRECTION_;

public class LinearAlgebra
{
    public enum PositionRelations
    {
        Intersect,
        Contain,
        Parallel,
        Skew,
        NotAvailable,
    }
    
    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector3 Up()
        {
            return new Vector3(0, 0, 1);
        }
        public static Vector3 Down()
        {
            return new Vector3(0, 0, -1);
        }
        public static Vector3 North()
        {
            return new Vector3(0, 1, 0);
        }
        public static Vector3 South()
        {
            return new Vector3(0, -1, 0);
        }
        public static Vector3 East()
        {
            return new Vector3(1, 0, 0);
        }
        public static Vector3 West()
        {
            return new Vector3(-1, 0, 0);
        }

        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }

        public static Vector3 Normalize(Vector3 a)
        {
            return a / Abs(a);
        }

        public static Vector3 Extends(Vector3 v, double length)
        {
            /*
            double xSlope = v.Z / v.X;
            double ySlope = v.Z / v.Y;
            double deltaX = length / Math.Sqrt(ySlope * ySlope + 1) / Math.Sqrt(xSlope * xSlope + 1);
            double deltaY = Math.Sqrt(Math.Pow(length / Math.Sqrt(ySlope * ySlope + 1),2)-deltaX*deltaX);
            double deltaZ = Math.Sqrt(Math.Abs(length * length - deltaX * deltaX - deltaY - deltaY));
            if (xSlope >= 0 && ySlope >= 0)
            {
                return new Vector3 { X = v.X + deltaX, Y = v.Y + deltaY, Z = v.Z + deltaZ };
            }
            else if (xSlope <= 0 && ySlope >= 0)
            {
                return new Vector3 { X = v.X + deltaX, Y = v.Y + deltaY, Z = v.Z - deltaZ };
            }
            else if (xSlope <= 0 && ySlope >= 0)
            {
                return new Vector3 { X = v.X - deltaX, Y = v.Y - deltaY, Z = v.Z - deltaZ };
            }
            else if (xSlope <= 0 && ySlope <= 0)
            {
                return new Vector3 { X = v.X - deltaX, Y = v.Y - deltaY, Z = v.Z + deltaZ };
            }
            else if (xSlope == 0 && ySlope == 0)
            {
                return new Vector3 { X = v.X - deltaX, Y = v.Y - deltaY, Z = 0 };
            }

            return v;
            //bruh i've been wasting time on this s**t for days while forgetting **similarity**
            */
            double ratio = Abs(v) + length / Abs(v);
            return ratio*v;
        }

        

        public static double Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static double Abs(Vector3 a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
        }

        public static double Angle(Vector3 a, Vector3 b)
        {
            return Math.Acos(Dot(a, b) / Abs(a) * Abs(b));
        }

        public static double SqrMagnitude(Vector3 a)
        {
            return a.X * a.X + a.Y * a.Y + a.Z * a.Z;
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, double t)
        {
            t = Math.Clamp(t,0,1);
            return new Vector3(
                a.X + (b.X - a.X) * t,
                a.Y + (b.Y - a.Y) * t,
                a.Z + (b.Z - a.Z) * t
            );
        }
        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            double sqrMag = Dot(onNormal, onNormal);
            if (sqrMag == 0) return Zero();
            else
            {
                var dot = Dot(vector, onNormal);
                return new Vector3(onNormal.X * dot / sqrMag,
                    onNormal.Y * dot / sqrMag,
                    onNormal.Z * dot / sqrMag);
            }
        }
        public static bool Perpendicular(Vector3 a, Vector3 b)
        {
            return Dot(a, b) == 0;
        }
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3 { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
        public static Vector3 Opposite(Vector3 a)
        {
            return new Vector3 { X = -a.X, Y = -a.Y, Z = -a.Z };
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return a + Opposite(b);
        }
        public static Vector3 operator * (double a, Vector3 b)
        {
            return new Vector3 { X = a*b.X, Y = a*b.Y, Z = a*b.Z };
        }
        public static Vector3 operator / (Vector3 a, double b)
        {
            return new Vector3 { X = a.X/b, Y = a.Y/b, Z = a.Z/b };
        }
        public static double Distance(Vector3 intersection, Vector3 line1Distance)
        {
            return Math.Sqrt((intersection.X - line1Distance.X) *
                             (intersection.X - line1Distance.X) +
                             (intersection.Y - line1Distance.Y) *
                             (intersection.Y - line1Distance.Y) +
                             (intersection.Z - line1Distance.Z) *
                             (intersection.Z - line1Distance.Z));
        }
    }

    public struct Matrix
    {
        public double[,] Values;

        public Matrix(int rows, int columns)
        {
            Values = new double[rows, columns];
        }
        
    }
    public struct Matrix3 
    {
        public double[,] Values = new double[3,3];

        public Matrix3(double[,] doubles)
        {
            Values = doubles;
        }
        public static Vector3 operator * (Vector3 a, Matrix3 b)
        {
            Vector3 f = new Vector3(b.Values[0, 0] * a.X, b.Values[0, 1] * a.Y, b.Values[0, 2] * a.Z);
            Vector3 g = new Vector3(b.Values[1, 0] * a.X, b.Values[1, 1] * a.Y, b.Values[1, 2] * a.Z);
            Vector3 h = new Vector3(b.Values[2, 0] * a.X, b.Values[2, 1] * a.Y, b.Values[2, 2] * a.Z);
            return f + g + h;
        }

        
    }
    public struct Plane
    {
        public Vector3 Normal;
        public Vector3 Point;

        public Plane(Vector3 normal, Vector3 distance)
        {
            this.Normal = normal;
            this.Point = distance;
        }
        /*
        public Plane GetPlane(Vector3 v1, Vector3 v2)
        {
            Vector3 normal = Vector3.Cross(v1, v2);
            double distance = -Vector3.Dot(normal, new Vector3(0, 0, 0));
            return new Plane(normal, distance);
        }*/

        public static PositionRelations GetPositionRelation(Line a, Plane b)
        {
            return !Perpendicular(a.Direction, b.Normal) ? PositionRelations.Intersect : PositionRelations.Parallel;
        }

        public static Vector3 GetIntersection(Plane a, Line b)
        {
            double d = Dot((a.Point - b.Point), a.Normal) / (Dot(b.Direction, a.Normal));
            return b.Point + d * b.Direction;



        }
    }
    public struct Line
    {
        public Vector3 Direction;
        public Vector3 Point;

        public static Vector3[] ToVector3Array(Line l)
        {
            Vector3[] vector3S = new Vector3[65536];
            int arrayIndex = 0;
            for (double i = -30; i <= 30; i+=1d)
            {
                vector3S.SetValue(Extends(l.Direction,i)+l.Point,arrayIndex);
                arrayIndex++;
            }
            Array.Resize(ref vector3S,arrayIndex+1);
            return vector3S;
        }
        

        public Line(Vector3 direction, Vector3 point)
        {
            this.Direction = direction;
            this.Point = point;
        }

        public static PositionRelations GetPositionRelation(Line a, Line b)
        {
            if (Equals(a.Direction,b.Direction))
            {
                return Equals(a.Point, b.Point) ? PositionRelations.Contain : PositionRelations.Parallel;
            }
            if (Intersect(a, b))
            {
                return PositionRelations.Intersect;
            }

            return PositionRelations.Skew;
        }
        public static bool Intersect(Line line1, Line line2, out Vector3 intersection)
        {
            intersection = Vector3.Zero();

            // Calculate the normal vector cross product
            Vector3 cross = Vector3.Cross(line1.Direction, line2.Direction);

            // Check if the lines are parallel
            if (SqrMagnitude(cross) < double.Epsilon)
            {
                return false;
            }

            // Calculate the intersection point
            double t = -Vector3.Dot(line1.Direction, line1.Point) / Vector3.Dot(line1.Direction, line2.Direction);
            intersection = line2.Point + t * line2.Direction;

            // Check if the intersection point lies on both lines
            if (Vector3.Distance(intersection, line1.Point + Vector3.Project(intersection - line1.Point, line1.Direction)) > double.Epsilon)
            {
                return false;
            }
            if (Vector3.Distance(intersection, line2.Point + Vector3.Project(intersection - line2.Point, line2.Direction)) > double.Epsilon)
            {
                return false;
            }

            return true;
        }
        public static bool Intersect(Line line1, Line line2)
        {
            // Calculate the normal vector cross product
            Vector3 cross = Vector3.Cross(line1.Direction, line2.Direction);

            // Check if the lines are parallel
            if (SqrMagnitude(cross) < double.Epsilon)
            {
                return false;
            }

            // Calculate the intersection point
            double t = -Vector3.Dot(line1.Direction, line1.Point) / Vector3.Dot(line1.Direction, line2.Direction);
            Vector3 intersection = line2.Point + t * line2.Direction;

            // Check if the intersection point lies on both lines
            if (Vector3.Distance(intersection, line1.Point + Vector3.Project(intersection - line1.Point, line1.Direction)) > double.Epsilon)
            {
                return false;
            }
            if (Vector3.Distance(intersection, line2.Point + Vector3.Project(intersection - line2.Point, line2.Direction)) > double.Epsilon)
            {
                return false;
            }

            return true;
        }

        public static Line GetLine(Vector3 a, Vector3 b)
        {
            return new Line(Normalize(b - a), a);
        }
    }
}

public struct Segment
{
    public Line Line;
    public double Length;
    
    public Segment(Line a, double length)
    {
        Line = a;
        Length = length;
    }
    public static Segment GetSegment(Vector3 a, Vector3 b)
    {
        double l = Abs(b - a);
        return new Segment(new Line(Normalize(b - a), a),l);
    }
    public static Vector3[] ToVector3Array(Segment l)
    {
        Vector3[] vector3S = new Vector3[65536];
        int arrayIndex = 0;
        for (double i = 0; i <= l.Length; i+=.5d)
        {
            vector3S.SetValue(Extends(l.Line.Direction,i)+l.Line.Point,arrayIndex);
            arrayIndex++;
        }
        Array.Resize(ref vector3S,arrayIndex);
        return vector3S;
    }
}

public struct Sphere
{
    public Vector3 Center;
    public double Radius;
    public Sphere(Vector3 a, double length)
    {
        Center = a;
        Radius = length;
    }

    public static Vector3[] ToVector3Array(Sphere s)
    {
        Vector3[] vector3S = new Vector3[65536];
        int arrayIndex = 0;
        for (double i = -Math.PI; i <= Math.PI; i+=0.04d)
        {
            var v = Math.SinCos(i);
            for (double uAngle = -Math.PI/2; uAngle < Math.PI/2; uAngle+=0.04d)
            {
                double height = Math.Sin(uAngle) * s.Radius;
                double a = v.Cos * s.Radius;
                double b = v.Sin * s.Radius;
                vector3S.SetValue(new Vector3(s.Center.X+a,s.Center.Y+b,s.Center.Z+height),arrayIndex);
                arrayIndex++;
            }
            GC.Collect();
        }
        Array.Resize(ref vector3S,arrayIndex);
        return vector3S;
    }
}

public struct Triangle
{
    public Vector3 A;
    public Vector3 B;
    public Vector3 C;

    public Triangle(Vector3 a, Vector3 b, Vector3 c)
    {
        A = a;
        B = b;
        C = c;
    }

    public static Vector3[] ToVector3Array(Triangle t)
    {
        
        Segment a = Segment.GetSegment(t.B,t.C);
        Segment b = Segment.GetSegment(t.A,t.C);
        Segment c = Segment.GetSegment(t.A,t.B);
        Vector3[] vector3S = new Vector3[65536];
        int arrayIndex = 0;
        for (double i = 0; i <= a.Length; i+=.5d)
        {
            vector3S.SetValue(Extends(a.Line.Direction,i)+a.Line.Point,arrayIndex);
            arrayIndex++;
        }
        for (double i = 0; i <= b.Length; i+=.5d)
        {
            vector3S.SetValue(Extends(b.Line.Direction,i)+b.Line.Point,arrayIndex);
            arrayIndex++;
        }
        for (double i = 0; i <= c.Length; i+=.5d)
        {
            vector3S.SetValue(Extends(c.Line.Direction,i)+c.Line.Point,arrayIndex);
            arrayIndex++;
        }
        Array.Resize(ref vector3S,arrayIndex);
        return vector3S;
    }
}

public class Scene
{
    public int LoadIndex = 0; 
    public Vector3[] Points = new Vector3[65536];
    public Vector3 CameraOffset = new Vector3(0,0,-10);
    public Vector3 ScreenOffset = new Vector3(0,0,-1);
    public double Fov = 90;//up+down, towards z positive
    public double AspectRatio = 16d / 9d;
    public Vector3 InGameOffset = new Vector3(0, 0, 0);
    
    public Scene()
    {
        
    }

    public static double GetUpFrame(Scene s)//relative
    {
        return (s.ScreenOffset.Z - s.CameraOffset.Z) * Math.Tan(s.Fov / 2);
    }
    public static double GetLeftFrame(Scene s)//relative
    {
        return s.AspectRatio*GetUpFrame(s);
    }
    public static Vector3[] Export(Scene s)
    {
        Array.Resize(ref s.Points,s.LoadIndex);
        return s.Points;
    }
    public void Clear()
    {
        GC.Collect();
        this.Points = new Vector3[65536];
        LoadIndex = 0;
    }

    public void Load(Vector3 a)
    {
        Points.SetValue(a,LoadIndex);
        LoadIndex++;
    }

    public void Load(Vector3[] s)
    {
        foreach (Vector3 a in s)
        {
            Points.SetValue(a,LoadIndex);
            LoadIndex++;
        }
    }

    public void Load(Line l)
    {
        Load(ToVector3Array(l));
    }
    public void Load(Segment l)
    {
        Load(Segment.ToVector3Array(l));
    }
    public void Load(Sphere l)
    {
        Load(Sphere.ToVector3Array(l));
    }
    public void Load(Triangle l)
    {
        Load(Triangle.ToVector3Array(l));
    }
    public void Matrix3Trans(Matrix3 matrix)
    {
        foreach (Vector3 a in Points)
        {
            for (int i = 0; i <= LoadIndex; i++)
            {
                Vector3 d = a * matrix;
                Points.SetValue(d,i);
            }
        }
    }
}