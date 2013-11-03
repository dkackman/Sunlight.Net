using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SunlightAPI
{
    /// <summary>
    /// Base class for result type to make unit test comparisons easier
    /// </summary>
    public abstract class EquatableObject<T> : IEquatable<T> where T : class
    {
        public static bool operator==(EquatableObject<T> l, EquatableObject<T> r)
        {
            if (object.ReferenceEquals(l, r))
                return true;

            if (object.ReferenceEquals(l, null) || object.ReferenceEquals(r, null))
                return false;

            return l.Equals(r);
        }

        public static bool operator !=(EquatableObject<T> l, EquatableObject<T> r)
        {
            return !(l == r);
        }

        public override int GetHashCode()
        {
            var values = from p in this.GetType().GetRuntimeProperties()
                         where p.CanRead
                         select p.GetValue(this, null) into value
                             where value != null
                             select value;
            unchecked
            {
                return values.Aggregate(0, (hash, next) => hash ^= ShiftAndWrap(next.GetHashCode(), 2));
            }
        }

        private static int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer. 
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded. 
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits. 
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        public override bool Equals(object o)
        {
            return Equals(o as T);
        }

        public bool Equals(T other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            if (object.ReferenceEquals(other, this))
                return true;

            // all readable properties in both instances must be equal for the instances to be equal
            foreach (var prop in typeof(T).GetRuntimeProperties().Where(p => p.CanRead))
            {
                // this and o are the same type so share same properties
                var value = prop.GetValue(this);
                var otherValue = prop.GetValue(other);

                // if both same ref or both null values are equal
                if (object.ReferenceEquals(value, otherValue))
                    return true;

                // one is null and the other isn't - not equal
                if (object.ReferenceEquals(value, null) || object.ReferenceEquals(otherValue, null))
                    return false;

                // now we can safely call equals
                if (!value.Equals(otherValue))
                    return false;
            }

            return true;
        }
    }
}
