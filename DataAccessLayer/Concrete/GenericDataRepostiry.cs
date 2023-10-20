using DataAccessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericDataRepostiry<T> : IGenericDataRepostory<T> where T : class
    {
        public async Task Create(T entity)
        {
            using (var db = new DataContext()) 
            {
               await db.Set<T>().AddAsync(entity);
            }
        }

        public async Task Delete(T entity)
        {
            using (var db = new DataContext()) 
            {
                var data = await db.Set<T>().FindAsync(entity);
                if (data != null) 
                {
                    db.Set<T>().Remove(data); 
                }
            }
        }
        //kt
        public async Task<List<T>> GetAllData()
        {
         //   if (typeof(T) == typeof(ProductModel)) { }
            using (var db = new DataContext() ) 
            {
             return await db.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var db = new DataContext()) 
            {
              var data = await db.Set<T>().FindAsync(id);
                return data;
              

            }
        }

        public async Task Update(T entity)
        {
            using (var db = new DataContext()) 
            {
                db.Set<T>().Update(entity);
            }
        }
    }
}
