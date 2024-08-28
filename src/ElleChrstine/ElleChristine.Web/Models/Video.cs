namespace ElleChristine.Web.Models
{
    public class Video
    {
        public Video()
        {
            Html = string.Empty;
            Description = string.Empty;
        }

        public int Id { get; set; }

        public string Html { get; set; }

        public string Description { get; set; }

        public DateTime Added { get; set; }

        public bool Active { get; set; }
    }
}
