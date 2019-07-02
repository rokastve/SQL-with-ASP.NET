<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PA2.aspx.cs" Inherits="AnimalDB.PA2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 272px;
            width: 753px;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
   
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Naminių gyvūnų duomenų bazė"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Main" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Main_Click" Text="Pagrindinis" Width="100px" />
        <asp:Button ID="Klasės" runat="server" OnClick="Klasės_Click1" Text="Klasės" BackColor="#666666" BorderStyle="Solid" Height="40px" Width="100px" />
            <asp:Button ID="Gyvunai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Gyvunai_Click" Text="Gyvūnai" Width="100px" />
            <asp:Button ID="Savininkai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Savininkai_Click" Text="Savininkai" Width="100px" />
            <asp:Button ID="Veisle" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Veisle_Click" Text="Veisle" Width="100px" />
            <asp:Button ID="Button1" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" Text="Ataskaitos" Width="100px" OnClick="Button1_Click" />
            <asp:Button ID="Registracijos" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Registracijos_Click" Text="Registracijos" Width="100px" />
         
        <asp:Panel ID="Panel2" runat="server" Height="350px" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="margin-top: 14px">
            <asp:Label ID="Label2" runat="server" Text="Pasirinkite vietą"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br /> 
            <asp:Label ID="Label3" runat="server" Text="Data nuo"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server">yyyy-mm-dd</asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Data iki"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server">yyyy-mm-dd</asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Vykdyti" />
            <br />
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HorizontalAlign="Center">
            </asp:GridView>
            </asp:Panel>
            </div>
    </form>
</body>
</html>

