using System;

namespace WhereClause
{
    public class FuncConverter : IConverter
    {
		private Func<string, object> func;
		public FuncConverter(Func<string,object> func)
        {
			this.func = func;
			if (this.func == null)
				this.func = (s) => s;
        }

        public object Convert(string input)
        {
			return this.func(input);
        }
    }
}

