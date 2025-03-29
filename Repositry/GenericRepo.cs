using Microsoft.EntityFrameworkCore;
using FreelanceManager.Interfaces;
using FreelanceManager.Models;

namespace FreelanceManager.Repositry
{
    public class GenericRepo<T>: IGenericRepo<T> where T : class
    {
        ITIContext context;
        DbSet<T> _dbSet;
        public GenericRepo(ITIContext _context)
        {
             context = _context;
            _dbSet = _context.Set<T>();

        }
        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Remove(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
