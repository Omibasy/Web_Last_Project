namespace Web_Last_Project
{

    //elfkbnmbberbre   УДАЛИТЬ  
    public static class ChackAdmin
    {
        public static bool Chack { get; set; }

        public static string IsSelectedMenuItem(Menu menu)
        {
            if (Chack)
            {
                switch (menu)
                {
                    case Menu.Hero:
                        return "hero";

                    case Menu.Heading:
                        return "heading";

                    case Menu.Blog:
                        return "blog";

                    case Menu.Contacts:
                        return "contacts";

                    case Menu.Project:
                        return "project";

                    case Menu.Services:
                        return "services";

                    default:
                        return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
