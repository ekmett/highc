using System;

namespace HighC {
    public interface IMonad<F> : IApplicative<F>, IBind<F> { }
    public static class MonadExtensions  { }
    public abstract class Monad<F> : IBind<F>, IApplicative<F> {
        public _<F, B> map<A, B>(Func<A, B> f, _<F, A> xs) { return bind(x => pure(f(x)), xs); }
        public _<F, B> ap<A, B>(_<F, Func<A, B>> ff, _<F, A> fa) {
            return bind(f => map(f, fa), ff);
        }
        public abstract _<F, A> pure<A>(A a);
        public abstract _<F, B> bind<A, B>(Func<A, _<F, B>> f, _<F, A> a);
    }
}
