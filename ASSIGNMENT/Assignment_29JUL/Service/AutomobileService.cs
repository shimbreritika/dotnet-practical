using Assignment16.Model;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignment16.Service
{
    public class AutomobileService : IAutomobileService
    {
        private static List<Automobile> automobiles = new List<Automobile>()
        {
            new Automobile{Id=101 , Name="Car" , Brand="Maruti", Price =980000, Color="White" , Year= 2024},
            new Automobile{Id=102 , Name="Bike" , Brand="Honda", Price =90000, Color="Black" , Year= 2023},
            new Automobile{Id=103 , Name="Car" , Brand="Hyundai", Price =158000, Color="Blue" , Year= 2025},
        };

        public List<Automobile> getAutomobile()
        {
            return automobiles;
        }

        public Automobile getById(int id)
        {
            return automobiles.FirstOrDefault(a => a.Id == id);
        }

        public Automobile getByName(string name)
        {
            return automobiles.FirstOrDefault(a => a.Name== name);
        }


        public void addAutomobile(Automobile automobile)
        {
            automobiles.Add(automobile);
        }

        public Automobile UpdateAutomobile(int id, Automobile automobile)
        {
            var existing = automobiles.FirstOrDefault(x => x.Id == id);

            if (existing == null)
                return null;

            existing.Price = automobile.Price;
            existing.Color = automobile.Color;

            return existing;
        }

        public void DeleteAutomobile(int id)
        {
            var auto = automobiles.FirstOrDefault(a => a.Id == id);

            if (auto != null)
            {
                automobiles.Remove(auto);
            }





        }
    }
}
