using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Resources;
using System.Text.Encodings.Web;
using System.Text.Json;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Pages.Data;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;



namespace Web_Last_Project.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Hero);

            ViewBag.Hero = PageProvider.GetPage(NamePage.Hero);
            ViewBag.Projects = PageProvider.GetPage(NamePage.BaseProjectListCards).GetFullCards();
            ViewBag.Services = PageProvider.GetPage(NamePage.Services);
            ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).GetFullCards();
            ViewBag.ContactsMain = PageProvider.GetPage(NamePage.ContactsMain);


            //ContactsData contacts = new ContactsData("ViewModels\\Pages\\Data\\Resources\\Json\\ContactsRessources\\Main.json");

            //Contacts data = new Contacts() 
            //{ 
            //Name = "Иванов Иван Иванович",
            //Address = "115088, г.Москва ул. Симоновский Вал. 16к2",
            //Fax = "+7-(989)-345-22-00",
            //Phone = "+7-(989)-345-22-00",
            //Email = "SkillProfi@mail.ru",
            //Coordinates = new double[] { 55.72208310323157, 37.66080472023767 }

            //}; 

            //contacts.Data.Coordinates

            //contacts.Data = data;

            //contacts.Save();

            return View();
        }


     



        ////для админа
        //public IActionResult Projects()
        //{
        //    ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);


        //    ViewBag.Projects = PageProvider.GetPage(NamePage.BaseProjectListCards).GetFullCards();

        //    return View();
        //}

        //public IActionResult Services()
        //{
        //    ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Services);

        //    ViewBag.Services = PageProvider.GetPage(NamePage.Services);

        //    return View();
        //}

        //public async Task<IActionResult> Blog()
        //{
        //    return await Task.Factory.StartNew(() =>
        //    {
        //        ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);

        //        ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).GetFullCards();

        //        return View();

        //    });
        //}

        public async Task<IActionResult> Admin()
        {
            return await Task.Factory.StartNew(() =>
            {

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                if (ChackAdmin.Chack)
                {
                    ChackAdmin.Chack = false;

                    return Redirect("~/Home/Index");
                }
                else
                {
                    ChackAdmin.Chack = true;

                    return Redirect("~/Hero/IndexAdmin");
                }
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx4

              

            });
        }


    }
}
