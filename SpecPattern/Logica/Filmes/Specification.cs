using System;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> rightSpec)
        {
            if (this == All)
                return rightSpec;

            if (rightSpec == All)
                return this;

            return new AndSpecification<T>(this, rightSpec);
        }

        public Specification<T> Or(Specification<T> rightSpec)
        {
            if (this == All || rightSpec == All)
                return All;

            return new OrSpecification<T>(this, rightSpec);
        }

        public Specification<T> Not() => new NotSpecification<T>(this);

    }
}
