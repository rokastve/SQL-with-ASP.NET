using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalDB
{
    public partial class RegistracijosList : System.Web.UI.Page
    {
        public List<Registracija> testas = new List<Registracija>();
        public string conString = @"Data Source=localhost;port=3306;Initial catalog=animal; User Id= root; password=''";

        protected void Page_Load(object sender, EventArgs e)
        {
            showRegistracija();
        }
        public void showRegistracija()
        {
            Kontekstas test = new Kontekstas(conString);
            testas = test.GetRegistracija();
            Session["ArrayRegistracijos"] = testas;
            gvMysql.DataSource = testas;
            gvMysql.DataBind();
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
            Server.Transfer("RegistracijosAdd.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<Registracija> bandymas = (List<Registracija>)Session["ArrayRegistracijos"];
                Kontekstas test = new Kontekstas(conString);
                test.RemoveRegistracija(bandymas[e.RowIndex].numeris);
            }
            catch (Exception exception)
            {
                Label2.Text = exception.Message;
                return;
            }
            showRegistracija();
            Label2.Text = "Pašalintas elementas indeksu: " + e.RowIndex;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["editId"] = e.NewEditIndex;
            Server.Transfer("RegistracijosEdit.aspx", true);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("Ataskaitos.aspx");
        }
    }
}