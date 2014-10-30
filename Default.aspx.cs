using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void SalvarButton_Click(object sender, EventArgs e)
    {

        String Pasta = Server.MapPath("./") + "\\Geracao";
        String URLsaida = String.Format("{0}\\{1}.png", Pasta, Guid.NewGuid().ToString());
        if (!Directory.Exists(Pasta)) Directory.CreateDirectory(Pasta);
        Uteis.GeraMarcaDagua(ImagemFileUpload.FileBytes, LogoFileUpload.FileBytes, URLsaida, 900, 600);


    }
}