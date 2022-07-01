using System;

namespace WhereClause.Functions
{
    public class FunctionKey
    {
        public string Name { get; set; }

        public Type OperandType { get; set; }

        public override string ToString()
        {
            return $"{Name}-{OperandType.FullName}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            var other = obj as FunctionKey;
            if (other is null) return false;
            return string.Equals(this.Name, other.Name)
                && this.OperandType.Equals(other.OperandType);
        }

    }
}

