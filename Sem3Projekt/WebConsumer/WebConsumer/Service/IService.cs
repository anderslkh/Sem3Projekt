namespace WebConsumer.Service {
	public interface IService<T, I> {
		Task<T> GetItem(I item);
		Task<List<T>>  GetAllItems();

    }
}
