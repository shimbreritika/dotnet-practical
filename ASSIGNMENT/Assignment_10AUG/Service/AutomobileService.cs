using Assignment_10AUG.Data;
using Assignment_10AUG.Model;
using Assignment_10AUG.Repository;

namespace Assignment_10AUG.Service
{
    public class AutomobileService : IAutomobileService
    {
        private readonly AppDbContext context;

        public AutomobileService(AppDbContext context)
        {
            this.context = context;
        }

        public Automobile CreateAutomobile(Automobile automobile)
        {
            var customer = context.Customerss
                .FirstOrDefault(c => c.Id == automobile.CustomerId);

            if (customer == null)
            {
                throw new ArgumentException("Invalid Customer");
            }

            var service = context.AutomobileServices
                .FirstOrDefault(s => s.Id == automobile.ServiceId);

            if (service == null)
            {
                throw new ArgumentException("Invalid Service");
            }

            context.Automobiles.Add(automobile);
            context.SaveChanges();

            return automobile;
        }

        public List<Automobile> GetAutomobiles()
        {
            return context.Automobiles.ToList();
        }

        public Automobile? GetAutomobileById(int id)
        {
            return context.Automobiles.Find(id);
        }

    }
    }
