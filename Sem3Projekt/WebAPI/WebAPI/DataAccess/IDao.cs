namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I id);
        List<T> GetAllItems();
        bool CreateItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(I id);
    }
}
