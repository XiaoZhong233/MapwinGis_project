using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Helper
{
    public class ImageUtils : System.Windows.Forms.AxHost
    {
        public ImageUtils()
        : base("75A9135C-8D64-4CE0-AD6B-EA48F7BF07D8")
        { }

        /// <summary>
        /// 将运行时的Icon和Image的object类型对象转换成Image类型对象
        /// </summary>
        /// <param name="Picture">object类型的图片对戏</param>
        /// <param name="newWidth">图片宽</param>
        /// <param name="newHeight">图片高</param>
        public static System.Drawing.Image ObjectToImage(object Picture, int newWidth = -1, int newHeight = -1)
        {
            System.Drawing.Image img = null;
            if (Picture is System.Drawing.Icon)
            {
                img = (System.Drawing.Image)(((System.Drawing.Icon)Picture).ToBitmap());
            }
            else if (Picture is System.Drawing.Image)
            {
                img = (System.Drawing.Image)((System.Drawing.Image)Picture);
            }
            else if (Picture is stdole.IPictureDisp)
            {
                stdole.IPictureDisp ipdisp = (stdole.IPictureDisp)Picture;

                const int PIC_BITMAP = 1;
                const int PIC_ICON = 3;

                if (ipdisp.Type == PIC_BITMAP)
                {
                    ImageUtils cvter = new ImageUtils();
                    img = cvter.IPictureDispToImage(Picture);
                }
                else if (ipdisp.Type == PIC_ICON)
                {
                    throw new System.Exception("暂不支持Icons类型的图像");
                }
                else
                {
                    throw new System.Exception("不支持的类型图像");
                }
            }

            System.Drawing.Image retval;

            if (newHeight > 0 && newWidth > 0)
            {
                retval = new System.Drawing.Bitmap(newWidth, newHeight);
                System.Drawing.Graphics drawtool = System.Drawing.Graphics.FromImage(retval);
                if (img != null)
                {
                    drawtool.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight));
                }
            }
            else
            {
                retval = img;
            }

            return retval;
        }

        public object ImageToIPictureDisp(System.Drawing.Image image)
        {
            return AxHost.GetIPictureDispFromPicture(image);
        }

        public System.Drawing.Image IPictureDispToImage(object image)
        {
            return AxHost.GetPictureFromIPicture(image);
        }

        //图像透明度
        public static Bitmap alphaImage(Bitmap fImage, Bitmap bImage, double alpha)
        {
            //输入fImage为前景图，bImage为背景图，alpha为透明度
            int height = fImage.Height;
            int width = bImage.Width;
            Bitmap aImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int Ra = (int)Math.Round((1 - (alpha / 100.0)) * fImage.GetPixel(x, y).R + (alpha / 100.0) * bImage.GetPixel(x, y).R);
                    int Ga = (int)Math.Round((1 - (alpha / 100.0)) * fImage.GetPixel(x, y).G + (alpha / 100.0) * bImage.GetPixel(x, y).G);
                    int Ba = (int)Math.Round((1 - (alpha / 100.0)) * fImage.GetPixel(x, y).B + (alpha / 100.0) * bImage.GetPixel(x, y).B);
                    Color RGB = Color.FromArgb(Ra, Ga, Ba);
                    aImage.SetPixel(x, y, RGB);
                }
            }
            return aImage;
        }

        //色彩度最大为255，最小为0
        public static Bitmap img_alpha(Bitmap src, int alpha)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int h = 0; h < src.Height; h++)
                for (int w = 0; w < src.Width; w++)
                {
                    Color c = src.GetPixel(w, h);
                    bmp.SetPixel(w, h, Color.FromArgb(alpha, c.R, c.G, c.B));
                }
            return bmp;
        }

    }
}
