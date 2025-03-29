namespace FreelanceManager.Interfaces
{
    public interface IGenericRepo<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int Id);
        public void Add(T obj);
        public void Remove(T obj);
        public void Update(T obj);
        public void Save();
    }
}
