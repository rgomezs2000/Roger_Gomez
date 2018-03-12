using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IConexionBaseDatos" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IConexionBaseDatos
{
    [OperationContract]
    List<Corresponsales> ListarCorresponsales();

    [OperationContract]
    Corresponsales ObtenerCaracteresOficinas(int idCorresponsales);
}

[DataContract]
public class Corresponsales
{
    [DataMember]
    public int idCorresponsales { get; set; }

    [DataMember]
    public string nombreCoresponsal { get; set; }

    [DataMember]
    public string nombreOficina { get; set; }

    [DataMember]
    public int nroOficina { get; set; }
}

