namespace WebAPI.DataAccess
{
    public interface IDao<T, R>
    {
        T GetById(R id);

        //List<T> GetAll();
    }
}
