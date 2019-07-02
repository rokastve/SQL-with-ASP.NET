using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class GyvunaiEdit : System.Web.UI.Page
    {
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        public List<Lytis> lytysList = new List<Lytis>();
        public List<Savininkas> savininkaiList = new List<Savininkas>();
        public List<Isvaizda> isvaizdaList = new List<Isvaizda>();
        public List<Mikro> mikrosList = new List<Mikro>();
        public List<Registracija> regList = new List<Registracija>();
        public List<Sveikata> sveikList = new List<Sveikata>();
        public List<Veisle> veislList = new List<Veisle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Gyvunas> bandymas = (List<Gyvunas>)Session["ArrayGyvunai"];
                int edit = (int)Session["editId"];
                TextBox1.Text = bandymas[edit].vardas;
                TextBox2.Text = bandymas[edit].gimimo_data.ToShortDateString();

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
                DropDownList1.SelectedValue = bandymas[edit].lytis_id.ToString();
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
                DropDownList2.SelectedValue = bandymas[edit].savininko_kodas.ToString();
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
                DropDownList3.SelectedValue = bandymas[edit].fk_Isvaizda_id.ToString();
                #endregion
                #region mikroschema
                mikrosList = test.GetMikro();
                List<int> mikroList = new List<int>();
                foreach (Mikro mik in mikrosList)
                {
                    mikroList.Add(mik.numeris);
                }
                DropDownList6.DataSource = mikroList;
                DropDownList6.DataBind();
                DropDownList6.SelectedValue = bandymas[edit].fk_micro_id.ToString();
                #endregion
                #region registracija
                regList = test.GetRegistracija();
                List<int> registNr = new List<int>();
                foreach (Registracija reg in regList)
                {
                    registNr.Add(reg.numeris);
                }
                DropDownList7.DataSource = registNr;
                DropDownList7.DataBind();
                DropDownList7.SelectedValue = bandymas[edit].fk_reg_id.ToString();
                #endregion
                #region sveikata
                sveikList = test.GetSveikata();
                List<DateTime> datuList = new List<DateTime>();
                foreach (Sveikata sveik in sveikList)
                {
                    datuList.Add(sveik.Vizito_data.Date);
                }
                DropDownList5.DataSource = datuList;
                DropDownList5.DataBind();
                DropDownList5.SelectedValue = bandymas[edit].fk_vet_viz.ToShortDateString();
                #endregion
                #region veisle
                veislList = test.GetVeisle();
                List<string> veisles = new List<string>();
                foreach (Veisle veis in veislList)
                {
                    veisles.Add(veis.pavadinimas);
                }
                DropDownList4.DataSource = veisles;
                DropDownList4.DataBind();
                DropDownList4.SelectedValue = bandymas[edit].fk_veisle;
                #endregion
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
            test.EditGyvunas(TextBox1.Text, DateTime.Parse(TextBox2.Text), int.Parse(DropDownList1.SelectedValue), long.Parse(DropDownList2.SelectedValue), int.Parse(DropDownList3.SelectedValue),
                DropDownList4.SelectedValue, DateTime.Parse(DropDownList5.SelectedValue), int.Parse(DropDownList6.Text), int.Parse(DropDownList7.SelectedValue));
            Server.Transfer("GyvunaiList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}