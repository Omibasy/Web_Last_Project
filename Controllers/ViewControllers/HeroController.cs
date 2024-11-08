using Microsoft.AspNetCore.Mvc;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Pages.Data;
using Web_Last_Project.ViewModels.Tools.DeliverymanHero;
using Web_Last_Project.ViewModels.Tools;
using System.Diagnostics;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class HeroController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public HeroController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Hero);

            ViewBag.Hero = PageProvider.GetPage(NamePage.Hero);

            return View();
        }

        public IActionResult IndexAdmin()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Hero);

            ViewBag.Hero = PageProvider.GetPage(NamePage.Hero);

            return View();
        }

        public IActionResult Update()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Hero);

            ViewBag.Hero = PageProvider.GetPage(NamePage.Hero);

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Hero);

            return View();
        }

        [HttpPost]
        public string Set([FromBody] HeroSlide package)
        {
            HeroData heroData = PageProvider.GetPage(NamePage.BaseHero);

            string path = _appEnvironment.WebRootPath + $"/Hero/img/slides-img/";

            heroData.AddSlogan(package.slideText);

            try
            {
                heroData.Save();

                WorkingPicture.AddPicture(package.fileBit, path);

                return "successfully";
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return "fail";
            }
        }

        [HttpPut]
        public string Update([FromBody] Hero packageHero)
        {
            HeroData heroData = PageProvider.GetPage(NamePage.BaseHero);

            string path = _appEnvironment.WebRootPath + $"/Hero/img/slides-img/";

            try
            {
                for (int i = 0; i < packageHero.files.Length; i++)
                {

                    if (packageHero.files[i].Length > 5)
                    {
                        WorkingPicture.EditPicture(packageHero.files[i], path);
                    }
                    else
                    {
                        int number = Convert.ToInt32(packageHero.files[i]);

                        string fileName = heroData.Data.Slogans[number];

                        if (fileName.Length > 8)
                        {
                            fileName = fileName.Substring(0, 8);
                        }

                        WorkingPicture.RemovePicture(path, fileName);
                    }
                }

                heroData.Data = packageHero;
                heroData.Save();

                return "successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return "fail";
            }
        }
    }
}
