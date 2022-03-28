﻿

using System.Linq.Expressions;

namespace Models.Specifications
{
    public interface ISpecifications<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
    }
}
