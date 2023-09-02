using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MyHashSet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class HashSetTemplate<TId, TValue>: ICollection<TValue>, ICloneable
    {        
        protected const int HashMask = 0x7FFFFFFF;

        protected Slot[] Slots;
        protected int SegmentSize;
        protected IEqualityComparer<TId> Comparer = EqualityComparer<TId>.Default;

        public int Count { get; protected set; }

        bool ICollection<TValue>.IsReadOnly => false;

        public HashSetTemplate() => Initialize(0);

        public HashSetTemplate(int capacity)
        {
            if (capacity < 0) throw new ArgumentException("Ёмкость коллекции не может быть меньше нуля.");
            Initialize(capacity);
        }

        public HashSetTemplate(IEnumerable<TValue> collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));
            else if (collection is HashSetTemplate<TId, TValue> hs)
            {
                this.Slots = (Slot[])hs.Slots.Clone();
                this.SegmentSize = hs.SegmentSize;
                this.Count = hs.Count;
            }
            else
            {
                int newCapacity = collection is ICollection<TValue> values ? values.Count : 0;
                Initialize(newCapacity);
                foreach (TValue item in collection) Add(item);
                if (Count < SegmentSize) Resize(false);
            }
        }

        protected void Initialize(int capacity)
        {
            capacity = MyHashHelpers.GetNextCapacity(capacity);
            Slots = new Slot[capacity];
            SegmentSize = capacity / 3;
            Count = 0;
        }

        protected void Resize(bool expand)
        {
            int newCapacity = expand ?
                              MyHashHelpers.GetNextCapacity(Slots.Length) :
                              MyHashHelpers.GetNextCapacity(SegmentSize);
            int newSegmentSize = newCapacity / 3;
            Slot[] newSlots = new Slot[newCapacity];
            int maxCollCount = 0;
            foreach (TValue item in this)
            {
                int collCount = 0;
                int newIndex = GetInnerHashCode(item) % newCapacity;
                while (newSlots[newIndex].Next > 0)
                {
                    newIndex = newSlots[newIndex].Next - 1;
                    collCount++;
                }
                newSlots[newIndex].Value = item;
                newSlots[newIndex].Next = (newIndex + newSegmentSize) % newCapacity + 1;
                if (collCount > maxCollCount) maxCollCount = collCount;
            }
            bool errorResize = maxCollCount >= MyHashHelpers.HashCollisionThreshold;
            if (!expand && errorResize) return;
            SegmentSize = newSegmentSize;
            Slots = newSlots;
            if (errorResize) Resize(true);
        }

        protected abstract TId GetId(TValue item);

        protected int GetInnerHashCode(TValue item) => GetInnerHashCode(GetId(item));

        protected int GetInnerHashCode(TId id) =>
            id == null ? 0 : Comparer.GetHashCode(id) & HashMask;

        public bool Add(TValue item)
        {
            if (FindItemSlot(item, out int index)) return false;
            AddOnIndex(item, index);
            return true;
        }

        protected void AddOnIndex(TValue item, int index)
        {
            Slots[index].Value = item;
            Slots[index].Next = Slots[index].Next < 0 ?
                                -Slots[index].Next :
                                (index + SegmentSize) % Slots.Length + 1;
            if (++Count == Slots.Length) Resize(true);
        }

        public bool Contains(TValue item) => FindItemSlot(item, out _);

        public bool Remove(TValue item)
        {
            if (!FindItemSlot(item, out int index)) return false;
            RemoveOnIndex(index);
            return true;
        }

        protected void RemoveOnIndex(int index)
        {
            Slots[index].Value = default;
            Slots[index].Next = Slots[Slots[index].Next - 1].Next == 0 ?
                                0 :
                                -Slots[index].Next;
            if (--Count < SegmentSize) Resize(false);
        }

        public void Clear() => Initialize(0);

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            else if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Индекс массива не может быть меньше нуля.");
            else if (arrayIndex > array.Length || Count > array.Length - arrayIndex)
                throw new ArgumentException("Невозможно поместить все элементы в массив с указанного индекса.");
            else
                foreach (TValue item in this) array[arrayIndex++] = item;
        }

        protected bool FindItemSlot(TValue item, out int itemIndex) =>
            FindIdSlot(GetId(item), out itemIndex);

        protected bool FindIdSlot(TId id, out int itemIndex)
        {
            int hashCode = GetInnerHashCode(id),
                initIndex = hashCode % Slots.Length,
                curIndex = initIndex,
                nextIndex = -1,
                collCount = 0;
            itemIndex = -1;
            for (; Slots[curIndex].Next != 0 &&
                   collCount < MyHashHelpers.HashCollisionThreshold &&
                   nextIndex != initIndex;
                   collCount++, curIndex = nextIndex)
            {
                if (Slots[curIndex].Next < 0)
                {
                    nextIndex = -Slots[curIndex].Next - 1;
                    if (Slots[nextIndex].Next > 0 &&
                        nextIndex != GetInnerHashCode(Slots[nextIndex].Value) % Slots.Length)
                    {
                        Slots[curIndex].Value = Slots[nextIndex].Value;
                        Slots[curIndex].Next = -Slots[curIndex].Next;
                        Slots[nextIndex].Value = default;
                        Slots[nextIndex].Next = -Slots[nextIndex].Next;
                    }
                    else if (Slots[nextIndex].Next == 0)
                    {
                        Slots[curIndex].Next = 0;
                        break;
                    }
                    else if (itemIndex < 0) itemIndex = curIndex;
                }
                if (Slots[curIndex].Next > 0)
                {
                    TId curId = GetId(Slots[curIndex].Value);
                    if (hashCode == GetInnerHashCode(curId) && Comparer.Equals(id, curId))
                    {
                        itemIndex = curIndex;
                        return true;
                    }
                    nextIndex = Slots[curIndex].Next - 1;
                }
            }
            if (collCount == MyHashHelpers.HashCollisionThreshold)
            {
                Resize(true);
                return FindIdSlot(id, out itemIndex);
            }
            if (Slots[curIndex].Next == 0 && itemIndex < 0) itemIndex = curIndex;
            return false;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            for (int i = 0, numGiven = 0; numGiven < Count; i++)
                if (Slots[i].Next > 0)
                {
                    yield return Slots[i].Value;
                    numGiven++;
                }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void ICollection<TValue>.Add(TValue item) { Add(item); }

        public abstract object Clone();

        public virtual object ShallowClone() => this.MemberwiseClone();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected struct Slot
        {
            public int Next;
            public TValue Value;
        }
    }
}
