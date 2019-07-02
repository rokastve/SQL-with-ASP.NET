<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavininkaiList.aspx.cs" Inherits="AnimalDB.SavininkaiList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            <asp:Button ID="Button1" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Button1_Click1" Text="Ataskaitos" Width="100px" />
            <asp:Button ID="Registracijos" runat="server" BackColor="#666666" BorderStyle="Solid" Height="40px" OnClick="Registracijos_Click" Text="Registracijos" Width="100px" />
         
            
            <br />
            <br />
            <asp:Label ID="NameTag" runat="server" Text="Savininkų lentelė"></asp:Label>
            <br />
            <asp:Button ID="PridetiGyvūną" runat="server" OnClick="Button1_Click" Text="Pridėti savininką" />
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
            </div>
    </form>
</body>
</html>
