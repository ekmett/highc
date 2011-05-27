using System;

namespace HighC {
    public interface IFunctor<F> {
        _<F, B> map<A, B>(Func<A, B> f, _<F, A> a);
    }
    public abstract class Functor<F> : IFunctor<F> {
        public abstract _<F, B> map<A, B>(Func<A, B> f, _<F, A> a);
    }
    public static class FunctorExtensions {
        public static Func<_<F, A>, _<F, B>> map<F, A, B>(this IFunctor<F> F_, Func<A, B> f) { return a => F_.map(f, a); }
        public static Func<Func<A, B>, Func<_<F, A>, _<F, B>>> map<F, A, B>(this IFunctor<F> F_) { return f => a => F_.map(f, a); }
    }

}
