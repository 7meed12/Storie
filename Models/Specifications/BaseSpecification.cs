

using System.Linq.Expressions;

namespace Models.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T,object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take {get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> IncludesExpression)
        {
            Includes.Add(IncludesExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> OrderByExpression)
        {
            OrderByDesc = OrderByExpression;
        }
        protected void ApplyPaging(int skip , int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
