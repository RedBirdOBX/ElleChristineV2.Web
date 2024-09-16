namespace ElleChristine.Web.Models
{
    public class HomePageTitle
    {
        public HomePageTitle()
        {
            ImgPath = $"imgs/page-titles/home{GetTitleImg()}.jpg";
        }

        public string ImgPath { get; set; }

        private int GetTitleImg()
        {
            Random random = new Random();
            return random.Next(1, 3);
        }
    }
}
