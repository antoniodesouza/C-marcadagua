using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SalvarButton_Click(object sender, EventArgs e)
    {



        String Pasta = Server.MapPath("./") + "\\Geracao";
        String URLimagem = String.Format("{0}\\{1}_img.png", Pasta, Guid.NewGuid().ToString());
        String URLlogo = URLimagem.Replace("_img.png", "_logo.png");
        String URLsaida = URLimagem.Replace("_img.png", ".png");


        if (!Directory.Exists(Pasta)) Directory.CreateDirectory(Pasta);
        ImagemFileUpload.SaveAs(URLimagem);
        LogoFileUpload.SaveAs(URLlogo);
        Uteis.GeraMarcaDagua(URLimagem, URLlogo, URLsaida);





    }
}