using Microsoft.AspNetCore.Mvc;

namespace Web_Last_Project.Component
{
    public class LogoutViewViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
