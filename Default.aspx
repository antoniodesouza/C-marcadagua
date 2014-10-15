<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <label>
            Imagem<br />
            <asp:FileUpload runat="server" ID="ImagemFileUpload" /><br />

            Logo<br />
            <asp:FileUpload runat="server" ID="LogoFileUpload" /><br />

            <asp:Button runat="server" ID="SalvarButton" OnClick="SalvarButton_Click"  Text="Salvar"/>

        </label>


    </form>
</body>
</html>
