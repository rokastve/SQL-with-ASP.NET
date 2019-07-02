using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class RegistracijosAdd : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        public List<Savininkas> savininkaiList = new List<Savininkas>();
        public List<Veterinaras> veterinraiList = new List<Veterinaras>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kontekstas test = new Kontekstas(conString);
                #region savininkai
                savininkaiList = test.GetSavininkas();
                List<long> savId = new List<long>();
                foreach (Savininkas sav in savininkaiList)
                {
                    savId.Add(sav.id);
                }
                DropDownList1.DataSource = savId;
                DropDownList1.DataBind();
                #endregion
                #region Veterk arak
                veterinraiList = test.GetVeterinaras();
                List<int> vetId = new List<int>();
                foreach (Veterinaras vet in veterinraiList)
                {
                    vetId.Add(vet.kodas);
                }
                DropDownList2.DataSource = vetId;
                DropDownList2.DataBind();
                #endregion
            }
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
                int numeris = int.Parse(TextBox_Vardas.Text);
                DateTime data = DateTime.Parse(TextBox1.Text);
                string vieta = TextBox2.Text;
                long sav_id = long.Parse(DropDownList1.SelectedValue);
                int vet_id = int.Parse(DropDownList2.SelectedValue);
                test.AddRegistracija(numeris, data, vieta, sav_id, vet_id);
            }
            catch(Exception exception)
            {
                Label9.Text = exception.Message;
                return;
            }
            Server.Transfer("RegistracijosList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}