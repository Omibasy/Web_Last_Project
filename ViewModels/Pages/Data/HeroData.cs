using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;


namespace Web_Last_Project.ViewModels.Pages.Data
{
    internal class HeroData : Page<Hero>
    {
        public List<string> SwiperSlidesPath { get; set; }

        private string _path;

        public HeroData(string relativePath)
        {            
            _path = Path.GetFullPath(relativePath);

            Load();

            Data = oldData;
        }

        public HeroData(string relativePath, string piturePath) : this(relativePath) 
        {
            FaindSlides(piturePath);
        }

        private protected override void InitOldData()
        {
            oldData = new Hero();
        }

        private void FaindSlides(string slidePath)
        {
            string path = Directory.GetCurrentDirectory() + slidePath;

            SwiperSlidesPath = new List<string>();

            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] fileInfo = info.GetFiles();

                for (int i = 0; i < Data.Slogans.Length; i++)
                {

                    for (int j = 0; j < fileInfo.Length; j++)
                    {
                        string[] fileName = fileInfo[j].Name.Split('.');

                        if (string.Equals(fileName[0], Data.Slogans[i].Substring(0, fileName[0].Length)))
                        {
                            SwiperSlidesPath.Add(fileInfo[j].Name);
                        }
                    }

                    if (SwiperSlidesPath.Count < (i + 1))
                    {
                        SwiperSlidesPath.Add("");
                    }

                }


            }
            catch
            {
                for (int i = 0; i < Data.Slogans.Length; i++)
                {
                    SwiperSlidesPath.Add("");
                }
            }
        }

        public void AddSlogan(string slideText)
        {
            string[] boxNewSlogan = new string[Data.Slogans.Length + 1];

            for (int i = 0; i < Data.Slogans.Length; i++)
            {
                boxNewSlogan[i] = Data.Slogans[i];
            }

            boxNewSlogan[boxNewSlogan.Length - 1] = slideText;

            Data.Slogans = boxNewSlogan;
        }
    


        private protected override void ValidatePage()
        {
            Data.Title = CheckingField(Data.Title, 25, 7, @"^[а-яА-Яa-zA-Z.,&?!()_\s\-]+$");
            Data.BtnText = CheckingField(Data.BtnText, 15, 2, @"^[а-яА-Я\s]+$");
            Data.BtnForm = CheckingField(Data.BtnForm, 15, 2, @"^[а-яА-Я\s]+$");
            Data.TitleForm = CheckingField(Data.TitleForm, 40, 7, @"^[а-яА-Я\s]+$");
            Data.PlaceholderName = CheckingField(Data.PlaceholderName, 25, 3, @"^[а-яА-Я*\s!.,<>]+$");
            Data.PlaceholderE_mail = CheckingField(Data.PlaceholderE_mail, 20, 4, @"^[а-яА-ЯA-Za-z*!.\s@,<>\-]+$");
            Data.PlaceholderTextArea = CheckingField(Data.PlaceholderTextArea, 22, 4, @"^[а-яА-Я*!.,<>\s\-]+$");

            for (int i = 0; i < Data.Slogans.Length; i++)
            {
                Data.Slogans[i] = CheckingField(Data.Slogans[i], 32, 7, @"^[а-яА-Я\s0-9]+$");
            }
        }

        private protected override void CheckingData()
        {
            Data.Title = Data.Title == null ? oldData.Title : Data.Title;
            Data.BtnForm = Data.BtnForm == null ? oldData.BtnForm : Data.BtnForm;
            Data.BtnText = Data.BtnText == null ? oldData.BtnText : Data.BtnText;
            Data.TitleForm = Data.TitleForm == null ? oldData.TitleForm : Data.TitleForm;
            Data.PlaceholderName = Data.PlaceholderName == null ? oldData.PlaceholderName : Data.PlaceholderName;
            Data.PlaceholderE_mail = Data.PlaceholderE_mail == null ? oldData.PlaceholderE_mail : Data.PlaceholderE_mail;
            Data.PlaceholderTextArea = Data.PlaceholderTextArea == null ? oldData.PlaceholderTextArea : Data.PlaceholderTextArea;
            Data.Slogans = Data.Slogans == null ? oldData.Slogans : Data.Slogans;

            for (int i = 0; i < Data.Slogans.Length; i++)
            {
                Data.Slogans[i] = Data.Slogans[i] == null ? oldData.Slogans[i] : Data.Slogans[i];
            }

            Data.files = null;
        }

        private protected override void SaveData(Hero data)
        {
            EmployeeWithFileJson.Save<Hero>(data, _path);
        }

        private protected override Hero LoadData()
        {
            return EmployeeWithFileJson.LoadData<Hero>(_path);
        }
    }
}
