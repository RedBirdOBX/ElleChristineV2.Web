namespace ElleChristine.Web.Models
{
    public class Photo
    {
        public Photo()
        {
            FileName = string.Empty;
            Heading = string.Empty;
            Description = string.Empty;
        }

        public int Id { get; set; }

        public string FileName { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Added { get; set; }

        public bool Active { get; set; }
    }
}
