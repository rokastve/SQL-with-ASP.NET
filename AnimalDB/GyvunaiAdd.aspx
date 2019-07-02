<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GyvunaiAdd.aspx.cs" Inherits="AnimalDB.GyvunaiAdd" EnableViewState="true"%>

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
            <asp:Label ID="Label2" runat="server" Text="Naujo gyvūno sukūrimas"></asp:Label>
            <br />
            <br />
         </div>
            
        <asp:Panel ID="Panel1" runat="server" Height="262px">
            <asp:Label ID="Label8" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Vardas"></asp:Label>
            <asp:TextBox ID="TextBox_Vardas" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Data"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server">yyyy-mm-dd</asp:TextBox>
            <br />
            Lytis&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Savininkas"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            Išvaizda
            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            Vizito pas veterinarą data
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            Mikroschemos nr
            <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            Registracijos nr
            <asp:DropDownList ID="DropDownList6" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Veisle"></asp:Label>
            <asp:DropDownList ID="DropDownList7" runat="server">
            </asp:DropDownList>
        </asp:Panel>
            
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sukurti" />
            
    </form>
</body>
</html>
