<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VeisleAdd.aspx.cs" Inherits="AnimalDB.VeisleAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
   <div align="center">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Naminių gyvūnų duomenų bazė"></asp:Label>
        <br />
        <br />
            <asp:Button ID="Main" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Main_Click" Text="Pagrindinis" Width="100px" />
        <asp:Button ID="Klasės" runat="server" OnClick="Klasės_Click1" Text="Klasės" BackColor="#666666" BorderStyle="Solid" Height="40px" Width="100px" />
            <asp:Button ID="Gyvunai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Gyvunai_Click" Text="Gyvūnai" Width="100px" />
            <asp:Button ID="Savininkai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Savininkai_Click" Text="Savininkai" Width="100px" />
            <asp:Button ID="Veisle" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Veisle_Click" Text="Veisle" Width="100px" />
            <asp:Button ID="Button2" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Button2_Click" Text="Ataskaitos" Width="100px" />
            <asp:Button ID="Registracijos" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Registracijos_Click" Text="Registracijos" Width="100px" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Naujos veislės įterpimas"></asp:Label>
            <br />
            <br />
         </div>
            
        <asp:Panel ID="Panel1" runat="server" Height="136px">
            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Kilmės Šalis"></asp:Label>
            <asp:TextBox ID="TextBox_Vardas" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Gyvenimo trukmė"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Pavadinimas"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Klasė"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </asp:Panel>
            
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sukurti" />
            
    </form>
</body>
</html>
