using System.IO;

namespace PixileGoggsUI__RESURRECTION_;

public class TextEngine5X5
{
    
    public const string A = "00100" +
                            "01010" +
                            "10001" +
                            "11111" +
                            "10001";

    public const string B = "11110" +
                            "10001" +
                            "11110" +
                            "10001" +
                            "11110";

    public const string C = "01110" +
                            "10001" +
                            "10000" +
                            "10001" +
                            "01110";

    public const string D = "11110" +
                            "10001" +
                            "10001" +
                            "10001" +
                            "11110";

    public const string E = "11111" +
                            "10000" +
                            "11111" +
                            "10000" +
                            "11111";

    public const string F = "11111" +
                            "10000" +
                            "11111" +
                            "10000" +
                            "10000";

    public const string G = "01110" +
                            "10000" +
                            "10011" +
                            "10001" +
                            "01110";

    public const string H = "10001" +
                            "10001" +
                            "11111" +
                            "10001" +
                            "10001";

    public const string I = "11111" +
                            "00100" +
                            "00100" +
                            "00100" +
                            "11111";

    public const string J = "11111" +
                            "00001" +
                            "00001" +
                            "10001" +
                            "01110";

    public const string K = "10001" +
                            "10010" +
                            "11100" +
                            "10010" +
                            "10001";

    public const string L = "10000" +
                            "10000" +
                            "10000" +
                            "10000" +
                            "11111";

    public const string M = "10001" +
                            "11011" +
                            "10101" +
                            "10101" +
                            "10101";

    public const string N = "10001" +
                            "11001" +
                            "10101" +
                            "10011" +
                            "10001";

    public const string O = "01110" +
                            "10001" +
                            "10001" +
                            "10001" +
                            "01110";

    public const string P = "11110" +
                            "10001" +
                            "11110" +
                            "10000" +
                            "10000";

    public const string Q = "01110" +
                            "10001" +
                            "10101" +
                            "01110" +
                            "00011";

    public const string R = "11110" +
                            "10001" +
                            "11110" +
                            "10100" +
                            "10011";

    public const string S = "01111" +
                            "10000" +
                            "01110" +
                            "00001" +
                            "11110";

    public const string T = "11111" +
                            "00100" +
                            "00100" +
                            "00100" +
                            "00100";

    public const string U = "10001" +
                            "10001" +
                            "10001" +
                            "10001" +
                            "01110";

    public const string V = "10001" +
                            "10001" +
                            "01010" +
                            "01010" +
                            "00100";

    public const string W = "10001" +
                            "10101" +
                            "10101" +
                            "11011" +
                            "10001";

    public const string X = "10001" +
                            "01010" +
                            "00100" +
                            "01010" +
                            "10001";

    public const string Y = "10001" +
                            "01010" +
                            "00100" +
                            "00100" +
                            "00100";

    public const string Z = "11111" +
                            "00010" +
                            "00100" +
                            "01000" +
                            "11111";
    
    public const string SPACE = "00000" +
                                "00000" +
                                "00000" +
                                "00000" +
                                "00000";

    public const string COMMA = "00000" +
                                "00000" +
                                "11000" +
                                "11000" +
                                "01000";

    public const string DOT = "00000" +
                              "00000" +
                              "00000" +
                              "11000" +
                              "11000";

    public const string SEMICOLON = "00000" +
                                    "11000" +
                                    "00000" +
                                    "11000" +
                                    "01000";

    public const string COLON = "00000" +
                                "11000" +
                                "00000" +
                                "11000" +
                                "00000";

    public const string APOSTROPHE = "01000" +
                                     "01000" +
                                     "00000" +
                                     "00000" +
                                     "00000";

    public const string QUOTE = "01010" +
                                "01010" +
                                "00000" +
                                "00000" +
                                "00000";

    public const string ONE = "00100" +
                              "01100" +
                              "00100" +
                              "00100" +
                              "11111";

    public const string TWO = "01110" +
                              "10001" +
                              "00110" +
                              "01000" +
                              "11111";

    public const string THREE = "01110" +
                                "10001" +
                                "00110" +
                                "10001" +
                                "01110";

    public const string FOUR = "00110" +
                               "01010" +
                               "10010" +
                               "11111" +
                               "00010";

    public const string FIVE = "11111" +
                               "10000" +
                               "11110" +
                               "00001" +
                               "11110";

    public const string SIX = "01111" +
                              "10000" +
                              "11110" +
                              "10001" +
                              "11110";

    public const string SEVEN = "11111" +
                                "00001" +
                                "00010" +
                                "00100" +
                                "01000";

    public const string EIGHT = "01110" +
                                "10001" +
                                "01110" +
                                "10001" +
                                "01110";

    public const string NINE = "01110" +
                               "10001" +
                               "01111" +
                               "00010" +
                               "00100";

    public const string ZERO = "01110" +
                               "11001" +
                               "10101" +
                               "10011" +
                               "01110";

    public const string LPR = "01000" +
                              "10000" +
                              "10000" +
                              "10000" +
                              "01000";

    public const string RPR = "00010" +
                              "00001" +
                              "00001" +
                              "00001" +
                              "00010";

    public const string QUESTIONMARK = "01110" +
                                       "10001" +
                                       "00010" +
                                       "00000" +
                                       "00100";

    public const string EXC = "00100" +
                              "00100" +
                              "00100" +
                              "00000" +
                              "00100";

    public const string SWITCHLINE = "";
    public static string Get5X5Font(char a)
    {
        return a switch
        {
            '(' => LPR,
            ')' => RPR,
            '1' => ONE,
            '2' => TWO,
            '3' => THREE,
            '4' => FOUR,
            '5' => FIVE,
            '6' => SIX,
            '7' => SEVEN,
            '8' => EIGHT,
            '9' => NINE,
            '0' => ZERO,
            '\'' => APOSTROPHE,
            '"' => QUOTE,
            ';' => SEMICOLON,
            ':' => COLON,
            ',' => COMMA,
            '.' => DOT,
            'A' => A,
            'B' => B,
            'C' => C,
            'D' => D,
            'E' => E,
            'F' => F,
            'G' => G,
            'H' => H,
            'I' => I,
            'J' => J,
            'K' => K,
            'L' => L,
            'M' => M,
            'N' => N,
            'O' => O,
            'P' => P,
            'Q' => Q,
            'R' => R,
            'S' => S,
            'T' => T,
            'U' => U,
            'V' => V,
            'W' => W,
            'X' => X,
            'Y' => Y,
            'Z' => Z,
            ' ' => SPACE,
            '?' => QUESTIONMARK,
            '!' => EXC,
            '§' => SWITCHLINE,
            _ => SPACE
        };
    }

    

    public static void Print5X5Words(string content, int pixelLimit, int startX, int startY, int color)
    {
        
        string result = "";
        content = content.Replace("\n", " §");
        content += " ";
        int pixelLength = pixelLimit - pixelLimit % 6;
        
        
        for (int i = 0; i < content.Length; i++)
        {
            result += Get5X5Font(content.ToUpper()[i]);
        }
        

        int currentX = startX;
        int currentY = startY;
        int contentIndex = 0;
        int currentCharIndex = 0;
        int currentLineIndex = 0;
        using StreamWriter fs = new StreamWriter("savefile.txt",true);
        for (int stringIndex = 0; stringIndex < result.Length-25; stringIndex++)
        {
            if (currentX >= pixelLength)//<--line brake
            {
                currentCharIndex = 1;
                currentLineIndex++;
                currentX = startX+6*currentCharIndex;
                currentY = startY-10*currentLineIndex;
            }else 
            if (content[contentIndex] == '§')//<--force line brake
            {
                currentCharIndex = 1;
                currentLineIndex++;
                currentX = startX+6*currentCharIndex;
                currentY = startY-10*currentLineIndex;
                contentIndex++;
            }
            else
            if ((stringIndex + 0) % 25 == 0)//<--switch to the next char
            {
                currentCharIndex++;
                currentY = startY-10*currentLineIndex;
                currentX = startX+6*currentCharIndex;
                contentIndex++;
            }
            else
            if((stringIndex + 0) % 5 == 0)//<--single char line brake
            {
                currentY--;
                currentX = startX+6*currentCharIndex;
            }
            else
            {
                currentX++;
            }
            
            
            if (result[stringIndex] == '0')
            {
                
            }
            else if (result[stringIndex] == '1')
            {
                fs.WriteLine($"6,{color},{currentX},{currentY},0,0");
            }
        }
        fs.WriteLine("\n");
        fs.Close();
    }
}