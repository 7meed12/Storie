

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

        protected void AddIncludes(Expression<Func<T, object>> IncludesExpression)
        {
            Includes.Add(IncludesExpression);
        }
    }
}
