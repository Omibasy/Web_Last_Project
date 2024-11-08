namespace Web_Last_Project.ViewModels.Pages.Data.ProjectTools
{


    internal class ProjectListCardsData
    {
        private readonly ProjectCardData[] projectCardDatas;

        private string _pathDescriptionDirectory;

        public ProjectListCardsData(string pathDirectory, string picturePath)
        {
            DirectoryInfo info = new DirectoryInfo(pathDirectory);
            FileInfo[] fileInfo = info.GetFiles();


            projectCardDatas = new ProjectCardData[fileInfo.Length];

            for (int i = 0; i < projectCardDatas.Length; i++)
            {
                string str = pathDirectory + fileInfo[i].Name;

                projectCardDatas[i] = new ProjectCardData(str, picturePath);
            }
        }

        public ProjectListCardsData(string pathDirectory, string picturePath, string pathDescriptionDirectory) : this(pathDirectory, picturePath)
        {
            _pathDescriptionDirectory = pathDescriptionDirectory;
        }

        public IEnumerable<ProjectCardData> GetFullCards()
        {
            return projectCardDatas;
        }

        public ProjectCardData FaindCard(string cardTitle)
        {
            for (int i = 0; i < projectCardDatas.Length; i++)
            {
                if (projectCardDatas[i].Data.Title == cardTitle)
                {
                    string str = cardTitle.Length > 11 ?  cardTitle.Substring(0, 11) : cardTitle;

                    str = _pathDescriptionDirectory + str;

                    projectCardDatas[i].LoadDescription(str);

                    return projectCardDatas[i];
                }
            }

            return null;
        }

        public ProjectCardData FaindCard(int id)
        {
            for (int i = 0; i < projectCardDatas.Length; i++)
            {
                if (i == id)
                {
                    ProjectCardData projectCardData = projectCardDatas[i];

                    string str = _pathDescriptionDirectory + projectCardData.Data.Title.Substring(0, 11);

                    projectCardDatas[i].LoadDescription(str);

                    return projectCardData;
                }
            }

            return null;
        }
    }
}
