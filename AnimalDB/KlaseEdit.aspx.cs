using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class KlaseEdit : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Klase> bandymas = (List<Klase>)Session["ArrayKlase"];
                int edit = (int)Session["editId"];
                TextBox1.Text = bandymas[edit].Pavadinimas;
                TextBox2.Text = bandymas[edit].Tipas;
                TextBox3.Text = bandymas[edit].Potipis;
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
            string pav = TextBox1.Text;
            string tip = TextBox2.Text;
            string potip = TextBox3.Text;
            test.EditKlase(pav, tip, potip);
            Server.Transfer("KlaseList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}