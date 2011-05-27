using System;

namespace HighC {
    public class _<F,A> {
        private object value;
        public _(object value) { this.value = value; }
        public object Value { get { return value; } }
        public override string ToString() {
            return value.ToString();
        }
    }
 
    public class _<F, A, B> : _<_<F, A>, B> {
        public _(object value) : base(value) {}
    }

    public class _<F, A, B, C> : _<_<_<F, A>, B>, C> {
        public _(object value) : base(value) {}    
    }

    public class _<F, A, B, C, D> : _<_<_<_<F, A>, B>, C>, D> {
        public _(object value) : base(value) { }
    }

    
}
