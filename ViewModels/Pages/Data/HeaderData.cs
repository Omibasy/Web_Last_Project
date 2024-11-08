using Microsoft.Extensions.Configuration;
using System.Text.Encodings.Web;
using System.Text.Json;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;



namespace Web_Last_Project.ViewModels.Pages.Data
{
    internal class HeaderData : Page<HeadingAndFooter>
    {
        private string _path;
        public string Logo { get; private set; }

        public HeaderData(string relativePath) 
        {
             
            _path = Path.GetFullPath(relativePath);


            Load();
        }

        public HeaderData(string relativePath, string piturePath): this(relativePath)
        {             
            Data = oldData;
            Logo = FaindPath(piturePath);
        }

        private string FaindPath(string piturePath)
        {
            string path = Directory.GetCurrentDirectory() + piturePath;

            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] fileInfo = info.GetFiles();
                return fileInfo[0].Name;
            }
            catch
            {
                return "";
            }
        }

        private protected override void InitOldData()
        {
            oldData = new HeadingAndFooter();
        }



        private protected override void ValidatePage()
        {
            Data.CompanyName = CheckingField(Data.CompanyName, 20, 3, @"");
            Data.Footer = CheckingField(Data.Footer, 100, 4, @"");

            for (int i = 0; i < Data.HeadingMenu.Length; i++)
            {
                Data.HeadingMenu[i] = CheckingField(Data.HeadingMenu[i], 13, 3, @"^[а-яА-я]+$");
            }
        }

        private protected override void CheckingData()
        {
            Data.CompanyName = Data.CompanyName == null ? oldData.CompanyName : Data.CompanyName;
            Data.Footer = Data.Footer == null ? oldData.Footer : Data.Footer;
            Data.HeadingMenu = Data.HeadingMenu == null ? oldData.HeadingMenu : Data.HeadingMenu;

            for (int i = 0; i < Data.HeadingMenu.Length; i++)
            {
                Data.HeadingMenu[i] = Data.HeadingMenu[i] == null ? oldData.HeadingMenu[i] : Data.HeadingMenu[i];
            }

            Data.file = null;
        }

        private protected override void SaveData(HeadingAndFooter data)
        {
            EmployeeWithFileJson.Save<HeadingAndFooter>(data, _path);
        }

        private protected override HeadingAndFooter LoadData()
        {
            return EmployeeWithFileJson.LoadData<HeadingAndFooter>(_path);
        }
    }
}
