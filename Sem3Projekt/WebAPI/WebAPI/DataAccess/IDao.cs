namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I identifier);

        List<T> GetAllItems();

        int CreateItem(T item);

        bool DeleteItem(I id);
    }
}
