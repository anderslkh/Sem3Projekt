using WebAPI.Model_DTO_s;

namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I identifier);

        List<T> GetAllItems();

        bool DeleteItem(I id);
    }
}
