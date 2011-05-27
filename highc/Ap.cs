using System;

namespace HighC {
    public interface IAp<F> : IFunctor<F> {       
        _<F, B> ap<A, B>(_<F, Func<A, B>> f, _<F, A> a);
    }
    public static class ApExtensions {
        public static Func<_<F, A>, _<F, B>> ap<F, A, B>(this IApplicative<F> F_, _<F, Func<A, B>> f) { return a => F_.ap(f, a); }
        public static Func<_<F, Func<A, B>>, Func<_<F, A>, _<F, B>>> ap<F, A, B>(this IApplicative<F> F_) { return f => a => F_.ap(f, a); }
    }
    public abstract class Ap<F> : Functor<F>, IAp<F> {
        public abstract _<F, B> ap<A, B>(_<F, Func<A, B>> f, _<F, A> a);
    }
}
