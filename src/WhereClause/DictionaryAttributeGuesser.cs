//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;

namespace WhereClause
{
    public class DictionaryAttributeGuesser
        : Dictionary<string,Attribute>,IAttributeGuesser
    {
        public Attribute Guess(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new Attribute(input, input);

            if (this.ContainsKey(input))
                return this[input];

            return new Attribute(input, input);
        }

        public void Prepare(string input,object value)
        {
            this[input] = new Attribute(input, value);
        }

        public void Prepare(string input, object value,Type asType)
        {
            this[input] = new Attribute(input, value,asType);
        }
    }
}

