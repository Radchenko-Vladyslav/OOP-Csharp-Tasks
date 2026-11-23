namespace DeliveryServiceApp
{
    public class Bike : Transport
    {
        private const double WeightLimit = 10.0;
        public Bike() : base("Велосипед", WeightLimit) { }

        public override decimal CalculateCost(Order order)
        {
            return 20m + 5m * (decimal)order.Distance;
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.Distance <= 10.0;
        }
    }
}
