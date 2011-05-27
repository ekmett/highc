using System;

namespace HighC {
    public interface IApplicative<F> : IAp<F> {
        _<F, A> pure<A>(A a);
    }
    public static class ApplicativeExtensions {
        public static Func<A, _<F, A>> pure<F, A>(this IApplicative<F> F_) { return a => F_.pure(a); }
    }

    public abstract class Applicative<F> : Ap<F>, IApplicative<F> {
        public override _<F, B> map<A, B>(Func<A, B> f, _<F, A> xs) { return ap(pure(f), xs); }
        public abstract _<F, A> pure<A>(A a);
    }
}
