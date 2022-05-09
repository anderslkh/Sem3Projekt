namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I itemId);

        List<T> GetAllItems();
    }
}
