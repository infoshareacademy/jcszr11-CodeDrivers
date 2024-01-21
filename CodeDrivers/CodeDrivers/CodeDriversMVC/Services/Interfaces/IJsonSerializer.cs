using CodeDrivers.Models;

namespace CodeDriversMVC.Services.Interfaces
{
    public interface IJsonSerializer<T>
    {
        void SaveInJson(T entity, string path);
    }
}
