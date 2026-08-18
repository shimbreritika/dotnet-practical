using Assignment_13AUG.Model;

namespace Assignment_13AUG.Repository
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}
