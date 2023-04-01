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

        if(cadena != null){
            // string val = cadena.contenido;
            return View("Index",cadena);
        }
        spliter tmp = new spliter();
        tmp.contenido = "/";
        return View( tmp );
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
        else{

            Console.WriteLine($"el modelo no es valido elimB");

            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp = new spliter();
            return Index( tmp );
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
        else{
            
            Console.WriteLine($"el modelo no es valido elimS");
            
            ViewData["result"] = "No se pudo realizar el analisis";
            spliter tmp_tm = new spliter();
            return Index( tmp_tm );
        }
    }

    [HttpPost]
    public IActionResult Reset_box()
    {        
            ViewData["contenido"] = "limpi0";
            ViewData["result"] = " ";
            spliter tmp = new spliter();
            tmp.contenido = "";
            return Index( tmp );
    }

    public IActionResult RemplazarContenido( [Bind("contenido,cadenaBuscada,cadenaRemplazo")] spliter tmp )
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"el modelo es valido elimS");

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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About(){
        return View(); 
    }

    public IActionResult Contact(){
        return View(); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
