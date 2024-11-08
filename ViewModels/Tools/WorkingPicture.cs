using System;
using System.IO;

namespace Web_Last_Project.ViewModels.Tools
{
    internal static class WorkingPicture
    {

        public static bool  AddPicture(string dataFile, string pathFile)
        {
       

                string[] data = dataFile.Split('.');

            if (AuthenticityOfName(pathFile, data[1]))
            {
                return false;
            }


            byte[] bytesFile = ConvertArrayBytes(data[0]);

                string path = pathFile + data[1] + '.' + NewNumber() + '.' + data[2];

                SavePhoto(bytesFile, path);


            return true;
        }

        public static bool AddPicture(string dataFile, string pathFile, string fileName)
        {
            if (AuthenticityOfName(pathFile, fileName))
            {
                return false;
            }

            string[] data = dataFile.Split('.');

            byte[] bytesFile = ConvertArrayBytes(data[0]);

            string path = pathFile + fileName + '.' + NewNumber() + '.' + data[2];

            SavePhoto(bytesFile, path);

            return true;
        }

        private static byte[] ConvertArrayBytes(string dataFile)
        {
            string[] arrayStr = dataFile.Split(',');
            byte[] ArrayFile = new byte[(arrayStr.Length)];

            for (int i = 0; i < ArrayFile.Length; i++)
            {
                ArrayFile[i] = Convert.ToByte(arrayStr[i]);
            }

            return ArrayFile;
        }

        private static string NewNumber()
        {
            Random random = new Random();

            int numner = random.Next(0, 100000);

            return numner.ToString();
        }

        private static void SavePhoto(byte[] dataFile, string pathPhoto)
        {
            if (dataFile != null)
            {
                System.IO.File.WriteAllBytes(pathPhoto, dataFile);
            }
        }

        public static void EditPicture(string dataFile, string pathFile)
        {

                string[] data = dataFile.Split('.');

                byte[] bytesFile = ConvertArrayBytes(data[0]);

                DirectoryInfo info = new DirectoryInfo(pathFile);
                FileInfo[] fileInfo = info.GetFiles();

                for (int i = 0; i < fileInfo.Length; i++)
                {
                    string[] str = fileInfo[i].Name.Split('.');

                    if (str[0] == data[1])
                    {
                        if (fileInfo[i].Exists)
                        {
                            fileInfo[i].Delete();
                            break;
                        }
                    }
                }

                string newPath = pathFile + data[1] + '.' + NewNumber() + '.' + data[2];

                SavePhoto(bytesFile, newPath);          
        }


        public static bool RemovePicture(string pathFile, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(pathFile);
            FileInfo[] fileInfo = info.GetFiles();

            for (int j = 0; j < fileInfo.Length; j++)
            {
                string[] oldFile = fileInfo[j].Name.Split('.');

                if (oldFile[0] == fileName)
                {
                    if (fileInfo[j].Exists)
                    {
                        fileInfo[j].Delete();
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool AuthenticityOfName(string path, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] fileInfo = info.GetFiles();

            
            foreach (FileInfo file in fileInfo) 
            {
                string str = file.Name.Split('.')[0];

                if ( str == fileName)
                {
                    return true;
                }
            
            }

            return false;
        }

        public static bool RenamePicture(string path,string oldName, string newName) 
        {
            if (AuthenticityOfName(path, newName))
            {
                return false;
            }

            oldName = FaindPictures(path, oldName);

            newName += "." + oldName.Split('.')[1] + "." + oldName.Split('.')[2];

            oldName = path + oldName;
            newName = path + newName;

            File.Move(oldName, newName);         

            return true;
        }

        private static string FaindPictures(string _path, string fileName) 
        {
            DirectoryInfo info = new DirectoryInfo(_path);
            FileInfo[] fileInfo = info.GetFiles();

            foreach (FileInfo file in fileInfo)
            {
                string str = file.Name.Split('.')[0];

                if (str == fileName)
                {
                    return fileName + "." + file.Name.Split('.')[1] + "." + file.Name.Split('.')[2];
                }

            }

            return string.Empty;
        }
    }
}
