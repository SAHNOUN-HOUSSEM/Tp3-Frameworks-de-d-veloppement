using System.ComponentModel.DataAnnotations.Schema;

namespace tp3.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        
        public int membershiptype_id { get; set; }

        [ForeignKey("membershiptype_id")]
        public Membershiptypes? Membershiptypes { get; set; }
        public virtual ICollection<Movies>? Movies { get; set; }


    }
}
