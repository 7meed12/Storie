

using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Specifications;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery ,
            ISpecifications<TEntity> spec)
        {
            var query = InputQuery;
            if(spec.Criteria!=null) query = query.Where(spec.Criteria);
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
