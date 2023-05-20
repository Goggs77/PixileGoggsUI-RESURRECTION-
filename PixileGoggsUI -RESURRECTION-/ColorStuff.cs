using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace PixileGoggsUI__RESURRECTION_;

[StructLayout(LayoutKind.Sequential)]
public struct Color {
    public byte R{ get; set; } 
    public byte G{ get; set; }        
    public byte B{ get; set; }        
    public byte A{ get; set; }      
}
public static class ColorStuff
{
    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));

        hue = GetHue(color.R,color.G,color.B);
        saturation = (max == 0) ? 0 : 1d - (1d * min / max);
        value = max / 255d;
    }
    public static int GetHue(int red, int green, int blue) {

        double min = Math.Min(Math.Min(red, green), blue);
        double max = Math.Max(Math.Max(red, green), blue);

        if (min == max) {
            return 0;
        }

        double hue = 0;
        if (max == red) {
            hue = (green - blue) / (max - min);

        } else if (max == green) {
            hue = 2f + (blue - red) / (max - min);

        } else {
            hue = 4f + (red - green) / (max - min);
        }

        hue *= 60;
        if (hue < 0) hue = hue + 360;

        return (int)Math.Round(hue);
    }
    public static Vector4 RGBAtoHSVA(Color color)
    {
        float min = Math.Min(color.R, Math.Min(color.G, color.B));
        float max = Math.Max(color.R, Math.Max(color.G, color.B));
        float delta = max - min;
        float hue = 0f;
        float saturation = (max == 0f) ? 0f : delta / max;
        float value = max/255f;
        if (delta != 0f)
        {
            if (Math.Abs(color.R - max) < 0.01f)
            {
                hue = (color.G - color.B) / delta;
            }
            else if (Math.Abs(color.G - max) < 0.01f)
            {
                hue = 2f + (color.B - color.R) / delta;
            }
            else
            {
                hue = 4f + (color.R - color.G) / delta;
            }
            hue *= 60f;
            if (hue < 0f)
            {
                hue += 360f;
            }
        }
        return new Vector4(hue / 360f, saturation, value, color.A);
        
    }
    public static int PartFromColor(Color input,
        float litenessThresholdA = 0.79999f,
        float litenessThresholdB = 0.23333f,
        float litenessThresholdC = 0.13333f,
        float saturationThresholdA = 0.5f,
        float saturationThresholdB = 0.166667f,
        float alphaThreshold = 0.95f)
    {
        Vector4 hsvaInput = RGBAtoHSVA(input);
        hsvaInput.X *= 360f;

        //MAGIC!!!!!!!!!!!!!!!!!!!!!!
        if (input.A < alphaThreshold)
            return -1;
        if (hsvaInput.Y >= saturationThresholdA)
        {
            if (hsvaInput.Z >= litenessThresholdA)
            {
                return (int)(hsvaInput.X / 20.0f + 12);
            }
            if (hsvaInput.Z >= litenessThresholdB)
            {
                return (int)(hsvaInput.X / 20.0f + 30);
            }
            if (hsvaInput.Z >= litenessThresholdC)
            {
                return (int)(hsvaInput.X / 20.0f + 48);
            }
        }
        if (hsvaInput.Y >= saturationThresholdB)
        {
            if (hsvaInput.Z >= litenessThresholdA)
            {
                return (int)(hsvaInput.X / 20.0f + 66);
            }
            if (hsvaInput.Z >= litenessThresholdB)
            {
                return (int)(hsvaInput.X / 20.0f + 84);
            }
            if (hsvaInput.Z >= litenessThresholdC)
            {
                return (int)(hsvaInput.X / 20.0f + 102);
            }
        }
        return  (int)(10 - hsvaInput.Z * 9 + 119);;
    }
}