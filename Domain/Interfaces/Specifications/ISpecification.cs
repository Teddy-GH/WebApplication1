using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Specifications
{
 public   interface ISpecification<T>
    {
        //to replace where
        Expression<Func<T, bool>> Criteria { get; }
        //to replace includes
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }


    }
}
