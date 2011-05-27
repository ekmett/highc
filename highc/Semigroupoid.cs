using System;

namespace HighC {
    public interface ISemigroupoid<Hom> {
        _<_<Hom, A>, C> compose<A, B, C>(_<_<Hom, B>, C> f, _<_<Hom, A>, B> g);
    }
    public abstract class Semigroupoid<Hom> : ISemigroupoid<Hom> {
        public abstract _<_<Hom, A>, C> compose<A, B, C>(_<_<Hom, B>, C> f, _<_<Hom, A>, B> g);
    }
    public static class SemigroupoidExtensions {
        public static Func<_<_<Hom, A>, B>, _<_<Hom, A>, C>> compose<Hom, A, B, C>(this Semigroupoid<Hom> Hom_, _<_<Hom, B>, C> f) {
            return g => Hom_.compose(f, g);
        }
        public static Func<_<_<Hom, B>, C>, Func<_<_<Hom, A>, B>, _<_<Hom, A>, C>>> compose<Hom, A, B, C>(this Semigroupoid<Hom> Hom_) {
            return f => g => Hom_.compose(f, g);
        }
    }
}
