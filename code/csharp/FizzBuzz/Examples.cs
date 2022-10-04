using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Examples
    {
        public static B Map<A, B>(A value, Func<A, B> mappingFn)
        {
            return mappingFn(value);
        }
    }
}
