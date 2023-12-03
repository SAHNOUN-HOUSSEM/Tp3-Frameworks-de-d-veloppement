namespace tp3.Models
{
    public class Membershiptypes
    {
        public int Id { get; set; }
        public double SignUpFee { get; set; }

        public int DurationInMonth { get; set; }

        public double DiscountRate { get; set; }

        public virtual ICollection<Customers>? Customers { get; set; }
    }
}
