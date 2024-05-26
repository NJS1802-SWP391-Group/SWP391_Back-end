﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SWP391_Project.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void PrepareCreate(T entity);

        public void PrepareUpdate(T entity);

        public void PrepareRemove(T entity);

        public int Save();

        public Task<int> SaveAsync();
        public List<T> GetAll();
        public Task<List<T>> GetAllAsync();
        public void Create(T entity);

        public Task<int> CreateAsync(T entity);

        public void Update(T entity);

        public Task<int> UpdateAsync(T entity);

        public bool Remove(T entity);

        public Task<bool> RemoveAsync(T entity);

        public T GetById(int id);

        public Task<T> GetByIdAsync(int id);

        public T GetById(string code);

        public Task<T> GetByIdAsync(string code);

        public T GetById(Guid code);

        public Task<T> GetByIdAsync(Guid code);
    }
}
