using Microsoft.AspNetCore.Mvc;
using Web_Last_Project.ViewModels.Pages;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;
using System.Diagnostics;
using System.IO;
using Web_Last_Project.ViewModels.Pages.Data.BlogTools;

namespace Web_Last_Project.Controllers.ViewControllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public BlogController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);
            ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).GetFullCards();

            return View();
        }

        public IActionResult Card(int id)
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);
            ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).FaindCard(id);

            return View();
        }

        public IActionResult Editable()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);

            ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).GetFullCards();

            return View();

        }


        public IActionResult Change(int id)
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);
            ViewBag.Blog = PageProvider.GetPage(NamePage.BlogListCards).FaindCard(id);

            ViewBag.CardID = id.ToString();

            return View();

        }

        public IActionResult Add()
        {
            ViewBag.MenuSelect = ChackAdmin.IsSelectedMenuItem(Menu.Blog);

            return View();
        }

        [HttpPost]
        public string Set([FromBody] BigCard bigCard)
        {
            BlogCardData blogtCard = PageProvider.GetPage(NamePage.NewBlogCard);

            blogtCard.Data = bigCard;

            string file = bigCard.file;

            string path = _appEnvironment.WebRootPath + $"/Blog/img/";

            try
            {
                blogtCard.Save();

                if (blogtCard.isSave == true)
                {
                    WorkingPicture.AddPicture(file, path, blogtCard.Data.Alt);
                }
                else
                {
                    return "fail";
                }

                return "successfully";
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return "fail";
            }

        }

        [HttpDelete]
        public string Delete(int id)
        {
            BlogCardData blogCard = PageProvider.GetPage(NamePage.BlogListCards).FaindCard(id);

            string path = _appEnvironment.WebRootPath + $"/Blog/img/";

            try
            {
                WorkingPicture.RemovePicture(path, blogCard.Data.Alt);

                blogCard.DeleteCard();

                return "successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return "fail";
            }
        }

        [HttpPut]
        public string Edit([FromBody] BigCard Card)
        {
            BlogCardData blogCard;

            try
            {
                blogCard = PageProvider.GetPage(NamePage.BlogListCards).FaindCard(Convert.ToInt32(Card.Alt));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return "fail";
            }

            Card.Alt = blogCard.Data.Alt;

            string file = Card.file;
            string path = _appEnvironment.WebRootPath + $"/Blog/img/";

            blogCard.Data = Card;

            try
            {
                blogCard.Save();

                if (file != null && file != string.Empty && file.Length > 100)
                {
                    if (blogCard.isSave == true)
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


            return "successfully";
        }
    }
}
