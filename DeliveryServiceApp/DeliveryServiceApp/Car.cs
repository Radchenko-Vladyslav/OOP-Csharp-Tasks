namespace DeliveryServiceApp
{
    public class Car : Transport
    {
        public Car() : base("Автомобіль") { }

        public override decimal CalculateCost(Order order)
        {
            return 50m + 8m * (decimal)order.Distance + 1m * (decimal)order.Weight;
        }
    }
}
