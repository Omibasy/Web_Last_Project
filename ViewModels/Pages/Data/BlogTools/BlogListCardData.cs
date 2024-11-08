namespace Web_Last_Project.ViewModels.Pages.Data.BlogTools
{
    internal class BlogListCardData
    {
        private readonly BlogCardData[] blogCardData;

        public BlogListCardData(string pathDirectory, string picturePath)
        {
            DirectoryInfo info = new DirectoryInfo(pathDirectory);
            FileInfo[] fileInfo = info.GetFiles();

            blogCardData = new BlogCardData[fileInfo.Length];

            for (int i = 0; i < blogCardData.Length; i++)
            {
                string str = pathDirectory + fileInfo[i].Name;

                blogCardData[i] = new BlogCardData(str, picturePath);
            }
        }

        public IEnumerable<BlogCardData> GetFullCards()
        {
            return blogCardData;
        }

        public BlogCardData FaindCard(int id)
        {
            if (id > -1 && id < blogCardData.Length)
            {
                return blogCardData[id];
            }

            return null;
        }

    }
}
