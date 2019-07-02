using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class SavininkaiEdit : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Savininkas> bandymas = (List<Savininkas>)Session["ArraySavininkai"];
                int edit = (int)Session["editId"];
                TextBox1.Text = bandymas[edit].id.ToString();
                TextBox2.Text = bandymas[edit].vardas;
                TextBox3.Text = bandymas[edit].pavarde;
                TextBox4.Text = bandymas[edit].numeris.ToString();
                TextBox5.Text = bandymas[edit].email;
                TextBox6.Text = bandymas[edit].gimimo_data.ToShortDateString();
                Kontekstas test = new Kontekstas(conString);
                List<Lytis>lytysList = test.GetLytis();
                Dictionary<int, string> lytys = new Dictionary<int, string>();

                foreach (Lytis lytis in lytysList)
                {
                    lytys.Add(lytis.id, lytis.name);
                }
                DropDownList1.DataSource = lytys;
                DropDownList1.DataTextField = "Value";
                DropDownList1.DataValueField = "Key";
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = edit;

                List<Adresas>adresaiList = test.GetAdresas();
                Dictionary<int, string> adresai = new Dictionary<int, string>();
                foreach (Adresas adresas in adresaiList)
                {
                    adresai.Add(adresas.id_adresas, adresas.gatve + " " + adresas.buto_nr);
                }
                DropDownList2.DataSource = adresai;
                DropDownList2.DataTextField = "Value";
                DropDownList2.DataValueField = "Key";
                DropDownList2.DataBind();
                DropDownList2.SelectedValue = bandymas[edit].adresas_id.ToString();
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
            test.EditSavininkas(long.Parse(TextBox1.Text), TextBox2.Text, TextBox3.Text, int.Parse(TextBox4.Text), TextBox5.Text, DateTime.Parse(TextBox6.Text), int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));
            Server.Transfer("SavininkaiList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}