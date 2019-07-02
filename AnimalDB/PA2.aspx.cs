using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class PA2 : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        public List<PA2c> testas = new List<PA2c>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kontekstas test = new Kontekstas(conString);
                List<Registracija> Registracijos = test.GetRegistracija();
                List<String> vietos = new List<string>();

                foreach (Registracija reg in Registracijos)
                {
                    if(!vietos.Contains(reg.vieta))
                    vietos.Add(reg.vieta);
                }
                DropDownList1.DataSource = vietos;
                DropDownList1.DataBind();
            }
        }
        public void UpdateTable()
        {
            try
            {
                Kontekstas test = new Kontekstas(conString);
                string vieta = DropDownList1.SelectedValue;
                DateTime from = DateTime.Parse(TextBox1.Text);
                DateTime to = DateTime.Parse(TextBox2.Text);
                testas = test.GetAnimalsInPlace(vieta, from, to);
                GridView1.DataSource = testas;
                GridView1.DataBind();
            }
            catch (Exception exception)
            {
                Label5.Text = exception.Message;
                return;
            }
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}