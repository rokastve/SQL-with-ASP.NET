using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace AnimalDB
{
    public partial class KlaseList : System.Web.UI.Page
    {

        public List<Klase> testas = new List<Klase>();
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''");
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowKlases();
        }
        protected void Klasės_Click1(object sender, EventArgs e)
        {
            Server.Transfer("KlaseList.aspx");
        }
        public void ShowKlases()
        {
            Kontekstas test = new Kontekstas(conString);
            testas = test.GetKlase();
            Session["ArrayKlase"] = testas;
            gvMysql.DataSource = testas;
            gvMysql.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("KlaseList.aspx");
        }
        public void SendError(string error)
        {
            Label2.Text = error;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<Klase> bandymas = (List<Klase>)Session["ArrayKlase"];
                Kontekstas test = new Kontekstas(conString);
                test.RemoveKlase(bandymas[e.RowIndex].Pavadinimas);
            }
            catch (Exception exception)
            {
                Label2.Text = exception.Message;
                return;
            }
            ShowKlases();
            Label2.Text = "Pašalintas elementas indeksu: " + e.RowIndex;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["editId"] = e.NewEditIndex;
            Server.Transfer("KlaseEdit.aspx",true);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMysql.EditIndex = -1;
            ShowKlases();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomePage.aspx", true);
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

        protected void PridetiKlase_Click(object sender, EventArgs e)
        {
            Server.Transfer("KlaseAdd.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}