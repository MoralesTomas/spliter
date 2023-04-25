using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Spliter.Models;


public class spliter
{
    public spliter()
    {

    }
    public string? contenido { get; set; }
    public int Opcion { get; set; }     //propiedad que nos ayudara a distinguir la opcion que deseemos ejecutar.

    public string? cadenaBuscada { get; set; }

    public string? cadenaRemplazo { get; set; }
    public string? separador { get; set; }

    public string[]? contenidoSpliter { get; set; }

    #region explicacion de la propiedad Opcion
    /*
     *Esto nos ayudara a manejar mejor las opciones del usuario
     *
     *1->Limpiar caja de entrada
     *2->Eliminar espacios en blanco
     *3->Eliminar saltos de linea
     *4->Remplazar contenido.
     *
     */
    #endregion


    public void splitear()
    {
        try
        {
            if( this.separador == null )
            {
                separador = " ";
            }

            this.contenidoSpliter = this.contenido.Split(this.separador);

        }catch( Exception ex)
        {
            string[] arreglo = { "No se pudo realizar el analisis" };
            this.contenidoSpliter =  arreglo;
        }
    }

    public string eliminarBlanco()
    {
        if (this.contenido == null || this.contenido == string.Empty)
        {
            this.contenido = "sin contenido";
        }

        this.contenido = this.contenido.Replace("\r", "");

        return Regex.Replace(this.contenido, @" +", " ").Trim();
    }

    public string eliminarSalto()
    {
        Console.WriteLine($"desde la funcion");

        if (this.contenido == null || this.contenido == string.Empty)
        {
            this.contenido = "sin contenido";
        }

        this.contenido = this.contenido.Replace("\r", "");

        return Regex.Replace(this.contenido, @"[\n][\n]+", "\n\n").Trim();
    }


    //funcion para remplazar en base a una expresion regular.
    public string reemplzarString()
    {
        Console.WriteLine($"desde la funcion");

        if (this.contenido == null || this.contenido == string.Empty)
        {
            this.contenido = "sin contenido";
        }

        this.contenido = this.contenido.Replace("\r", "");

        string cad_1 = this.cadenaBuscada + "+";

        string resultado = "No se pudo realizar...";
        try
        {
            return Regex.Replace(this.contenido, cad_1, this.cadenaRemplazo).Trim();
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
            return resultado;
        }
    }

}
