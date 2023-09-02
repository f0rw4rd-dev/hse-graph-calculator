using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MyHashSet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MyHashSet<TValue> : HashSetTemplate<TValue, TValue>
    {
        public MyHashSet() : this(0) { }

        public MyHashSet(int capacity) : base(capacity) { }

        public MyHashSet(IEnumerable<TValue> collection) : base(collection) { }

        protected override TValue GetId(TValue item) => item;

        public override object Clone()
        {
            MyHashSet<TValue> clone = new MyHashSet<TValue>(this);
            if (typeof(ICloneable).IsAssignableFrom(typeof(TValue)))
                for (int i = 0, numGiven = 0; numGiven < clone.Count; i++)
                    if (clone.Slots[i].Next > 0)
                    {
                        clone.Slots[i].Value = (TValue)(clone.Slots[i].Value as ICloneable).Clone();
                        numGiven++;
                    }
            return clone;
        }
    }
}
