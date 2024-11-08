using Microsoft.AspNetCore.Mvc;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using System;
using System.Diagnostics;
using Web_Last_Project.ViewModels.Pages.Data.ServicesTools;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Services);

            ViewBag.Services = PageProvider.GetPage(NamePage.Services);

            return View();
        }


        public IActionResult Change()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Services);

            ViewBag.Services = PageProvider.GetPage(NamePage.Services);

            return View();
        }

        public IActionResult Add(int count)
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Services);

            if (count == -1)
            {
                ViewBag.ServicesItem = new LitleCard();

                return View();
            }
            else
            {
                ViewBag.ServicesItem = PageProvider.GetPage(NamePage.Services).ServicesPage[count].Data;

                return View();
            }

        }

        [HttpPost]
        public string Set([FromBody] LitleCard service)
        {
            ServicesData serviceData = PageProvider.GetPage(NamePage.NewServices);

            serviceData.Data = service;

            try
            {
                serviceData.Save();

                return "successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return "fail";
            }
        }

        [HttpPut]
        public string Edit([FromBody] LitleCard service)
        {
            ServicesList services = PageProvider.GetPage(NamePage.Services);

            string[] str = service.Title.Split('*');

            service.Title = str[0];

            int index = Convert.ToInt32(str[1]);         

            ServicesData serviceData = PageProvider.GetPage(NamePage.NewServices);

            serviceData.Data = service;

            try
            {
                services.Delete(index);

                serviceData.Save();

                return "successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return "fail";
            }      
        }

        [HttpDelete]
        public string Delete(int index)
        {
            ServicesList Services = PageProvider.GetPage(NamePage.Services);

            try
            {
                Services.Delete(index);

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
