using System;
using System.Collections.Generic;
using System.Linq;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph : ICloneable
    {
        #region Class fields and properties

        public const ushort MaxVertexNum = 1_000;
        public const uint MaxEdgeLen = 1_000_000_000;

        protected IndexedHashSet<ushort, Vertex> Vertices { get; set; }

        public IEnumerable<ushort> VerticesId => Vertices.Ids;

        public int VertexCount => Vertices.Count;

        public uint DirEdgeCount => (uint)Vertices.Sum(v => (uint)v.Outdegree);

        public bool HasDirEdges => Vertices.Any(v => v.Outdegree != 0);

        public uint UndirEdgeCount => (uint)Vertices.Sum(v => (uint)v.UndirDegree) / 2;

        public bool HasUndirEdges => Vertices.Any(v => v.UndirDegree != 0);

        protected IEnumerable<Vertex> LoopVertices => Vertices.Where(v => v.HasLoop);

        public ushort LoopCount => (ushort)LoopVertices.Count();

        public bool HasLoops => LoopVertices.Any();

        public uint EdgeCount => DirEdgeCount + UndirEdgeCount + LoopCount;

        #endregion
    }
}
