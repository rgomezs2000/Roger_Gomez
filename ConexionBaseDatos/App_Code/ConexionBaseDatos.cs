using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "ConexionBaseDatos" en el código, en svc y en el archivo de configuración a la vez.

public class ConexionBaseDatos : IConexionBaseDatos
{
    string strConn;

    public ConexionBaseDatos()
    {
        strConn = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();
    }

    public List<Corresponsales> ListarCorresponsales()
    {
        string strQuery = "EXEC ListarCorresponsales";

        using (SqlConnection conn = new SqlConnection(strConn))
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataReader read = cmd.ExecuteReader();
            List<Corresponsales> corresponsales = new List<Corresponsales>();

            if (read.HasRows)
            {
                while (read.Read())
                {

                    Corresponsales cor = new Corresponsales()
                    {
                        idCorresponsales = Convert.ToInt32(read["COR_CORRESPONSAL_ID"]),
                        nombreCoresponsal = read["COR_NOMBRE"].ToString(),
                        nroOficina = Convert.ToInt32(read["COR_NRO_OFI"])
                    };
                    corresponsales.Add(cor);
                }

            }

            return corresponsales;

        }

    }

    public Corresponsales ObtenerCaracteresOficinas(int idCorresponsal)
    {
        try
        {
            string strQuery = "ContarCaracteres" + idCorresponsal.ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataReader read = cmd.ExecuteReader();

                read.Read();

                Corresponsales cor = new Corresponsales()
                {
                    idCorresponsales = Convert.ToInt32(read["COR_CORRESPONSAL_ID"]),
                    nombreCoresponsal = read["COR_NOMBRE"].ToString(),
                    nombreOficina = read["OFI_NOMBRE"].ToString()
                };

                return cor;
            }

        }
        catch
        {
            return null;
        }
    }

}