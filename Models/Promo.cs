namespace HaylandMontalvo_tablaBD.Models
{
    public class Promo
    {
        public int PromoId { get; set; }
        public string PromoName { get; set; }
        public string PromoDescription { get; set; }

        public int Id { get; set; } 
        public Burger? Burger { get; set; }

    }
}
