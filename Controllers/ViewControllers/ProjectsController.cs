using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Pages.Data.ProjectTools;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class ProjectsController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ProjectsController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);
            ViewBag.Projects = PageProvider.GetPage(NamePage.BaseProjectListCards).GetFullCards();

            return View();
        }

        public IActionResult Card(string cardName)
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);
            ViewBag.CardData = PageProvider.GetPage(NamePage.ProjectListCards).FaindCard(cardName);

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);

            return View();
        }

        public IActionResult Editable()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);

            ViewBag.Projects = PageProvider.GetPage(NamePage.BaseProjectListCards).GetFullCards();

            return View();
        }

        public IActionResult Changet(string title)
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Project);

            string[] str = title.Split('*');

            ProjectCardData projectCard = PageProvider.GetPage(NamePage.ProjectListCards).FaindCard(str[0]);

            ViewBag.CardID = str[1];

            ViewBag.Card = projectCard;

            return View();
        }

        [HttpPost]
        public string Set([FromBody] Card card)
        {
            ProjectCardData projectCard = PageProvider.GetPage(NamePage.NewProjectsCard);

            string path = _appEnvironment.WebRootPath + $"/Projects/img/";

            projectCard.Data = card;

            string file = card.file;

            try
            {
                projectCard.Save();

                if (projectCard.isSave == true)
                {
                    WorkingPicture.AddPicture(file, path, projectCard.Data.Alt);
                }
                else
                {
                    return "fail";
                }

                return "successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        public string Edit([FromBody] Card card)
        {
            string[] str = card.Alt.Split("*");

            if (str.Length <= 1)
            {
                return "fail";
            }
            else
            {
                card.Alt = str[0];

                ProjectCardData projectCard;

                try
                {
                    projectCard = PageProvider.GetPage(NamePage.ProjectListCards).FaindCard(Convert.ToInt32(str[1]));
                }
                catch (Exception)
                {
                    return "fail";
                }

                string file = card.file;
                string path = _appEnvironment.WebRootPath + $"/Projects/img/";

                projectCard.Data = card;

                try
                {
                    projectCard.Save();

                    if (file != null && file != string.Empty && file.Length > 100)
                    {
                        if (projectCard.isSave == true)
                        {
                            WorkingPicture.EditPicture(file, path);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);

                    return "fail";
                }

            }

            return "successfully";
        }

        [HttpDelete]
        public string Delete(string title)
        {
            ProjectCardData projectCard = PageProvider.GetPage(NamePage.ProjectListCards).FaindCard(title);

            string path = _appEnvironment.WebRootPath + $"/Projects/img/";

            try
            {
                WorkingPicture.RemovePicture(path, projectCard.Data.Alt);

                projectCard.DeleteCard();

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
