using System;

namespace GraphClasses
{
    public partial class Graph
    {
        /// <summary>
        /// Добавить вершину
        /// </summary>
        /// <param name="vertex">Номер вершины</param>
        public bool AddVertex(ushort vertex) =>
            vertex > 0 && VertexCount < MaxVertexNum && AddVertexUnsafe(new Vertex(vertex));

        protected bool AddVertexUnsafe(Vertex vertex) => Vertices.Add(vertex);

        /// <summary>
        /// Удалить вершину
        /// </summary>
        /// <param name="vertex">Номер вершины</param>
        public bool RemoveVertex(ushort vertex) =>
            VertexExists(vertex) && RemoveVertexUnsafe(Vertices[vertex]);

        protected bool RemoveVertexUnsafe(Vertex vertex)
        {
            if (!vertex.IsIsolated)
            {
                foreach (Vertex v in GetExistInEdgesUnsafe(vertex)) RemoveEdgeUnsafe(v, vertex);
                foreach (Vertex v in GetExistOutEdgesUnsafe(vertex)) RemoveEdgeUnsafe(vertex, v);
            }
            return Vertices.Remove(vertex);
        }

        protected bool EdgeIsValid(ushort from, ushort to, uint len) =>
            VertexPairExists(from, to) && (len > 0) && (len <= MaxEdgeLen);

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="from">Начало ребра (вершина, из которой исходит ребро)</param>
        /// <param name="to">Конец ребра (вершина, в которую идет ребро)</param>
        /// <param name="len">Вес ребра</param>
        /// <exception cref="Exception"></exception>
        public bool AddEdge(ushort from, ushort to, uint len, bool isDir) =>
            EdgeIsValid(from, to, len) && AddEdgeUnsafe(Vertices[from], Vertices[to], len, isDir);

        protected bool AddEdgeUnsafe(Vertex from, Vertex to, uint len, bool isDir) =>
            from.AddEdgeTo(to, len, isDir);

        /// <summary>
        /// Изменение веса ребра
        /// </summary>
        /// <param name="from">Начало ребра (вершина, из которой исходит ребро)</param>
        /// <param name="to">Конец ребра (вершина, в которую идет ребро)</param>
        /// <param name="len">Новый вес ребра</param>
        /// <exception cref="Exception"></exception>
        public bool ChangeEdge(ushort from, ushort to, uint len, bool isDir) =>
            EdgeIsValid(from, to, len) && ChangeEdgeUnsafe(Vertices[from], Vertices[to], len, isDir);

        protected bool ChangeEdgeUnsafe(Vertex from, Vertex to, uint len, bool isDir) =>
            from.ChangeEdgeTo(to, len, isDir);

        /// <summary>
        /// Удалить ребро
        /// </summary>
        /// <param name="from">Начало ребра (вершина, из которой исходит ребро)</param>
        /// <param name="to">Конец ребра (вершина, в которую идет ребро)</param>
        public bool RemoveEdge(ushort from, ushort to) =>
            VertexPairExists(from, to) && RemoveEdgeUnsafe(Vertices[from], Vertices[to]);

        protected bool RemoveEdgeUnsafe(Vertex from, Vertex to) => from.RemoveEdgeTo(to);
    }
}
