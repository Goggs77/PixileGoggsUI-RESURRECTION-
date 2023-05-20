using System;

namespace PixileGoggsUI__RESURRECTION_;

public static class HelpStrings
{
    public static string GetHelpString(int page)
    {
        return page switch
        {
            0 => "",
            1 => Help1,
            2 => Help2,
            3 => Help3,
            4 => Help4,
            5 => Help5,
            6 => Help6,
            7 => Help7,
            8 => Help8,
            9 => Help9,
            10 => Help10,
            _ => throw new ArgumentOutOfRangeException(nameof(page), page, null)
        };
    }

    public const string LICENCE =
        "Copyright 2023 @Goggs" +
        "\n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:" +
        "\n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software." +
        "\n\nTHE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";
    public const string About = "\nPixileGoggsUI -RESURRECTION- 1.2.F" +
                                "\n----------------------------------------------" +
                                "\nA Bad Piggies graphing project originally by @Goggs" +
                                "\nhttps://github.com/Goggs77/PixileGoggsUI-RESURRECTION-" +
                                "\nEvaluation Support: https://eval-expression.net" +
                                "\nYoutube Channel: https://www.youtube.com/channel/UCcKGwHzY1LrtrYaaHjq2d2w" +
                                "\nMental Support: https://www.youtube.com/user/TheGoggsBand (TheGoggsBand Is Not User @Goggs)" +
                                "\nNo Need to Say: https://stackoverflow.com" +
                                "\nVery Very Special thanks to @原野与森林, @MySelf, @AnstroPleuton, @Dlina" +
                                "\n----------------------------------------------" +
                                "\nWritten by @Goggs, this software itself(apart from external packages) is Free and Open Source under MIT License\n";

    public const string Help1 = "PixileGoggsUI -RESURRECTION- Help\n" +
                                "Edited On 2023 May 20th\n" +
                                "----------------------------------------------\n" +
                                "Available Functions:\n" +
                                "1.Function Plotting\n" +
                                "2.Polar Function Plotting\n" +
                                "3.Parametric Equation Plotting\n" +
                                "4.X-Y Equation Plotting\n" +
                                "5.Rectangle Tool\n" +
                                "6.Textbox Tool (2 Fonts)\n" +
                                "7.Easy Copy/Paste/View/Backup/Edit to Your Game Saves\n" +
                                "8.Complex Functions/Transformations\n" +
                                "9.Image To Parts(with complex transformations)\n" +
                                "10.Naive code-based 3d rendering\n" +
                                "----------------------------------------------\n" +
                                "How To Use:\n" +
                                "https://www.youtube.com/watch?v=pgiuZ7VdjuY&list=PL6LkwZ9bqGb2rC0UwXIdPHZZF1-QRSgHB\n" +
                                "----------------------------------------------\n" +
                                "Common Shortcuts:\n" +
                                "-Right click on a save file allows you to edit it, but remember to press \"Save\"!\n" +
                                "-Left click \"Switch\" can show more tool in the Main Window\n" +
                                "-You can copy those functions from the \"Available Functions\" list, and test them out in plotting menu\n" +
                                "----------------------------------------------\n" +
                                "Try out these examples!\n" +
                                "Function Examples:\n" +
                                "Sin(x)*Cos(2*x)        x*Sin(x)-x*x+1/x\n" +
                                "Copy-Paste these functions into FunctionPlotting-Arguments-y=Functionx Text Box, then click \"Plot\" \n" +
                                "There are other Real-World Functions available in \"Available Functions\" list\n" +
                                "Some of them takes 2 or more parameters, e.g. : \nClamp(Double value, Double min, Double max)\n" +
                                "Returns value clamped to the inclusive range of min and max\n" +
                                "CopySign(double x, double y) Returns a value with the magnitude of x and the sign of y\n" +
                                "DivRem(int a, int b, out int result) \n" +
                                "Calculates the quotient of two 32-bit signed integers and also returns the remainder \n" +
                                "in an output parameter.\n" +
                                "FusedMultiplyAdd(double x, double y, double z) Returns (x * y) + z, \n" +
                                "rounded as one ternary operation\n" +
                                "ScaleB(double x, int n) Returns x * 2^n computed efficiently\n" +
                                "SinCos(double x) Returns ValueTuple<Double,Double>\n" +
                                "----------------------------------------------\n" +
                                "Complex World is on the next page...\n";

    public const string Help2 = "PixileGoggsUI -RESURRECTION- Complex World -Help\n" +
                                "----------------------------------------------\n" +
                                "General Complex Functions:\n" +
                                "Exp(Complex z)\tModulus(Complex z)\tArgument(Complex z)\n" +
                                "Sqrt(Complex z)\tLn(Complex z)\tAnd (Hyperbolic)Trigonometry Functions\n" +
                                "LogBase(Complex b, Complex z) Returns Log_{b}(z)\n" +
                                "Given Complex a and b, you can simply use a^b instead of Pow(a,b), which is not available\n" +
                                "in Complex World.\n" +
                                "----------------------------------------------\n";
                                
    public const string Help3 = "";
    public const string Help4 = "";
    public const string Help5 = "";
    public const string Help6 = "";
    public const string Help7 = "";
    public const string Help8 = "";
    public const string Help9 = "";
    public const string Help10 = "LICENCE:\n"+LICENCE;
}