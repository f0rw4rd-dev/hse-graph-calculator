using System.Runtime.InteropServices;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected readonly struct Edge : IIndexable<ushort>
        {
            public readonly ushort To;
            public readonly uint Length;

            public ushort Id => To;            

            public Edge(ushort to, uint length)
            {
                To = to;
                Length = length;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct EdgeData
    {
        public readonly ushort From;
        public readonly ushort To;
        public readonly uint Length;
        public readonly bool IsDir;

        public bool Exists => Length != 0;

        public EdgeData(ushort from, ushort to, uint length, bool isDir)
        {
            From = from;
            To = to;
            Length = length;
            IsDir = isDir;
        }
    }
}

