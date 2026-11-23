namespace DeliveryServiceApp
{
    public class Car : Transport
    {
        private const double WeightLimit = 200.0;
        public Car() : base("Автомобіль", WeightLimit) { }

        public override decimal CalculateCost(Order order)
        {
            return 50m + 8m * (decimal)order.Distance + 1m * (decimal)order.Weight;
        }
    }
}
