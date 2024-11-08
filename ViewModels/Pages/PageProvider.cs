using System.IO;
using Web_Last_Project.ViewModels.Pages.Data.ProjectTools;
using Web_Last_Project.ViewModels.Pages.Data.BlogTools;
using Web_Last_Project.ViewModels.Pages.Data.ServicesTools;
using Web_Last_Project.ViewModels.Pages.Data;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages
{
    internal static class PageProvider
    {
        public static dynamic GetPage(NamePage namePage)
        {
            switch (namePage)
            {
                case NamePage.BaseHeader:
                    return new HeaderData("ViewModels\\Pages\\Data\\Resources\\Json\\HeadingAndFooter.json");

                case NamePage.Header:            

                    return new HeaderData("ViewModels\\Pages\\Data\\Resources\\Json\\HeadingAndFooter.json", "\\wwwroot\\Layout\\img");

                case NamePage.BaseHero:
                    return new HeroData("ViewModels\\Pages\\Data\\Resources\\Json\\Hero.json");

                case NamePage.Hero:                

                    return new HeroData("ViewModels\\Pages\\Data\\Resources\\Json\\Hero.json", "\\wwwroot\\Hero\\img\\slides-img");
                case NamePage.BaseProjectListCards:

                    return new  ProjectListCardsData("ViewModels\\Pages\\Data\\Resources\\Json\\ProjectCards\\", "\\wwwroot\\Projects\\img");

                case NamePage.ProjectListCards:
                    return new ProjectListCardsData("ViewModels\\Pages\\Data\\Resources\\Json\\ProjectCards\\", "\\wwwroot\\Projects\\img", "ViewModels\\Pages\\Data\\Resources\\Json\\ProjectDescription\\");

                case NamePage.NewProjectsCard:
                    return new ProjectCardData("ViewModels\\Pages\\Data\\Resources\\Json\\ProjectCards\\", "ViewModels\\Pages\\Data\\Resources\\Json\\ProjectDescription\\", null);

                case NamePage.Services:
                    return new ServicesList("ViewModels\\Pages\\Data\\Resources\\Json\\ServicesRessources");

                case NamePage.NewServices:
                    return new ServicesData("ViewModels\\Pages\\Data\\Resources\\Json\\ServicesRessources", null);

                case NamePage.BlogListCards:
                    return new BlogListCardData("ViewModels\\Pages\\Data\\Resources\\Json\\BlogCards\\", "\\wwwroot\\Blog\\img");

                case NamePage.NewBlogCard:
                    return new BlogCardData("ViewModels\\Pages\\Data\\Resources\\Json\\BlogCards\\", "\\wwwroot\\Blog\\img", null);

                case NamePage.ContactsMain:
                    return new ContactsData("ViewModels\\Pages\\Data\\Resources\\Json\\ContactsRessources\\Main.json");

                default:
                    return null;
            }
            
        }


      


    }
}
