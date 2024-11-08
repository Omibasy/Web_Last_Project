using System.Diagnostics;
using System.Reflection.PortableExecutable;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages.Data.BlogTools
{
    internal class BlogCardData : Page<BigCard>
    {
        private string _pathCard;

        public string pictureUrl { get; set; }

        public bool isSave { get; private set; }

        public BlogCardData(string path)
        {
            isSave = false;

            _pathCard = Path.GetFullPath(path);

            Load();

        }

        public BlogCardData(string path, string pathPicture) : this(path)
        {
            Data = oldData;

            pictureUrl = FaindPiture(pathPicture);

        }

        public BlogCardData(string path, string pathPicture, BigCard data)
        {
            isSave = false;

            _pathCard = path;

            if (data == null)
            {
                Data = new BigCard()
                {
                    dateTime = DateTime.Now,
                    Title = string.Empty,
                    Alt = string.Empty,
                    Description = string.Empty,
                };

                pictureUrl = pathPicture;
            }
            else
            {
                Data = data;
            }

        }

        private protected override void CheckingData()
        {
            Data.file = null;

            if (oldData == null)
            {
                Data.Title = Data.Title == null ? "Не коректный ввод" : Data.Title;
                Data.Alt = Data.Alt == null ? "Не коректный ввод" : Data.Alt;
                Data.Description = Data.Description == null ? "Не коректный ввод" : Data.Description;

                return;
            }

            Data.Title = Data.Title == null ? oldData.Title : Data.Title;
            Data.Alt = Data.Alt == null ? oldData.Alt : Data.Alt;
            Data.Description = Data.Description == null ? oldData.Description : Data.Description;
        }
        private protected override void ValidatePage()
        {
            Data.Title = CheckingField(Data.Title, 70, 7, @"^[а-яА-Яa-zA-Z,&?!()_\s\-]+$");
            Data.Alt = CheckingField(Data.Alt, 104, 4, @"^[а-яА-Яa-zA-Z0-9,&?!()_\s\-]+$");
            Data.dateTime = Data.dateTime <= new DateTime(2010, 1, 1) ? DateTime.Now : Data.dateTime;
            Data.Description = CheckingField(Data.Description, 0, 7, string.Empty);
        }


        private protected override void InitOldData()
        {
            oldData = new BigCard();
        }

        private protected override BigCard LoadData()
        {
            return EmployeeWithFileJson.LoadData<BigCard>(_pathCard);
        }

        private protected override void SaveData(BigCard data)
        {
            if (_pathCard == string.Empty && _pathCard == null)
            {
                isSave = false;
                return;
            }

            if (oldData == null)
            {
                NewSave(data);
            }
            else
            {
                OldSave(data);
            }

        }

        private void NewSave(BigCard data)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_pathCard);
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            string newNameFile = Data.dateTime.ToString("yyyy.MM.dd");

            newNameFile = newNameFile + ".json";

            foreach (FileInfo file in fileInfo)
            {
                if (file.Name == newNameFile)
                {
                    isSave = false;
                    return;
                }
            }

            string newPath = _pathCard + newNameFile;

            EmployeeWithFileJson.Save(data, newPath);

            isSave = true;
        }

        private void OldSave(BigCard data)
        {
            EmployeeWithFileJson.Save(data, _pathCard);

            if (oldData.dateTime != data.dateTime)
            {
                string newNameCard = NewFileName(_pathCard);

                File.Move(_pathCard, newNameCard);
            }

            isSave = true;
        }

        private string NewFileName(string _path)
        {
            string newNameFile = string.Empty;

            string[] str = _path.Split("\\");

            for (int i = 0; i < str.Length - 1; i++)
            {
                newNameFile += str[i] + "\\";
            }

            string newName = Data.dateTime.ToString("yyyy.MM.dd");

            newNameFile += newName + ".json";

            return newNameFile;
        }

        private string FaindPiture(string piturePath)
        {
            string path = Directory.GetCurrentDirectory() + piturePath;


            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] fileInfo = info.GetFiles();

                for (int j = 0; j < fileInfo.Length; j++)
                {
                    string[] fileName = fileInfo[j].Name.Split('.');

                    if (string.Equals(fileName[0], Data.Alt))
                    {
                        return fileInfo[j].Name;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return string.Empty;
        }

        public void DeleteCard()
        {
            FileInfo fileInfoCard = new FileInfo(_pathCard);

            if (fileInfoCard.Exists)
            {
                fileInfoCard.Delete();
            }
        }

    }
}
