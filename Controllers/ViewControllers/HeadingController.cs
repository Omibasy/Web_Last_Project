using Microsoft.AspNetCore.Mvc;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Pages.Data;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Tools;
using System.Diagnostics;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class HeadingController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public HeadingController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Heading);

            return View();
        }

        public IActionResult Change()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Heading);

            return View();
        }

        [HttpPut]
        public string Set([FromBody] HeadingAndFooter packageHeading)
        {

            string path = _appEnvironment.WebRootPath + $"/Layout/img/";

            try
            {
                if (packageHeading.file != null && packageHeading.file != string.Empty)
                {
                    WorkingPicture.EditPicture(packageHeading.file, path);
                }

                HeaderData header = PageProvider.GetPage(NamePage.BaseHeader);

                header.Data = packageHeading;
                header.Save();

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
