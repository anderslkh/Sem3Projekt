namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetItemById(I personEmail);

        List<T> GetAllItems();
    }
}
