namespace DeliveryServiceApp
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Distance { get; set; }

        public Order(int id, string description, double weight, double distance)
        {
            Id = id;
            Description = description;
            Weight = weight;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"Замовлення #{Id} ({Description}): вага = {Weight} кг, відстань = {Distance} км";
        }
    }
}
