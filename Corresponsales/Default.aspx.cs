using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Data.Odbc;
using System.Data;
using Corresponsales;
using System.Collections;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            ListarCorresponsales();
            ConsultarOficinas(corresponsales.DataValueField);

        }

    }


    private void ListarCorresponsales()
    {
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-H962VE2;Initial;Integrated Security=SSPI;Database=cmmoneycash;");
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC ListarCorresponsales";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;
            conexion.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            corresponsales.DataSource = dt;
            corresponsales.DataBind();
            corresponsales.DataTextField = "COR_NOMBRE - counts";
            corresponsales.DataValueField = "COR_NOMBRE";
            conexion.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            conexion.Close();
        }
    }

    private void ConsultarOficinas(string corNombre)
    {
        SqlConnection conexion = new SqlConnection("Server=DESKTOP-H962VE2;Initial;Integrated Security=SSPI;Database=cmmoneycash;");
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC MostrarInicialesOficina";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;
            conexion.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            oficinas.DataSource = dt;
            oficinas.DataBind();
            conexion.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conexion.Close();
        }

    }



}