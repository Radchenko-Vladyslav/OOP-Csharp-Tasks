namespace DeliveryServiceApp
{
    public class Truck : Transport
    {
        public Truck() : base("Вантажівка") { }

        public override decimal CalculateCost(Order order)
        {
            return 200m + 15m * (decimal)order.Distance + 0.5m * (decimal)order.Weight;
        }
    }
}
