using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Oficinas
/// </summary>
public class Oficinas
{
    public Oficinas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
        this.IdCorresponsal = 0;
        this.nombreOficina = "";

    }

    public Oficinas(int idCorresponsal, string nombreOficina)
    {
        this.IdCorresponsal = IdCorresponsal;
        this.nombreOficina = NombreOficina;
    }

    private int idCorresponsal;

    public int IdCorresponsal { get => idCorresponsal; set => idCorresponsal = value; }
    public string NombreOficina { get => nombreOficina; set => nombreOficina = value; }

    private string nombreOficina;
}