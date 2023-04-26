using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spliter.Models;
namespace Spliter.Controllers;

public class SpliterController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public SpliterController()
    {

    }

    public IActionResult Index(spliter? cadena)
    {

        if (cadena != null)
        {

            return View( "Index",cadena );
        }
        spliter tmp = new spliter();
        tmp.contenido = "";
        ViewData["result"] = "Sin contenido...";
        return View( "Index", tmp );
    }


    [HttpPost]
    public IActionResult Evaluar(spliter obj)
    {
        try
        {
            if (obj == null)
            {
                return Index( null );
            }

            Console.WriteLine("L 32");
            //realizar la evaluacion
            switch (obj.Opcion)
            {
                case 1:
                    return Reset_box();
                case 2:
                    return eliminarBlanco(obj);

                case 3:
                    return eliminarSalto(obj);

                case 4:
                    return RemplazarContenido(obj);
                case 5:
                    return AplicarSplit( obj );
                default:
                    Console.WriteLine("Ocurrio un error...");
                    ViewData["result"] = "Seleccione una opcion valida...";
                    return Index( obj );

            }


        }
        catch (Exception ex)
        {

            Console.WriteLine("Ocurrio un error en el lado del controlador...");
            Console.WriteLine(ex.Message);
            return Index(null);
        }

    }


    [HttpPost]
    public IActionResult eliminarBlanco([Bind("contenido")] spliter spli)
    {

        if (ModelState.IsValid)
        {
            Console.WriteLine($"el modelo es valido elimB");

            ViewData["result"] = spli.eliminarBlanco();
            return Index(spli);
        }
        else
        {

            Console.WriteLine($"el modelo no es valido elimB");

            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp = new spliter();
            return Index(tmp);
        }
    }

    [HttpPost]
    public IActionResult eliminarSalto([Bind("contenido")] spliter tmp)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"el modelo es valido elimS");

            ViewData["result"] = tmp.eliminarSalto();

            return Index(tmp);
        }
        else
        {

            Console.WriteLine($"el modelo no es valido elimS");

            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp_tm = new spliter();
            return Index(tmp_tm);
        }
    }

    [HttpPost]
    public IActionResult Reset_box()
    {
        ViewData["contenido"] = " ";
        ViewData["result"] = " ";
        spliter tmp = new spliter();
        tmp.contenido = "";

        Console.WriteLine("DESDE RESET BOX");

        return Index(tmp);
    }

    public IActionResult RemplazarContenido([Bind("contenido,cadenaBuscada,cadenaRemplazo")] spliter tmp)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"el modelo es valido RemplazarContenido");

            ViewData["result"] = tmp.reemplzarString();

            return Index(tmp);
        }
        else
        {

            Console.WriteLine($"el modelo no es valido elimS");

            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp_tm = new spliter();
            return Index(tmp_tm);
        }
    }

    public IActionResult AplicarSplit([Bind("contenido,separador")] spliter tmp)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"el modelo es valido aplicarSplit");

            //realizar el metodo splitear.
            tmp.splitear();

            ViewData["result"] = "Visualice la tabla que se encuentra debajo de este componente.";

            return Index(tmp);
        }
        else
        {

            Console.WriteLine($"el modelo no es valido aplicarSplit");

            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp_tm = new spliter();
            return Index(tmp_tm);
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Instrucciones()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
