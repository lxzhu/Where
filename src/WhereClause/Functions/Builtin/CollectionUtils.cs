using System;
using System.Collections;

namespace WhereClause.Functions.Builtin
{
    public class CollectionUtils
    {
        public static bool Contains(object a, object b)
        {
            if (a is null) return false;
            if (typeof(IEnumerable).IsAssignableFrom(a.GetType()))
            {
                var enumerator = (a as IEnumerable).GetEnumerator();
                var isMatched = false;
                while (enumerator.MoveNext() && !isMatched)
                {
                     isMatched = Compare.CompareObjects(enumerator.Current, b) == 0;
                }
                return isMatched;
            }
            throw new Exception($"First operand of {nameof(Contains)} must be IEnumerable.");
        }

        public static bool In(object a,object b)
        {
            if (b is null) return false;
            if (typeof(IEnumerable).IsAssignableFrom(b.GetType()))
            {
                var enumerator = (b as IEnumerable).GetEnumerator();
                var isMatched = false;
                while (enumerator.MoveNext() && !isMatched)
                {
                    isMatched = Compare.CompareObjects(enumerator.Current, a) == 0;
                }
                return isMatched;
            }
            throw new Exception($"Second operand of {nameof(In)} must be IEnumerable.");
        }

        public static bool ContainsAny(object a, object b)
        {
            throw new NotImplementedException();
        }

        public static bool ContainsAll(object a, object b)
        {
            throw new NotImplementedException();
        }
    }
    
}

