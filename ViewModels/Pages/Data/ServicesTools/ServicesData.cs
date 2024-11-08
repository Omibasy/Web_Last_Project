using System.Runtime.InteropServices;
using System.Xml.Linq;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages.Data.ServicesTools
{
    internal class ServicesData : Page<LitleCard>
    {
        private string _path;

        public ServicesData(string path)
        {
            _path = Path.GetFullPath(path);

            Load();

            Data = oldData;
        }

        public ServicesData(string relativePath, LitleCard data)
        {
            _path = relativePath;

            if (data == null)
            {
                Data = new LitleCard()
                {
                    Title = string.Empty,
                    Description = string.Empty,
                };
            }
            else
            {
                Data = data;
            }
        }

        private protected override void CheckingData()
        {
            if (oldData == null)
            {
                Data.Title = Data.Title == null ? "Не коректный ввод" : Data.Title;
                Data.Description = Data.Description == null ? "Не коректный ввод" : Data.Description;

                return;
            }

            Data.Title = Data.Title == null ? oldData.Title : Data.Title;
            Data.Description = Data.Description == null ? oldData.Description : Data.Description;
        }

        private protected override void ValidatePage()
        {
            Data.Title = CheckingField(Data.Title, 70, 7, @"^[а-яА-Яa-zA-Z,&?!()_\s\-]+$");
            Data.Description = CheckingField(Data.Description, 0, 7, string.Empty);
        }


        private protected override void InitOldData()
        {
            oldData = new LitleCard();
        }

        private protected override LitleCard LoadData()
        {
            return EmployeeWithFileJson.LoadData<LitleCard>(_path);
        }

        private protected override void SaveData(LitleCard data)
        {
            string name = string.Empty;

            name = data.Title.Length > 11 ? data.Title.Substring(0, 11) : data.Title;

            string[] strings = _path.Split('\\');

            _path = string.Empty;

            foreach (string s in strings)
            {
                _path += s + "\\";
            }

            EmployeeWithFileJson.Save(data, _path + name + ".json");
        }

        public string GetPath()
        {
            return _path;
        }
    }
}
