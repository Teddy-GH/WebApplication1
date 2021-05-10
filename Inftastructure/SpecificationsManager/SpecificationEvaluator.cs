﻿using Domain.Entities;
using Domain.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.SpecificationsManager
{
   public class SpecificationEvaluator<TEntity> where  TEntity: BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {

            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);//i => i.categoryId =id
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

    }
}