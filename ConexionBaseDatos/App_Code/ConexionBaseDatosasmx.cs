using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Data.Odbc;

/// <summary>
/// Descripción breve de ConexionBaseDatosasmx
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
//[System.Web.Script.Services.ScriptService]
public class ConexionBaseDatosasmx : System.Web.Services.WebService
{

    [WebMethod]
    public Corresponsales ListarCorresponsales()
    {
        Corresponsales corresponsales = new Corresponsales();
        using (SqlConnection conn = new SqlConnection(connectionString: "Data Source=./SQLEXPRESS;Initial Catalog=cmmoneycash;Integrated Security=SSPI;"))
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = "EXEC ListarCorresponsales";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        corresponsales.CorCorresponsalId = int.Parse(reader["COR_CORRESPONSAL_ID"].ToString());
                        corresponsales.CorNombre = reader["CONT_OFICINA"].ToString();
                    }
                }

                conn.Close();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        return corresponsales;
    }

}
