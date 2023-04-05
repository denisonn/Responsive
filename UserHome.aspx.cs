using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WsLogin;
using WsClientes;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null)
        {
            lblSuccess.Text = "Login Success, Welcome " + Session["USERNAME"].ToString() + "";
        }
        BindCategories();
    }

    public void BindCategories()
    {
        UsuarioOut UO = ((UsuarioOut)Session["U_OUT"]);

        rptCategory.DataSource = UO.Slista_Empresas;
        rptCategory.DataBind();
        /*
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from tblCategories", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptCategory.DataSource = dtBrands;
                    rptCategory.DataBind();
                }

            }
        }*/
    }

    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string co_empresa = (e.Item.FindControl("hfCo_empresa") as HiddenField).Value;
            Repeater rptSubCategories = e.Item.FindControl("rptSubCategories") as Repeater;

            WsClientes.WsClientes wsc = new WsClientes.WsClientes();
            SucursalIn Sucur = new SucursalIn();
            Sucur.Co_usuario = ((UsuarioOut)Session["U_OUT"]).SUsuario_Codigo;
            Sucur.Co_empresa = co_empresa;
            try
            {
                SucursalOut[] arr_sucur = wsc.ConsultarSucursales(Sucur);
                if (arr_sucur.Length > 0)
                {
                    rptSubCategories.DataSource = arr_sucur;
                    rptSubCategories.DataBind();
                }
            }
            catch (Exception ex)
            { }
            /*String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM tblSubCategories WHERE MainCatID='{0}'", catId), con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        rptSubCategories.DataSource = dtBrands;
                        rptSubCategories.DataBind();
                    }

                }
            }*/
        }
    }
}