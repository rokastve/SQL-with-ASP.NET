<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KlaseList.aspx.cs" Inherits="AnimalDB.KlaseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 170px;
            width: 591px;
        }
    </style>
</head>
<body>
    <div align="center">
    <form id="form1" runat="server">
   
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Naminių gyvūnų duomenų bazė"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Button1_Click" Text="Pagrindinis" Width="100px" />
        <asp:Button ID="Klasės" runat="server" OnClick="Klasės_Click1" Text="Klasės" BackColor="#666666" BorderStyle="Solid" Height="40px" Width="100px" />
            <asp:Button ID="Gyvunai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Gyvunai_Click" Text="Gyvūnai" Width="100px" />
            <asp:Button ID="Savininkai" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Savininkai_Click" Text="Savininkai" Width="100px" />
            <asp:Button ID="Veisle" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Veisle_Click" Text="Veisle" Width="100px" />
            <asp:Button ID="Button2" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Button2_Click1" Text="Ataskaitos" Width="100px" />
            <asp:Button ID="Registracijos" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Registracijos_Click" Text="Registracijos" Width="100px" />
         
            
            <br />
            <br />
            <asp:Label ID="NameTag" runat="server" Text="Klasių lentelė"></asp:Label>
            <br />
            <asp:Button ID="PridetiKlase" runat="server" OnClick="PridetiKlase_Click" Text="Pridėti Klasę" />
            <br />
         
            
            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
            <br />
        <asp:GridView ID="gvMysql" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#999999" BorderStyle="Solid" Font-Bold="True" />
            <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </form>
        </div>
</body>
</html>
