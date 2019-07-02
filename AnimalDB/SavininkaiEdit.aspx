<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavininkaiEdit.aspx.cs" Inherits="AnimalDB.SavininkaiEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 454px;
        }
    </style>
</head>
    <div align="center">
<body>
    <form id="form1" runat="server">
        <p>
   
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Naminių gyvūnų duomenų bazė"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Main" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Main_Click1" Text="Pagrindinis" Width="100px" />
        <asp:Button ID="Klasės" runat="server" OnClick="Klasės_Click1" Text="Klasės" BackColor="#666666" BorderStyle="Solid" Height="40px" Width="100px" />
            <asp:Button ID="Gyvunai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Gyvunai_Click" Text="Gyvūnai" Width="100px" />
            <asp:Button ID="Savininkai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Savininkai_Click" Text="Savininkai" Width="100px" />
            <asp:Button ID="Veisle" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Veisle_Click" Text="Veisle" Width="100px" />
            <asp:Button ID="Button3" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Button3_Click" Text="Ataskaitos" Width="100px" />
            <asp:Button ID="Registracijos" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Registracijos_Click" Text="Registracijos" Width="100px" />
         
            
            </p>
        <p>
   
            <asp:Label ID="Label2" runat="server" Text="Savininko redagavimas"></asp:Label>
         
            
            </p>
        <asp:Panel ID="Panel1" runat="server" Height="306px" HorizontalAlign="Left">
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Asmens kodas"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Vardas"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Pavardė"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Telefono Numeris"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="El.Paštas"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Gimimo Data"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server">yyyy-mm-dd</asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Lytis"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Adresas"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Atnaujinti" style="height: 26px" />
</asp:Panel>
    </form>
</body>
        </div>
</html>