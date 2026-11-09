namespace DeliveryServiceApp
{
    public class Bike : Transport
    {
        public Bike() : base("Велосипед") { }

        public override decimal CalculateCost(Order order)
        {
            return 20m + 5m * (decimal)order.Distance;
        }

        public override bool CanTake(Order order)
        {
            return order.Distance <= 10.0;
        }
    }
}
