using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Web_Last_Project.ViewModels.Pages.Data.Resources
{
    public class Card : LitleCard
    {

        public string Alt { get; set; }

        public string file { get; set; }


        public Card() { }

    }
}
