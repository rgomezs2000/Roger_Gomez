using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Corresponsal
/// </summary>
public class Corresponsal
{
    public Corresponsal()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //

        this.IdCorresponsal = 0;
        this.NombreCorresponsal = "";

    }

    public Corresponsal(int idCorresponsal, string nombreCorresponsal)
    {
        this.IdCorresponsal = IdCorresponsal;
        this.NombreCorresponsal = NombreCorresponsal;
    }

    private int idCorresponsal;

    private string nombreCorresponsal;

    public int IdCorresponsal { get => idCorresponsal; set => idCorresponsal = value; }
    public string NombreCorresponsal { get => nombreCorresponsal; set => nombreCorresponsal = value; }
}