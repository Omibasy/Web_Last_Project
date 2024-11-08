using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages.Data
{
    internal class ContactsData : Page<Contacts>
    {

        private string _path;

        public ContactsData(string relativePath) 
        {
            _path = Path.GetFullPath(relativePath);

            Load();

            Data = oldData;
        }

        private protected override void CheckingData()
        {
            
        }

        private protected override void InitOldData()
        {
            oldData = new Contacts();
        }

        private protected override void SaveData(Contacts data)
        {
            EmployeeWithFileJson.Save<Contacts>(data, _path);
        }

        private protected override Contacts LoadData()
        {
            return EmployeeWithFileJson.LoadData<Contacts>(_path);
        }

        private protected override void ValidatePage()
        {
            
        }
    }
}
