﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Data.Entity;
using Store.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{

    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {

        Task<TEntity> GetByIdAsync(Tkey? id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();


        Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> specs);


        Task<IReadOnlyList<TEntity>> GetAllwithSpecificationAsync(ISpecification<TEntity> specs);

        Task<int> GetCountWithSpecification(ISpecification<TEntity> specs);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
