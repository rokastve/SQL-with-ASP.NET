using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class SavininkaiAdd : System.Web.UI.Page
    {
        public List<Lytis> lytysList = new List<Lytis>();
        public List<Adresas> adresaiList = new List<Adresas>();
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kontekstas test = new Kontekstas(conString);
                #region lytys
                lytysList = test.GetLytis();
                Dictionary<int, string> lytys = new Dictionary<int, string>();

                foreach (Lytis lytis in lytysList)
                {
                    lytys.Add(lytis.id, lytis.name);
                }
                DropDownList1.DataSource = lytys;
                DropDownList1.DataTextField = "Value";
                DropDownList1.DataValueField = "Key";
                DropDownList1.DataBind();
                #endregion
                #region adresau=i
                adresaiList = test.GetAdresas();
                Dictionary<int, string> adresai = new Dictionary<int, string>();
                foreach (Adresas adresas in adresaiList)
                {
                    adresai.Add(adresas.id_adresas, adresas.gatve + " " +adresas.buto_nr);
                }
                DropDownList2.DataSource = adresai;
                DropDownList2.DataTextField = "Value";
                DropDownList2.DataValueField = "Key";
                DropDownList2.DataBind();
                #endregion
            }
        }

            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Kontekstas test = new Kontekstas(conString);
                long id = long.Parse(TextBox_Vardas.Text);
                string vardas = TextBox1.Text;
                string pavarde = TextBox2.Text;
                int numeris = int.Parse(TextBox3.Text);
                string email = TextBox4.Text;
                DateTime data = DateTime.Parse(TextBox5.Text);
                int lytis = int.Parse(DropDownList1.SelectedValue);
                int adresas = int.Parse(DropDownList2.SelectedValue);
                test.AddSavininkas(id, vardas, pavarde, numeris, email, data, lytis, adresas);
            }
            catch(Exception exception)
            {
                Label3.Text = exception.Message;
                return;
            }
            Server.Transfer("SavininkaiList.aspx");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}