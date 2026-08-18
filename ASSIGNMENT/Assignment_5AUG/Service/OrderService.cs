using Assignment_5AUG.Data;
using Assignment_5AUG.Model;
using Assignment_5AUG.Repository;

namespace Assignment_5AUG.Service
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = context.Orders.Find(id);

            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order? GetOrder(int id)
        {
            return context.Orders.Find(id);
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
    }
}
