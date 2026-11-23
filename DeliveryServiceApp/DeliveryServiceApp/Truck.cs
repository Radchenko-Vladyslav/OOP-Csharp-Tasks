namespace DeliveryServiceApp
{
    public class Truck : Transport
    {
        private const double WeightLimit = 1000.0;
        public Truck() : base("Вантажівка", WeightLimit) { }

        public override decimal CalculateCost(Order order)
        {
            return 200m + 15m * (decimal)order.Distance + 0.5m * (decimal)order.Weight;
        }
    }
}
