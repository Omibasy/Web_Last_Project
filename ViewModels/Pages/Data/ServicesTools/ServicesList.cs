using System;
using System.IO;
using Web_Last_Project.ViewModels.Pages.Data.Resources;
using Web_Last_Project.ViewModels.Tools;

namespace Web_Last_Project.ViewModels.Pages.Data.ServicesTools
{
    internal class ServicesList
    {
        public ServicesData[] ServicesPage { get; private set; }

        public ServicesList(string path)
        {
            InitServices(path);
        }

        private void InitServices(string path)
        {

            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] fileInfo = info.GetFiles();

            ServicesPage = new ServicesData[fileInfo.Length];


            for (int i = 0; i < ServicesPage.Length; i++)
            {
                ServicesPage[i] = new ServicesData(path + "\\" + fileInfo[i].Name);
            }
        }

        public void Delete(int index)
        {
            FileInfo fileInfo = new FileInfo(ServicesPage[index].GetPath());

            if (fileInfo.Exists)
            {
                fileInfo.Delete();

            }
        }

    }
}
