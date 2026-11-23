namespace DeliveryServiceApp
{
    public abstract class Transport : ITransporter
    {
        public string Name { get; protected set; }
        public bool IsBusy { get; set; } = false;

        public double MaxWeight { get; private set; }

        protected Transport(string name, double maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
        }

        public abstract decimal CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            if (order.Weight <= MaxWeight)
            {
                return true;
            }
            return false;
        }
    }
}
