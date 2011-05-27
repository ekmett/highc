using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighC {
    public interface ICategory<Hom> : ISemigroupoid<Hom> {
        _<_<Hom, A>, A> id<A>();
    }
    public static class CategoryExtensions { }
    public abstract class Category<Hom> : Semigroupoid<Hom>, ICategory<Hom> {
        public abstract _<_<Hom, A>, A> id<A>();
    }
}
