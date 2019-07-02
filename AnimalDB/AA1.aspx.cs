using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class AA1 : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        public List<AA1c> testas = new List<AA1c>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                updateTable();
            }
        }
        private void updateTable()
        {
            Kontekstas test = new Kontekstas(conString);
            testas = test.GetAA1();
            GridView1.DataSource = testas;
            GridView1.DataBind();
        }

        protected void Klasės_Click1(object sender, EventArgs e)
        {
            Server.Transfer("KlaseList.aspx");
        }

        protected void Main_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomePage.aspx");
        }

        protected void Gyvunai_Click(object sender, EventArgs e)
        {
            Server.Transfer("GyvunaiList.aspx");
        }

        protected void Savininkai_Click(object sender, EventArgs e)
        {
            Server.Transfer("SavininkaiList.aspx");
        }

        protected void Veisle_Click(object sender, EventArgs e)
        {
            Server.Transfer("VeisleList.aspx");
        }

        protected void Registracijos_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegistracijosList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}