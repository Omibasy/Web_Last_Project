using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Encodings.Web;
using System.Text.Json;
using Web_Last_Project.ViewModels.Pages.Data.Resources;

namespace Web_Last_Project.ViewModels.Tools
{
    internal static class EmployeeWithFileJson
    {
        public static async void Save<T>(T data, string path)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };


            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, data, options);
            };

        }

        public static T LoadData<T>(string path)
        {
            T data;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                data = JsonSerializer.DeserializeAsync<T>(fs).Result;
            };

            return data;

        }
    }
}
