using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighC {
    public class Kleisli {
        private Kleisli() { }
    }
    public class KleisliSemigroupoid<K> : ISemigroupoid<_<Kleisli, K>> {
        private IBind<K> k;
        public KleisliSemigroupoid(IBind<K> binder) {
          this.k = binder;
        }
        public _<_<_<Kleisli, K>, A>, C> compose<A, B, C>(_<_<_<Kleisli, K>, B>, C> f, _<_<_<Kleisli, K>, A>, B> g) {
            var f0 = f.Value as Func<B, _<K, C>>;
            var g0 = g.Value as Func<A, _<K, B>>;
            return new _<Kleisli, K, A, C>(new Func<A, _<K, C>>(a => k.bind(f0, g0(a))));
        }
    }

    public class KleisliCategory<K> : KleisliSemigroupoid<K>, ICategory<_<Kleisli, K>> {
        private IMonad<K> k;
        public KleisliCategory(IMonad<K> monad) : base(monad) {
            this.k = monad;
        }
        public _<_<_<Kleisli, K>, A>, A> id<A>() {
            return new _<_<_<Kleisli, K>, A>, A>(new Func<A, _<K, A>>(a => k.pure(a)));
        }
    }

    public static class KleisliExtensions {
        public static KleisliSemigroupoid<K> kleisli<K>(this IBind<K> bind) {
            return new KleisliSemigroupoid<K>(bind);
        }
        public static KleisliCategory<K> kleisli<K>(this IMonad<K> monad) {
            return new KleisliCategory<K>(monad);
        }
    }
}
