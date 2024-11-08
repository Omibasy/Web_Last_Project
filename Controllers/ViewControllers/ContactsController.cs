using Microsoft.AspNetCore.Mvc;
using Web_Last_Project.ViewModels.Pages;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Contacts);

            ViewBag.ContactsMain = PageProvider.GetPage(NamePage.ContactsMain);

            return View();
        }
    }
}
