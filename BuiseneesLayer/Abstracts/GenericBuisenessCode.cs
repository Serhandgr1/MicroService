using BuiseneesLayer.Contracts;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiseneesLayer.Abstracts
{
    public class GenericBuisenessCode<T> : IGenericBuisennesCode<T> where T : class
    {
        private IGenericDataRepostory<T> _genericRepository;
        public GenericBuisenessCode()
        {
            _genericRepository = new GenericDataRepostiry<T>();
        }
        public async Task Create(T entity)
        {
            await _genericRepository.Create(entity);
        }

        public async Task Delete(T entity)
        {
            await _genericRepository.Delete(entity);
        }

        public async Task<List<T>> GetAllData()
        {
            return await _genericRepository.GetAllData();
        }

        public async Task<T> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task Update(T entity)
        {
            await _genericRepository.Update(entity);
        }
    }
}
