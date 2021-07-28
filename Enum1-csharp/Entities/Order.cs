using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Enum1_csharp.Entities.Enums;

namespace Enum1_csharp.Entities {
    class Order {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        Order() {

        }

        public Order(OrderStatus status, Client client) {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item) {
            OrderItems.Remove(item);
        }

        public double Total() {
            double sum = 0;
            foreach (OrderItem i in OrderItems) {
                sum += i.SubTotal();
            }
            return sum;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") " + Client.Email);
            sb.AppendLine("Order items:");
            foreach(OrderItem item in OrderItems) {
                sb.AppendLine(item.Product.Name + ", $" 
                    + item.Price.ToString("F2", CultureInfo.InvariantCulture) 
                    + ", Quantity: " + item.Quantity 
                    + ", Subtotal: $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
