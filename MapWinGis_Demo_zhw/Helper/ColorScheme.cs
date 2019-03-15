using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw.Helper
{
    public class ColorScheme
    {
        public static void GetRGB(int color, out int r, out int g, out int b)
        {
            if (color < 0)
            {
                color = 0;
            }
            r = (int)(color & 0xFF);
            g = (int)(color & 0xFF00) / 256;	//shift right 8 bits
            b = (int)(color & 0xFF0000) / 65536; //shift right 16 bits
        }

        public static int HSLToRGB(int Hue, int Saturation, int Luminance)
        {
            int R = 0, G = 0, B = 0;
            int lMax, lMid, lMin;
            float q;

            lMax = (int)((Luminance * 255) / 100);
            lMin = (int)((100 - Saturation) * lMax / 100);
            q = (float)((lMax - lMin) / 60);

            if (Hue >= 0 && Hue <= 60)
            {
                lMid = (int)((Hue - 0) * q + lMin);
                R = lMax;
                G = lMid;
                B = lMin;
            }
            else if (Hue >= 60 && Hue <= 120)
            {
                lMid = (int)(-(Hue - 120) * q + lMin);
                R = lMid;
                G = lMax;
                B = lMin;
            }
            else if (Hue >= 120 && Hue <= 180)
            {
                lMid = (int)((Hue - 120) * q + lMin);
                R = lMin;
                G = lMax;
                B = lMid;
            }
            else if (Hue >= 180 && Hue <= 240)
            {
                lMid = (int)(-(Hue - 240) * q + lMin);
                R = lMin;
                G = lMid;
                B = lMax;
            }
            else if (Hue >= 240 && Hue <= 300)
            {
                lMid = (int)((Hue - 240) * q + lMin);
                R = lMid;
                G = lMin;
                B = lMax;
            }
            else if (Hue >= 300 && Hue <= 360)
            {
                lMid = (int)(-(Hue - 360) * q + lMin);
                R = lMax;
                G = lMin;
                B = lMid;
            }

            return B * 0x10000 + G * 0x100 + R;
        }

        public static int ColorToInt(Color c)
        {
            int retval = ((int)c.B) << 16;
            retval += ((int)c.G) << 8;
            return retval + ((int)c.R);
        }

        public static uint ColorToUInt(Color c)
        {
            return (uint)ColorToInt(c);
        }

        public static Color UIntToColor(UInt32 IntColor)
        {
            int r, g, b;
            GetRGB((int)(IntColor), out r, out g, out b);
            return Color.FromArgb(255, r, g, b);
        }

        public static Color IntToColor(int IntColor)
        {
            int r, g, b;
            GetRGB(IntColor, out r, out g, out b);
            return Color.FromArgb(255, r, g, b);
        }
    }



}
