namespace UberAPIMENAGE.Genarics
{
    public interface IGenaricRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task  Add(T item);
        void  Remove(T item);
        void  Update(T item);
        Task<T> GetById(int id);
    }
}
