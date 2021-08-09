using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Data.ViewModels
{
    public class BookView
    {
        [XmlIgnore]
        [JsonIgnore]
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string AuthorName { get; set; }

        public int? Year { get; set; }

        public int SavedTimes { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}; Genre: {Genre}; Author: {AuthorName}; Year: {Year}; Saved times: {SavedTimes}.";
        }
    }
}
