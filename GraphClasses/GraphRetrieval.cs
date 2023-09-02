using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphClasses
{
    public partial class Graph
    {
        #region Data retrieval
        public bool VertexExists(ushort vertex) => Vertices.Contains(vertex);

        protected bool VertexPairExists(ushort from, ushort to) =>
            VertexExists(from) && VertexExists(to);

        public bool EdgeExists(ushort from, ushort to) =>
            VertexPairExists(from, to) && EdgeExistsUnsafe(Vertices[from], to);

        protected bool EdgeExistsUnsafe(Vertex from, ushort to) => from.EdgeToExists(to);

        /// <summary>
        /// Получение веса ребра
        /// </summary>
        /// <param name="from">Начало ребра (вершина, из которой исходит ребро)</param>
        /// <param name="to">Конец ребра (вершина, в которую идет ребро)</param>
        /// <returns></returns>
        public EdgeData GetEdgeState(ushort from, ushort to)
        {
            if (VertexPairExists(from, to))
                return GetEdgeStateUnsafe(Vertices[from], to);
            else return default;
        }

        protected EdgeData GetEdgeStateUnsafe(Vertex from, ushort to) => from[to];

        /// <summary>
        /// Получение списка вершин, в которые идут ребра из вершины ver
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<ushort> GetExistOutEdges(ushort vertex)
        {
            if (!VertexExists(vertex)) return null;
            else return Vertices[vertex].AdjVertices;
        }

        protected IEnumerable<Vertex> GetExistOutEdgesUnsafe(Vertex vertex) =>
            vertex.AdjVertices.Select(v => Vertices[v]);

        /// <summary>
        /// Получение списка вершин, в которые не идут ребра из вершины ver
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<ushort> GetAvailOutEdges(ushort vertex)
        {
            if (!VertexExists(vertex)) return null;
            else return GetAvailOutEdgesUnsafe(Vertices[vertex]).Select(v => v.Id);
        }

        protected IEnumerable<Vertex> GetAvailOutEdgesUnsafe(Vertex vertex) =>
            Vertices.Where(v => !EdgeExistsUnsafe(vertex, v.Id));

        /// <summary>
        /// Получение списка вершин, из которых идут ребра в вершину ver
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<ushort> GetExistInEdges(ushort vertex)
        {
            if (!VertexExists(vertex)) return null;
            else return GetExistInEdgesUnsafe(Vertices[vertex]).Select(v => v.Id);
        }

        protected IEnumerable<Vertex> GetExistInEdgesUnsafe(Vertex vertex) =>
            Vertices.Where(v => EdgeExistsUnsafe(v, vertex.Id));

        protected int GetDegreeGen(ushort vertex, byte type)
        {
            EnsureVertexExists(vertex);
            switch (type)
            {
                case 1: return Vertices[vertex].Outdegree;
                case 2: return Vertices[vertex].Indegree;
                default: return Vertices[vertex].UndirDegree;
            }
        }

        /// <summary>
        /// Получение степени вершины outdegree
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <returns>Степень вершины outdegree</returns>
        public int GetOutdegree(ushort vertex) => GetDegreeGen(vertex, 1);

        /// <summary>
        /// Получение степени вершины indegree
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <returns>Степень вершины indegree</returns>
        public int GetIndegree(ushort vertex) => GetDegreeGen(vertex, 2);

        public int GetUndirDegree(ushort vertex) => GetDegreeGen(vertex, 3);

        #endregion

        #region Graph presentation constructors

        /// <summary>
        /// Vertex and Edge sets
        /// </summary>
        /// <returns></returns>
        public string ToVerEdgSets()
        {
            StringBuilder strb = new StringBuilder("S:");
            List<Vertex> vertices = Vertices.ToList();
            vertices.Sort();
            foreach (Vertex v in vertices) strb.Append($" {v.Id}");
            strb.AppendLine();
            foreach (Vertex from in vertices)
                foreach (Vertex to in vertices)
                {
                    EdgeData edgeData = GetEdgeStateUnsafe(from, to.Id);
                    if (edgeData.Exists)
                        strb.AppendLine($"{edgeData.From} {edgeData.To} {edgeData.Length} {(edgeData.IsDir ? 'О' : 'Н')}");
                }
            return strb.ToString();
        }

        /// <summary>
        /// Adjacency matrix
        /// </summary>
        /// <returns></returns>
        public string ToAdjMtx()
        {
            StringBuilder strb = new StringBuilder("M");
            List<Vertex> vertices = Vertices.ToList();
            vertices.Sort();
            foreach (Vertex v in vertices) strb.Append($",{v.Id}");
            strb.AppendLine();
            foreach (Vertex v1 in vertices)
            {
                strb.Append($"{v1.Id}");
                foreach (Vertex v2 in vertices)
                {
                    EdgeData edgeData = GetEdgeStateUnsafe(v1, v2.Id);
                    if (edgeData.Exists)
                        strb.Append($",{edgeData.Length};{(edgeData.IsDir ? 'О' : 'Н')}");
                    else strb.Append(",0");
                }
                strb.AppendLine();
            }
            return strb.ToString();
        }
        #endregion
    }
}
