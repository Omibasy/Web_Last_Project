using System;
using System.Diagnostics;
using System.IO;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages.Data.ProjectTools
{
    internal class ProjectCardData : Page<Card>
    {
        public string pictureUrl { get; set; }

        private string _pathCard;

        private string _pathDescription;

        public bool isSave { get; private set; }

        public ProjectCardData(string relativePath)
        {
            isSave = false;

            _pathCard = Path.GetFullPath(relativePath);

            Load();
        }

        public ProjectCardData(string relativePath, string piturePath) : this(relativePath)
        {
            Data = oldData;

            pictureUrl = FaindPiture(piturePath);
        }

        public ProjectCardData(string relativePath, string descriptionPath, Card data)
        {
            isSave = false;

            _pathDescription = descriptionPath;
            _pathCard = relativePath;

            if (data == null)
            {
                Data = new Card()
                {
                    Title = string.Empty,
                    Alt = string.Empty,
                    Description = string.Empty,
                };

                pictureUrl = string.Empty;
            }
            else
            {
                Data = data;
            }
        }

        public void LoadDescription(string path)
        {
            path += ".json";

            _pathDescription = path;

            Data.Description = EmployeeWithFileJson.LoadData<string>(path);
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

        private protected override void InitOldData()
        {
            oldData = new Card();
        }

        private protected override void ValidatePage()
        {
            Data.Title = CheckingField(Data.Title, 70, 7, @"^[а-яА-Яa-zA-Z,&?!()_\s\-]+$");
            Data.Alt = CheckingField(Data.Alt, 104, 4, @"^[а-яА-Яa-zA-Z0-9,&?!()_\s\-]+$");
            Data.Description = CheckingField(Data.Description, 0, 7, string.Empty);
        }

        private protected override void CheckingData()
        {
            Data.file = null;

            if (oldData == null)
            {
                Data.Title = Data.Title == null ? "Не коректный ввод" + NewNumber() : Data.Title;
                Data.Alt = Data.Alt == null ? "Не коректный ввод" + NewNumber() : Data.Alt;
                Data.Description = Data.Description == null ? "Не коректный ввод" + NewNumber() : Data.Description;

                return;
            }

            Data.Title = Data.Title == null ? oldData.Title : Data.Title;
            Data.Alt = Data.Alt == null ? oldData.Alt : Data.Alt;
            Data.Description = Data.Description == null ? oldData.Description : Data.Description;
        }

        private protected override void SaveData(Card data)
        {
            if (_pathCard == string.Empty && _pathCard == null && _pathDescription == string.Empty && _pathDescription == null)
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

        private protected override Card LoadData()
        {
            return EmployeeWithFileJson.LoadData<Card>(_pathCard);
        }

        private static string NewNumber()
        {
            Random random = new Random();

            int numner = random.Next(0, 100000);

            return numner.ToString();
        }

        public void DeleteCard()
        {
            FileInfo fileInfoCard = new FileInfo(_pathCard);

            if (fileInfoCard.Exists)
            {
                fileInfoCard.Delete();
            }

            fileInfoCard = new FileInfo(_pathDescription);

            if (fileInfoCard.Exists)
            {
                fileInfoCard.Delete();
            }
        }

        private void OldSave(Card data)
        {
            EmployeeWithFileJson.Save(data.Description, _pathDescription);

            data.Description = null;

            EmployeeWithFileJson.Save(data, _pathCard);

            if (oldData.Title != data.Title)
            {
                string newNameCard = NewFileName(_pathCard);

                File.Move(_pathCard, newNameCard);

                newNameCard = NewFileName(_pathDescription);

                File.Move(_pathDescription, newNameCard);
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

            string newName = Data.Title.Length > 11 ? Data.Title.Substring(0, 11) : Data.Title;

            newNameFile += newName + ".json";

            return newNameFile;
        }

        private void NewSave(Card data)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_pathCard);
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            string newNameFile = data.Title.Length >= 11 ? data.Title.Substring(0, 11) + ".json" : data.Title + ".json";

            foreach (FileInfo file in fileInfo)
            {
                if (file.Name == newNameFile)
                {
                    isSave = false;
                    return;
                }
            }

            string newPath = _pathDescription + newNameFile;

            EmployeeWithFileJson.Save(data.Description, newPath);

            newPath = _pathCard + newNameFile;

            data.Description = null;

            EmployeeWithFileJson.Save(data, newPath);

            isSave = true;
        }
    }
}
