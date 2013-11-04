using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPITests
{
    class ReflectionEqualityComparer<T> : EqualityComparer<T>
    {
        public override bool Equals(T x, T y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            // all readable properties in both instances must be equal for the instances to be equal
            foreach (var prop in typeof(T).GetProperties().Where(p => p.CanRead))
            {
                // this and o are the same type so share same properties
                var value = prop.GetValue(x);
                var otherValue = prop.GetValue(y);

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

        public override int GetHashCode(T obj)
        {
            if (object.ReferenceEquals(obj, null))
                return 0;

            var values = from p in typeof(T).GetProperties()
                         where p.CanRead
                         select p.GetValue(obj, null) into value
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
    }
}
