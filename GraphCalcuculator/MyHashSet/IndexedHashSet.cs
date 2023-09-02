using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MyHashSet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class IndexedHashSet<TId, TValue> : HashSetTemplate<TId, TValue> where TValue : IIndexable<TId>
    {
        public IEnumerable<TId> Ids => this.Select(i => i.Id);

        public IndexedHashSet() : this(0) { }

        public IndexedHashSet(int capacity) : base(capacity) { }

        public IndexedHashSet(IEnumerable<TValue> collection) : base(collection) { }

        protected override TId GetId(TValue item) =>
            item == null ? default : item.Id;

        public TValue this[TId id]
        {
            get
            {
                if (FindIdSlot(id, out int index)) return Slots[index].Value;
                else throw new KeyNotFoundException("Элемент с таким id отсутствует в коллекции.");
            }
            set
            {
                if (!Comparer.Equals(id, GetId(value))) throw new ArgumentException("Id назначаемого элемента не совпадает с целевым id.");
                else if (FindIdSlot(id, out int index)) Slots[index].Value = value;
                else AddOnIndex(value, index);
            }
        }

        public bool Contains(TId id) => FindIdSlot(id, out _);

        public bool Remove(TId id)
        {
            if (!FindIdSlot(id, out int index)) return false;
            RemoveOnIndex(index);
            return true;
        }

        public bool Peek(TId id, out TValue item)
        {
            if (FindIdSlot(id, out int index))
            {
                item = Slots[index].Value;
                return true;
            }
            else
            {
                item = default;
                return false;
            }    
        }

        public bool Pop(TId id, out TValue item)
        {
            if (FindIdSlot(id, out int index))
            {
                item = Slots[index].Value;
                RemoveOnIndex(index);
                return true;
            }
            else
            {
                item = default;
                return false;
            }
        }

        public override object Clone()
        {
            IndexedHashSet<TId, TValue> clone = new IndexedHashSet<TId, TValue>(this);
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
