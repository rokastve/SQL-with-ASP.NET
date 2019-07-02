using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class VeisleEdit : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Veisle> bandymas = (List<Veisle>)Session["ArrayVeisles"];
                int edit = (int)Session["editId"];
                TextBox1.Text = bandymas[edit].kilmes_salis;
                TextBox2.Text = bandymas[edit].gyvenimo_trukme.ToString() ;
                TextBox3.Text = bandymas[edit].pavadinimas;
                Kontekstas test = new Kontekstas(conString);
                List<Klase> klases = test.GetKlase();
                List<string> klasespav = new List<string>();
                foreach (Klase klase in klases)
                    klasespav.Add(klase.Pavadinimas);
                DropDownList1.DataSource = klasespav;
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = edit;
            }
        }
        protected void Main_Click1(object sender, EventArgs e)
        {
            Server.Transfer("HomePage.aspx");
        }

        protected void Klasės_Click1(object sender, EventArgs e)
        {
            Server.Transfer("KlaseList.aspx");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Kontekstas test = new Kontekstas(conString);
            test.EditVeisle(TextBox1.Text, int.Parse(TextBox2.Text), TextBox3.Text, DropDownList1.SelectedValue);
            Server.Transfer("VeisleList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}