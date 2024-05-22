namespace ElleChristine.Web.Models
{
    public class Show
    {
        public Show()
        {
            Location = string.Empty;
            Time = string.Empty;
            Description = string.Empty;
            Image = string.Empty;
        }

        public string Location { get; set; }

        public DateOnly Date { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
