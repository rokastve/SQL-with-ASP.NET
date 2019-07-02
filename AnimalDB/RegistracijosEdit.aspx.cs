using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class RegistracijosEdit : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Registracija> bandymas = (List<Registracija>)Session["ArrayRegistracijos"];
                int edit = (int)Session["editId"];
                TextBox1.Text = bandymas[edit].numeris.ToString();
                TextBox2.Text = bandymas[edit].data.ToShortDateString();
                TextBox3.Text = bandymas[edit].vieta;

                Kontekstas test = new Kontekstas(conString);
                List<Savininkas> savininkai = test.GetSavininkas();
                List<long> id = new List<long>();
                foreach (Savininkas sav in savininkai)
                    id.Add(sav.id);
                DropDownList1.DataSource = id;
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = bandymas[edit].savininko_id.ToString();

                List<Veterinaras> veterinarai = test.GetVeterinaras();
                List<int> idv = new List<int>();
                foreach (Veterinaras vet in veterinarai)
                    idv.Add(vet.kodas);
                DropDownList2.DataSource = idv;
                DropDownList2.DataBind();
                DropDownList2.SelectedValue = bandymas[edit].veterinaras_id.ToString();
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
            test.EditRegistracija(int.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text), TextBox3.Text, long.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));
            Server.Transfer("RegistracijosList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}