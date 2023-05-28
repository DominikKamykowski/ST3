using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.CrossCutting.Mappings
{
    public interface IMapping<TSource, TDestination>
    {
        TDestination Map(TSource source);
        Expression<Func<TSource, TDestination>> GetMapping();
    }
}
