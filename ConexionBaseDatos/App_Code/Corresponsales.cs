using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Corresponsales
/// </summary>
public class Corresponsales
{
    public Corresponsales()
    {
        this.corCorresponsalId = 0;
        this.corNombre = "";
    }

    public Corresponsales(int corCorresponsalId, string corNombre)
    {
        this.corCorresponsalId = CorCorresponsalId;
        this.corNombre = CorNombre;
    }

    private int corCorresponsalId;

    public int CorCorresponsalId
    {
        get
        {
            return corCorresponsalId;
        }

        set
        {
            corCorresponsalId = value;
        }
    }

    public string CorNombre
    {
        get
        {
            return corNombre;
        }

        set
        {
            corNombre = value;
        }
    }

    private string corNombre;
}