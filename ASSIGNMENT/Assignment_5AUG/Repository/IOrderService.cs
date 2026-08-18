using Assignment_5AUG.Model;

namespace Assignment_5AUG.Repository
{
    public interface IOrderService
    {
        List<Order> GetAll();

        Order GetOrder(int id);

        void AddOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(int id);
    }
}
