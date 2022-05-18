namespace WebConsumer.Service {
	public interface IService<T, I> {
		Task<T> GetItemById(I item);
		Task<List<T>>  GetAllItems();

    }
}
