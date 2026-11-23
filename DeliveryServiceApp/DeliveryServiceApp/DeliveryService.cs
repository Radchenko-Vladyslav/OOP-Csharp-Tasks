using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceApp
{
    public class DeliveryService
    {
        private List<Transport> transports = new List<Transport>();
        private List<Order> activeOrders = new List<Order>();
        private List<string> history = new List<string>();
        private Dictionary<Order, Transport> orderTransportMap = new Dictionary<Order, Transport>();

        public void AddTransport(Transport transport)
        {
            transports.Add(transport);
        }

        public void AddOrder(Order order)
        {
            activeOrders.Add(order);
            Console.WriteLine($"(Система) Створено нове {order}");
        }

        public void ShowDeliveryCosts(Order order)
        {
            Console.WriteLine($"\n--- Розрахунок вартості для: {order} ---");
            foreach (var transport in transports)
            {
                if (transport.CanTake(order))
                {
                    decimal cost = transport.CalculateCost(order);
                    Console.WriteLine($"  * {transport.Name}: {cost} грн (Доступний)");
                }
                else
                {
                    Console.WriteLine($"  * {transport.Name}: Не може взяти замовлення через обмеження.");
                }
            }
        }

        public bool AssignOrder(Order order, Transport transport)
        {
            if (!activeOrders.Contains(order))
            {
                Console.WriteLine($"[Помилка] Замовлення #{order.Id} не знайдено серед активних.");
                return false;
            }

            if (transport.IsBusy)
            {
                Console.WriteLine($"[Помилка] {transport.Name} зайнятий.");
                return false;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine($"[Помилка] {transport.Name} не може виконати це замовлення через обмеження.");
                return false;
            }

            transport.IsBusy = true;
            activeOrders.Remove(order);
            orderTransportMap[order] = transport;
            Console.WriteLine($"(Успіх) Замовлення #{order.Id} призначено на {transport.Name}.");
            return true;
        }

        public void CompleteDelivery(Order order, IPayment payment)
        {
            if (!orderTransportMap.ContainsKey(order))
            {
                Console.WriteLine($"[Помилка] Замовлення #{order.Id} не перебуває в процесі доставки.");
                return;
            }

            if (payment == null)
            {
                Console.WriteLine("[Помилка] Не вказано спосіб оплати.");
                return;
            }

            Transport transport = orderTransportMap[order];
            decimal cost = transport.CalculateCost(order);

            payment.Pay(cost);

            transport.IsBusy = false;
            orderTransportMap.Remove(order);

            string record = $"Замовлення #{order.Id} ({order.Description}) доставлено транспортом [{transport.Name}]. Вартість: {cost} грн. Оплата: {payment.Name}.";
            history.Add(record);

            Console.WriteLine($"[Доставка виконана] {record}");
        }

        public void ShowStatus()
        {
            Console.WriteLine("\n================ СТАТУС СИСТЕМИ ================");
            Console.WriteLine("Активні замовлення:");
            if (activeOrders.Count == 0) 
                Console.WriteLine("  (немає)");
            else 
                foreach (var ord in activeOrders) Console.WriteLine($"  - {ord}");

            Console.WriteLine("\nСтатус транспорту:");
            foreach (var t in transports)
            {
                string status;

                if (t.IsBusy)
                {
                    status = "Зайнятий";
                }
                else
                {
                    status = "Вільний";
                }
                Console.WriteLine($"  - {t.Name}: {status}");
            }

            Console.WriteLine("\nІсторія доставок:");
            if (history.Count == 0) 
                Console.WriteLine("  (історія порожня)");
            else 
                foreach (var h in history) Console.WriteLine($"  - {h}");
            Console.WriteLine("=================================================\n");
        }
    }
}
