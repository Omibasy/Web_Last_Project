using Microsoft.AspNetCore.Mvc;

namespace Web_Last_Project.Controllers
{
    public class ExceptionController : Controller
    {
        public  IActionResult Mistake()
        {       
            return View();         
        }
    }
}
