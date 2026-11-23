namespace DeliveryServiceApp
{
    public interface IPayment
    {
        string Name { get; }
        void Pay(decimal amount);
    }

    public class CardPayment : IPayment
    {
        public string Name => "Карта";

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата ({Name}): {amount} грн");
        }
    }

    public class CashPayment : IPayment
    {
        public string Name => "Гроші";

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата ({Name}): {amount} грн");
        }
    }
}
