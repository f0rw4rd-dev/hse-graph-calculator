using System.Collections.Generic;
using System.Linq;
using MyHashSet;

namespace GraphClasses
{

    public partial class Graph
    {
        /// <summary>
        /// Поиск Эйлерова пути/цепи при помощи алгоритма Иерхольцера
        /// </summary>
        public Path FindEulerianPath()
        {
            Vertex start = null,
                   finish = null,
                   cycleStart = null;
            bool fixedStart = false,
                 fixedFinish = false,
                 oneLoopCycle = false;
            Graph mainGraphCopy = (Graph)this.Clone(),
                  reserveGraphCopy = null;

            bool ClassifyVertex(Vertex v)
            {
                int fullDegree = v.Outdegree - v.Indegree;
                if (fullDegree > 0)
                {
                    fullDegree -= v.UndirDegree;
                    if (fullDegree >= 0)
                    {
                        if (fullDegree == 1 && (!fixedStart || start == v))
                        {
                            if (start != null && start != v)
                            {
                                if (finish is null) finish = start;
                                else return false;
                            }
                            start = v;
                            fixedStart = true;
                        }
                        else if (fullDegree != 0) return false;
                        List<(Vertex, uint)> undirEdges =
                            v.UndirEdges.Select(e => (mainGraphCopy.Vertices[e.To], e.Length)).ToList();
                        v.DirectAllEdges(undirEdges, true);
                        foreach (var (Ver, Len) in undirEdges)
                            if (Ver == v) continue;
                            else if (!ClassifyVertex(Ver)) return false;
                        return true;
                    }
                }
                else
                {
                    fullDegree += v.UndirDegree;
                    if (fullDegree <= 0)
                    {
                        if (fullDegree == -1 && (finish is null || finish == v))
                        {
                            finish = v;
                            fixedFinish = true;
                        }
                        else if (fullDegree != 0) return false;
                        List<(Vertex, uint)> undirEdges =
                            v.UndirEdges.Select(e => (mainGraphCopy.Vertices[e.To], e.Length)).ToList();
                        v.DirectAllEdges(undirEdges, false);
                        foreach (var (Ver, Len) in undirEdges)
                            if (Ver == v) continue;
                            else if (!ClassifyVertex(Ver)) return false;
                        return true;
                    }
                }
                if (fullDegree % 2 == 0) return true;
                else if (start is null || start == v) start = v;
                else if (finish is null || finish == v) finish = v;
                else return false;
                return true;
            }

            List<Vertex> copyVertexList = mainGraphCopy.Vertices.ToList();
            for (int i = 0; i < copyVertexList.Count; i++)
            {
                Vertex v = copyVertexList[i];
                if (v.IsIsolated)
                {
                    if (v.HasLoop)
                        if (!oneLoopCycle && cycleStart is null)
                        {
                            start = v;
                            finish = v;
                            oneLoopCycle = true;
                        }
                        else return null;
                    else mainGraphCopy.Vertices.Remove(v);
                    continue;
                }
                if (oneLoopCycle || !ClassifyVertex(v)) return null;
                cycleStart = v;
            }

            if (oneLoopCycle) return new Path(0) { start.Id, finish.Id };
            else if (cycleStart is null) return null;
            else if (start is null && finish is null)
            {
                start = cycleStart;
                finish = cycleStart;
            }

            if (!fixedFinish && !fixedStart && start != finish) reserveGraphCopy = (Graph)mainGraphCopy.Clone();
            bool isConnected;
            Path eulerPath; // Окончательный путь Эйлера

            Path FindEulerianPathUtil(Vertex iStart, Vertex iFinish, Graph graph, out bool connected)
            {
                connected = true;
                Path tempEulerPath = new Path(0);
                Stack<Vertex> partEulerPath = new Stack<Vertex>(); // Промежуточный (часть) путь Эйлера
                partEulerPath.Push(iStart);
                while (partEulerPath.Count > 0)
                {
                    Vertex lastVertex = partEulerPath.Peek(),
                           nextVertex;
                    while (true)
                    {                        
                        if (lastVertex.DirEdges.Count > 0)
                            nextVertex = graph.Vertices[lastVertex.DirEdges.First().To];
                        else if (lastVertex.UndirEdges.Count > 0)
                            nextVertex = graph.Vertices[lastVertex.UndirEdges.First().To];
                        else break;
                        lastVertex.RemoveEdgeTo(nextVertex);
                        partEulerPath.Push(nextVertex);
                        lastVertex = nextVertex;
                    }
                    if (lastVertex != iFinish) return null;
                    tempEulerPath.Add(lastVertex.Id);
                    graph.RemoveVertexUnsafe(partEulerPath.Pop());
                    if (partEulerPath.Count > 0) iFinish = partEulerPath.Peek();
                }
                connected = graph.VertexCount == 0;
                return connected ? tempEulerPath : null;
            }

            eulerPath = FindEulerianPathUtil(start, finish, mainGraphCopy, out isConnected);
            if (!isConnected) return null;

            if (eulerPath is null && reserveGraphCopy != null)
                eulerPath = FindEulerianPathUtil(reserveGraphCopy.Vertices[finish.Id],
                                                 reserveGraphCopy.Vertices[start.Id],
                                                 reserveGraphCopy, out isConnected);

            if (eulerPath != null) eulerPath.Reverse();
            return eulerPath;
        }
    }
}
