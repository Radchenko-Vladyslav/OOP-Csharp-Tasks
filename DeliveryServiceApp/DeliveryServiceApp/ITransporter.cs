namespace DeliveryServiceApp
{
    public interface ITransporter
    {
        bool IsBusy { get; set; }
        string Name { get; }
        bool CanTake(Order order);
        decimal CalculateCost(Order order);
    }
}
