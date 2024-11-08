using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using Web_Last_Project.ViewModels.Pages.Data.Resources;

namespace Web_Last_Project.ViewModels.Tools
{

    internal abstract class Page<T>
    {

        public T Data { get; set; }

        private protected T oldData { get; set; }

        public void Save()
        {
            ValidatePage();
            CheckingData();

            SaveData(Data);
        }

        private protected void Load()
        {
            InitOldData();

            oldData = LoadData();
        }

        private protected abstract void ValidatePage();
        private protected abstract void InitOldData();

        private protected abstract void CheckingData();

        private protected abstract void SaveData(T data);

        private protected abstract T LoadData();

        private protected string CheckingField(string checkedLine, int maxLength, int minLength, string regular)
        {
            if (maxLength == 0 || regular == string.Empty)
            {
                return checkedLine;
            }
            else if (checkedLine.Length >= minLength &&
                checkedLine.Length <= maxLength &&
                Regex.IsMatch(checkedLine, regular))
            {
                return checkedLine;
            }
            else
            {
                return null;
            }
        }

    }
}
