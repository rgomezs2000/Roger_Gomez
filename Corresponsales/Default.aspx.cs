using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConexionBaseDatos;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                CargarCorresponsales();
                int idCorresponsal = Convert.ToInt32(lisCorresponsales.SelectedValue.ToString());
                string nombreOficina = ObtenerCaracteresOficinas(idCorresponsal);
                MostrarCaracteres(nombreOficina);
            }
        }
        catch(Exception ex)
        {
            lblInfo.Text = lblInfo.Text + " . " + "<p>Ha ocurrido un error al cargar los corresponsales: (" + ex.Source + "): " + ex.Message + "</p>";
        }

    }


    public void CargarCorresponsales()
    {
        try
        {
            ConexionBaseDatosClient cliente = new ConexionBaseDatosClient();
            Corresponsales[] cor = cliente.ListarCorresponsales();

            foreach(Corresponsales corresponsal in cor)
            {
                lisCorresponsales.Items.Add(corresponsal.nombreCoresponsal + " - " + corresponsal.nroOficina.ToString());
                lisCorresponsales.Items[lisCorresponsales.Items.Count - 1].Value = corresponsal.idCorresponsales.ToString();
            }
            lblCorresponsal.Text = lisCorresponsales.SelectedValue.ToString();
        }
        catch
        {
            lblInfo.Text = "No se han podido cargar los corresponsales, verifique si hay corresponsales registrados o si el servicio se está ejecutando";
        }
    }

    protected void lisCorresponsales_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCorresponsal;
        idCorresponsal = Convert.ToInt32(lisCorresponsales.SelectedValue.ToString());
        string nombreOficina = ObtenerCaracteresOficinas(idCorresponsal);
        MostrarCaracteres(nombreOficina);
    }

    public void MostrarCaracteres(string nombreOficinaTabla)
    {
        nombreOficinaTabla = nombreOficinaTabla.ToLower();
        string nombreOficinaTablaDistinct = new string(nombreOficinaTabla.Trim().ToCharArray().Distinct().ToArray());
        nombreOficinaTablaDistinct = nombreOficinaTablaDistinct.Trim().Replace(" ", "").ToLower();
        tablaOficina.Rows.Clear();
        tablaOficina.Caption = "";
        int l = nombreOficinaTablaDistinct.Length;

        TablaCaracteres[] tablaCaractes = new TablaCaracteres[l];
        int countCaracteres = 0;

        for(int i = 0; i < l; i++)
        {
            string letra = nombreOficinaTablaDistinct.Substring(i, 1);
            long veces = nombreOficinaTabla.LongCount(sletra => sletra.ToString() == letra);
            tablaCaractes[countCaracteres] = new TablaCaracteres();
            tablaCaractes[countCaracteres].letra = letra;
            tablaCaractes[countCaracteres].veces = veces.ToString();

            countCaracteres++;
        }

    }

    public class TablaCaracteres
    {
        public string letra { get; set; }
        public string veces { get; set; }
    }

    public void Tabla(TablaCaracteres[] tablaCaracteres)
    {
        TableRow row;
        TableCell cell;

        TableHeaderRow tableHeaderRow = new TableHeaderRow();
        TableHeaderCell tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Letra";
        tableHeaderCell.Scope = TableHeaderScope.Column;
        tableHeaderRow.Cells.Add(tableHeaderCell);

        tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Veces";
        tableHeaderCell.Scope = TableHeaderScope.Column;
        tableHeaderRow.Cells.Add(tableHeaderCell);

        tablaOficina.Rows.Add(tableHeaderRow);
        tablaOficina.Rows.Add(tableHeaderRow);

        for(int filas = 0; filas < tablaCaracteres.Length; filas++)
        {
            row = new TableRow();

            cell = new TableCell();
            cell.Text = tablaCaracteres[filas].letra;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = tablaCaracteres[filas].veces;
            row.Cells.Add(cell);

            tablaOficina.Rows.Add(row);
        }
    }

    public string ObtenerCaracteresOficinas(int idCorresponsal)
    {
        ConexionBaseDatosClient cliente = new ConexionBaseDatosClient();
        Corresponsales cor = cliente.ObtenerCaracteresOficinas(idCorresponsal);
        lblCorresponsal.Text = cor.nombreCoresponsal;
        lblOficina.Text = cor.nombreOficina;
    }



}