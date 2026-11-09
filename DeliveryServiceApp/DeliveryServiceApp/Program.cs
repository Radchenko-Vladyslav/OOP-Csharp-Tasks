namespace DeliveryServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService service = new DeliveryService();

            Bike bike = new Bike();
            Car car = new Car();
            Truck truck = new Truck();

            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);

            Order order1 = new Order(1, "Доставка документів", 2.5, 5.0);
            Order order2 = new Order(2, "Коробка з одягом", 12.0, 25.0);
            Order order3 = new Order(3, "Будівельні матеріали", 350.0, 50.0);

            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            service.ShowDeliveryCosts(order1);
            service.ShowDeliveryCosts(order2);

            Console.WriteLine("\n--- Процес призначення та доставки ---");

            service.AssignOrder(order1, bike);
            service.AssignOrder(order2, car);

            // Наведено спробу призначити зайнятий велосипед
            service.AssignOrder(order3, bike);

            service.ShowStatus();

            service.CompleteDelivery(order1, "Картка");
            service.CompleteDelivery(order2, "Готівка");

            service.ShowStatus();
        }
    }
}