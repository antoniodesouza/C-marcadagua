using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uteis
/// </summary>
public class Uteis
{

    public static Int32[] GeraDimensoes(Image image, Int32 Width, Int32 Height)
    {
        Int32[] r = new Int32[] { };

        if (image.Width > image.Height)
        {
            r = new Int32[] { Width, (Int32)(image.Height * ((((Width * 100.00) / image.Width)) / 100)) };
        }
        else
        {
            r = new Int32[] { Height, (Int32)(image.Width * ((((Height * 100.00) / image.Height)) / 100)) };
        }

        return r;
    }

    public static void GeraMarcaDagua(Byte[] imageByte, Byte[] watermarkImageByte, String URLsaida, Int32 Width, Int32 Height)
    {


        Image image = byteArrayToImage(imageByte);
        Image watermarkImage = byteArrayToImage(watermarkImageByte);
        Int32[] imageD = GeraDimensoes(image, Width, Height);
        Int32[] watermarkImageD = GeraDimensoes(watermarkImage, (imageD[0] / 3), (imageD[1] / 3));

        image = imageResize(image, imageD[0], imageD[1]);
        watermarkImage = imageResize(watermarkImage, watermarkImageD[0], watermarkImageD[1]);

        using (Graphics imageGraphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            int x = (image.Width / 2 - watermarkImage.Width / 2);
            int y = (image.Height / 2 - watermarkImage.Height / 2);
            watermarkBrush.TranslateTransform(x, y);
            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
            image.Save(URLsaida);
        }

    }

    public static void GeraMarcaDagua(Image image, Image watermarkImage, String URLsaida)
    {
        using (Graphics imageGraphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            int x = (image.Width / 2 - watermarkImage.Width / 2);
            int y = (image.Height / 2 - watermarkImage.Height / 2);
            watermarkBrush.TranslateTransform(x, y);
            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
            image.Save(URLsaida);
        }

    }

    public static void GeraMarcaDagua(String URLimagem, String URLlogo, String URLsaida)
    {

        using (Image image = Image.FromFile(URLimagem))
        using (Image watermarkImage = Image.FromFile(URLlogo))
        using (Graphics imageGraphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            int x = (image.Width / 2 - watermarkImage.Width / 2);
            int y = (image.Height / 2 - watermarkImage.Height / 2);
            watermarkBrush.TranslateTransform(x, y);
            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
            image.Save(URLsaida);
        }

    }

    public static Image imageResize(Image image, Int32 width, Int32 height)
    {
        Size size = new Size(width, height);
        return (Image)(new Bitmap(image, size));
    }

    public static Image imageResizeThumb(Image image, Int32 width, Int32 height)
    {
        Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
        return image.GetThumbnailImage(width, height, callback, new IntPtr());
    }

    public static bool ThumbnailCallback()
    {
        return true;
    }

    public static byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }

    public static Image byteArrayToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }

}