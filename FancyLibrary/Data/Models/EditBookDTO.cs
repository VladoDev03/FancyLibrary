namespace Data.Models
{
    public class EditBookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int? Year { get; set; }

        public int? Pages { get; set; }

        //public int InspiredBy { get; set; }
    }
}
