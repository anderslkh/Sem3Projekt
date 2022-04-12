namespace WebAPI.DataAccess
{
    public interface IDao<T, I>
    {
        T GetById(I id);

        List<T> GetAll();
    }
}
