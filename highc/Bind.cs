using System;

namespace HighC {
    public interface IBind<F> : IAp<F> {
        _<F, B> bind<A, B>(Func<A, _<F, B>> f, _<F, A> a);
    }
    public abstract class Bind<F> : Ap<F>, IBind<F> {
        public abstract _<F, B> bind<A, B>(Func<A, _<F, B>> f, _<F, A> a);
    }
    public static class BindExtensions {
        public static Func<_<F, A>, _<F, B>> bind<F, A, B>(this IBind<F> F_, Func<A, _<F, B>> f) { return a => F_.bind(f, a); }
        public static Func<Func<A, _<F, B>>, Func<_<F, A>, _<F, B>>> bind<F, A, B>(this IBind<F> F_) { return f => a => F_.bind(f, a); }
    }
}
