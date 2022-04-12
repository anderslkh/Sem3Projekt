using WebAPI.Models;

namespace WebAPI.Managers
{
    public interface IPersonManager
    {
        Person GetPersonByEmail(string email);
    }
}
