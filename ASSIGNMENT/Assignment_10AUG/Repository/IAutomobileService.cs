using Assignment_10AUG.Model;

namespace Assignment_10AUG.Repository
{
    public interface IAutomobileService
    {
        Automobile CreateAutomobile(Automobile automobile);

        List<Automobile> GetAutomobiles();

        Automobile? GetAutomobileById(int id);
    }
}
