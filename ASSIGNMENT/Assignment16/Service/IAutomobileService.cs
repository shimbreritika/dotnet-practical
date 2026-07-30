using Assignment16.Model;

namespace Assignment16.Service
{
    public interface IAutomobileService
    {
        List<Automobile> getAutomobile();

        Automobile getById(int id);
        Automobile getByName(string name);
        void addAutomobile(Automobile automobile);
        Automobile? UpdateAutomobile(int id, Automobile automobile);
        void DeleteAutomobile(int id);


    }
}
