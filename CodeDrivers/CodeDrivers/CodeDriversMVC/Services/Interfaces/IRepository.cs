using CodeDrivers.Models.Car;
using System.Linq.Expressions;

namespace CodeDriversMVC.Services.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(int id);
       
    }
}
