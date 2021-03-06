using System;

namespace WhereClause
{
    public class Attribute
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public Type ElementType
        {
            get
            {
                if (this.Type.HasElementType)
                        return this.Type.GetElementType();
                return this.Type;
            }
        }

        public object Value { get; set; }

        public Attribute() { }
        public Attribute(string name, object value)
            : this(name, value, value is null ? typeof(AnyType) : value.GetType()) { }
        public Attribute(string name, object value, Type type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }
    }
}


