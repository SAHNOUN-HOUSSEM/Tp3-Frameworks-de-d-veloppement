namespace tp3.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }

        public virtual ICollection<Movies>? Movies { get; set; }
    }
}
