using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDataRepostory<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAllData();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
