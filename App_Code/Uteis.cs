using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uteis
/// </summary>
public class Uteis
{
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
}