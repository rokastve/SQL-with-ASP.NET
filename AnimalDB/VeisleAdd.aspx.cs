using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{

    public partial class VeisleAdd : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        public List<Klase> klaseList = new List<Klase>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kontekstas test = new Kontekstas(conString);
                #region Klase
                klaseList = test.GetKlase();
                List<string> klases = new List<string>();
                foreach (Klase klas in klaseList)
                {
                    klases.Add(klas.Pavadinimas);
                }
                DropDownList1.DataSource = klases;
                DropDownList1.DataBind();
                #endregion
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Main_Click(object sender, EventArgs e)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Kontekstas test = new Kontekstas(conString);
                string kilmes_salis = TextBox_Vardas.Text;
                int gyv_trukme = int.Parse(TextBox1.Text);
                string pavadinimas = TextBox2.Text;
                string klase = DropDownList1.SelectedValue;
                test.AddVeisle(kilmes_salis, gyv_trukme, pavadinimas, klase);
            }
            catch(Exception exception)
            {
                Label3.Text = exception.Message;
                return;
            }
            Server.Transfer("VeisleList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}