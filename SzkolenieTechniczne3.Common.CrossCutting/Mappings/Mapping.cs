using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.CrossCutting.Mappings
{
    public abstract class Mapping<TSource, TDestination> : IMapping<TSource, TDestination>
    {
        private Func<TSource, TDestination>? _cachedMapping;
        public TDestination Map(TSource source)
        {
            if (_cachedMapping == null)
            {
                _cachedMapping = GetMapping().Compile();
            }
            return _cachedMapping.Invoke(source);
        }
        public abstract Expression<Func<TSource, TDestination>> GetMapping();
    }
}
