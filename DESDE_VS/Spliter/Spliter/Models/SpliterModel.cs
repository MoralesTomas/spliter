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
    public string contenido { get; set; }

    public string? cadenaBuscada { get; set; }

    public string? cadenaRemplazo { get; set; }


    public string[] splitear(string separador)
    {

        this.contenido = Regex.Replace(this.contenido, @"\s+", " ").Trim();

        this.contenido = Regex.Replace(this.contenido, @"\n+", "\n").Trim();

        return contenido.Split(separador);
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
