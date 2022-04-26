namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I id);

        List<T> GetAllItems();
    }
}
