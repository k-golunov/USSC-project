using USSC.Entities;

namespace USSC.Services;

// create BaseEntity

public interface IEfRepository<T> where T: BaseEntity
{
    List<T> GetAll();
    T GetById(long id);
    Task<long> Add(T entity);
}