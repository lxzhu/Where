//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;

namespace WhereClause.AttributeReaders
{
    public class DictionaryAttributeReader : 
        Dictionary<string, object>, IAttributeReader
    {
        public virtual Attribute Read(string attributeName)
        {
            if (this.ContainsKey(attributeName))
            {
                var value = this[attributeName];
                return new Attribute(attributeName, value);
            }
            return new Attribute(attributeName, null, null);
        }
    }
}

