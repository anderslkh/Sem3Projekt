using WebAPI.Models;

namespace WebAPI.Managers
{
    public interface IManager<T, I>
    {
        T GetById(I id);

        List<T> GetAll();
    }
}
