using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class GyvunaiAdd : System.Web.UI.Page
    {
        public List<Lytis> lytysList = new List<Lytis>();
        public List<Savininkas> savininkaiList = new List<Savininkas>();
        public List<Isvaizda> isvaizdaList = new List<Isvaizda>();
        public List<Mikro> mikrosList = new List<Mikro>();
        public List<Registracija> regList = new List<Registracija>();
        public List<Sveikata> sveikList = new List<Sveikata>();
        public List<Veisle> veislList = new List<Veisle>();
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
                #region savininkai
                savininkaiList = test.GetSavininkas();
                List<long> savId = new List<long>();
                foreach (Savininkas sav in savininkaiList)
                {
                    savId.Add(sav.id);
                }
                DropDownList2.DataSource = savId;
                DropDownList2.DataBind();
                #endregion
                #region isvaizda
                isvaizdaList = test.GetIsvaizda();
                List<int> isvId = new List<int>();
                foreach (Isvaizda isv in isvaizdaList)
                {
                    isvId.Add(isv.id);
                }
                DropDownList3.DataSource = isvId;
                DropDownList3.DataBind();
                #endregion
                #region mikroschema
                mikrosList = test.GetMikro();
                List<int> mikroList = new List<int>();
                foreach (Mikro mik in mikrosList)
                {
                    mikroList.Add(mik.numeris);
                }
                DropDownList5.DataSource = mikroList;
                DropDownList5.DataBind();
                #endregion
                #region registracija
                regList = test.GetRegistracija();
                List<int> registNr = new List<int>();
                foreach (Registracija reg in regList)
                {
                    registNr.Add(reg.numeris);
                }
                DropDownList6.DataSource = registNr;
                DropDownList6.DataBind();
                #endregion
                #region sveikata
                sveikList = test.GetSveikata();
                List<DateTime> datuList = new List<DateTime>();
                foreach (Sveikata sveik in sveikList)
                {
                    datuList.Add(sveik.Vizito_data.Date);
                }
                DropDownList4.DataSource = datuList;
                DropDownList4.DataBind();
                #endregion
                #region veisle
                veislList = test.GetVeisle();
                List<string> veisles = new List<string>();
                foreach (Veisle veis in veislList)
                {
                    veisles.Add(veis.pavadinimas);
                }
                DropDownList7.DataSource = veisles;
                DropDownList7.DataBind();
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
            Server.Transfer("GegistracijosList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Kontekstas test = new Kontekstas(conString);
                if (String.IsNullOrEmpty(TextBox_Vardas.Text))
                    {
                    throw new Exception("Tuscias vardo laukelis");
                }
                string vardas = TextBox_Vardas.Text;
                if (String.IsNullOrEmpty(TextBox1.Text))
                {
                    throw new Exception("Tuscias datos laukelis");
                }
                DateTime db = Convert.ToDateTime(TextBox1.Text).Date;
                int lytis = int.Parse(DropDownList1.SelectedValue);
                long savininkas = long.Parse(DropDownList2.SelectedValue);
                int isvaizda = int.Parse(DropDownList3.SelectedValue);
                DateTime vizitoData = DateTime.Parse(DropDownList4.SelectedValue).Date;
                int mikro = int.Parse(DropDownList5.SelectedValue);
                int reg = int.Parse(DropDownList6.SelectedValue);
                string veisle = DropDownList7.SelectedValue;
                test.AddGyvunas(vardas, db, lytis, savininkas, isvaizda, veisle, vizitoData, mikro, reg);
            }
            catch(Exception exception)
            {
                Label8.Text = exception.Message;
                return;
            }
            Server.Transfer("GyvunaiList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}