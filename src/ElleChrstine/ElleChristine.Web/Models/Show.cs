﻿namespace ElleChristine.Web.Models
{
    public class Show
    {
        public Show()
        {
            Title = string.Empty;
            Location = string.Empty;
            Time = string.Empty;
            Description = string.Empty;
            Image = string.Empty;
            Url = string.Empty;
            MapUrl = string.Empty;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string MapUrl { get; set; }
    }
}
