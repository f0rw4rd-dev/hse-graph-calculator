using System;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        #region Ensurance methods
        protected void EnsureVertexExists(ushort vertex)
        {
            if (!VertexExists(vertex)) throw new ArgumentException($"Вершина {vertex} не существует.");
        }
        #endregion

        #region Cloning
        public object Clone() => new Graph { Vertices = (IndexedHashSet<ushort, Vertex>)this.Vertices.Clone() };
        #endregion
    }
}
