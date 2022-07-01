using System;
using System.Collections;
using System.Collections.Generic;

namespace WhereClause
{
	public class Compare
	{
        public static readonly Dictionary<Type, IComparer> Comparers;

        static Compare()
        {
            Comparers = new Dictionary<Type, IComparer>();
        }

		public static int CompareObjects(object a, object b)
        {
            if (a == null && b == null) return 0;
            if (a != null )
            {
                var aType = a.GetType();
                IComparer comparer = null;
                if (Comparers.ContainsKey(aType))
                    comparer = Comparers[aType];
                if(comparer is null && typeof(IComparer).IsAssignableFrom(aType))
                {
                    comparer = a as IComparer;
                }
                if(comparer is null && typeof(IComparable).IsAssignableFrom(aType))
                {
                    comparer = new CompareableComparer();
                }
                if(comparer != null)
                {
                    return comparer.Compare(a, b);
                }
            }
            if (b != null)
            {
                return Compare.CompareObjects(b, a);
            }
            throw new Exception($"Failed to compare {a} and {b}");
        }
	}

    public class CompareableComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var result= (x as IComparable).CompareTo(y);
            return result;
        }
    }

}

