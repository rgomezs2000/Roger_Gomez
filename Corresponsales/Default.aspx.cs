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

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.
            corresponsales.DataSource = CreateDataSource();
            corresponsales.DataTextField = "COR_NOMBRE - counts";
            corresponsales.DataValueField = "COR_NOMBRE";

            // Bind the data to the control.
            corresponsales.DataBind();

            // Set the default selected item, if desired.
            corresponsales.SelectedIndex = 0;

        }

    }

    ICollection CreateDataSource()
    {
        string selectQuery = @"EXEC ListarCorresponsales";
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection("Server=DESKTOP-H962VE2;Initial;Integrated Security=SSPI;Database=cmmoneycash;"))
        {
            using (SqlCommand cmd = new SqlCommand(selectQuery, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }
        DataView dv = new DataView(dt);
        return dv;
    }



}