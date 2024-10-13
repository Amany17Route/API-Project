﻿using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {

            _context = context;
        }

        public async Task<int> CompletedAsync()
        => await _context.SaveChangesAsync();


        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {

            if (_repositories is null)
            {

                _repositories = new Hashtable();
            }
            var entitykey = typeof(TEntity).Name; //"Product"

            if (!_repositories.ContainsKey(entitykey))
            {

                var repositoryType = typeof(GenericRepository<,>); //GenericRepository<Product, int>(context)
                var RepositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);

                _repositories.Add(entitykey, RepositoryInstance);

            }

            return (IGenericRepository<TEntity, TKey>)_repositories[entitykey];
        }
    }
}
