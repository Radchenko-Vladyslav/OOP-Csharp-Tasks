namespace DeliveryServiceApp
{
    public abstract class Transport : ITransporter
    {
        public string Name { get; protected set; }
        public bool IsBusy { get; set; } = false;

        protected Transport(string name)
        {
            Name = name;
        }

        public abstract decimal CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return true;
        }
    }
}
