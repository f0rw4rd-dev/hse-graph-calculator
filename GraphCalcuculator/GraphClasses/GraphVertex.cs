using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected class Vertex : IIndexable<ushort>, ICloneable, IEquatable<Vertex>, IComparable<Vertex>
        {
            public ushort Id { get; }

            public IndexedHashSet<ushort, Edge> DirEdges;
            public IndexedHashSet<ushort, Edge> UndirEdges;

            public bool EdgeToExists(ushort vertex) => DirEdges.Contains(vertex) || UndirEdges.Contains(vertex);

            public IEnumerable<ushort> AdjVertices => DirEdges.Ids.Concat(UndirEdges.Ids);

            public int Outdegree => DirEdges.Count;

            public int Indegree;

            public int UndirDegree => UndirEdges.Count - (HasLoop ? 1 : 0);

            public bool IsIsolated => Outdegree == 0 && Indegree == 0 && UndirDegree == 0;

            public bool HasLoop => UndirEdges.Contains(Id);

            public EdgeData this[ushort i]
            {
                get
                {
                    Edge edge;
                    if (DirEdges.Peek(i, out edge)) return new EdgeData(Id, edge.To, edge.Length, true);
                    else if (UndirEdges.Peek(i, out edge)) return new EdgeData(Id, edge.To, edge.Length, false);
                    else return default;
                }
            }

            public Vertex(ushort id)
            {
                Id = id;
                UndirEdges = new IndexedHashSet<ushort, Edge>();
                DirEdges = new IndexedHashSet<ushort, Edge>();
                Indegree = 0;
            }

            protected Vertex(ushort id, IndexedHashSet<ushort, Edge> outEdges, IndexedHashSet<ushort, Edge> undirEdges, int indegree)
            {
                Id = id;
                DirEdges = new IndexedHashSet<ushort, Edge>(outEdges);
                UndirEdges = new IndexedHashSet<ushort, Edge>(undirEdges);
                Indegree = indegree;
            }

            public bool AddEdgeTo(Vertex to, uint length, bool isDir)
            {
                Edge newEdge = new Edge(to.Id, length);
                if (to == this) return UndirEdges.Add(newEdge);
                else if (isDir && !this.UndirEdges.Contains(to.Id) && this.DirEdges.Add(newEdge))
                    to.Indegree++;
                else if (!isDir && !this.DirEdges.Contains(to.Id) && this.UndirEdges.Add(newEdge))
                {
                    if (to.DirEdges.Remove(this.Id)) this.Indegree--;
                    to.UndirEdges.Add(new Edge(this.Id, length));
                }
                else return false;
                return true;
            }

            public bool ChangeEdgeTo(Vertex to, uint length, bool isDir)
            {
                EdgeData oldEdge = this[to.Id];
                if (!oldEdge.Exists) return false;
                Edge newEdge = new Edge(to.Id, length);
                if (to == this) UndirEdges[to.Id] = newEdge;
                else if (isDir)
                {
                    if (!oldEdge.IsDir)
                    {
                        to.UndirEdges.Remove(this.Id);
                        to.DirEdges.Add(new Edge(this.Id, oldEdge.Length));
                        this.Indegree++;
                        this.UndirEdges.Remove(to.Id);
                        to.Indegree++;
                    }
                    this.DirEdges[to.Id] = newEdge;
                }
                else
                {
                    Edge newRevEdge = new Edge(this.Id, length);
                    if (!oldEdge.IsDir) to.UndirEdges[this.Id] = newRevEdge;
                    else
                    {
                        if (to.DirEdges.Remove(this.Id)) this.Indegree--;
                        to.UndirEdges.Add(newRevEdge);
                        this.DirEdges.Remove(to.Id);
                        to.Indegree--;
                    }
                    this.UndirEdges[to.Id] = newEdge;
                }
                return true;
            }

            public bool RemoveEdgeTo(Vertex to)
            {
                EdgeData oldEdge = this[to.Id];
                if (!oldEdge.Exists) return false;
                if (oldEdge.IsDir)
                {
                    this.DirEdges.Remove(to.Id);
                    to.Indegree--;
                }
                else
                {
                    this.UndirEdges.Remove(to.Id);
                    if (to != this) to.UndirEdges.Remove(this.Id);
                }
                return true;
            }

            public void DirectAllEdges(List<(Vertex, uint)> edges, bool toInEdges)
            {
                if (toInEdges) Indegree += UndirDegree;
                foreach (var (Ver, Len) in edges)
                {
                    if (Ver == this) continue;
                    Ver.UndirEdges.Remove(this.Id);
                    this.UndirEdges.Remove(Ver.Id);
                    if (toInEdges) Ver.DirEdges.Add(new Edge(this.Id, Len));
                    else
                    {
                        this.DirEdges.Add(new Edge(Ver.Id, Len));
                        Ver.Indegree++;
                    }
                }
            }

            public Vertex Clone() => new Vertex(this.Id, DirEdges, UndirEdges, Indegree);

            object ICloneable.Clone() => Clone();

            public bool Equals(Vertex other)
            {
                if (other is null) return false;
                else if (ReferenceEquals(this, other)) return true;
                else if (this.GetType() != other.GetType()) return false;
                else return this.Id == other.Id;
            }

            public int CompareTo(Vertex other)
            {
                if (other is null) return 1;
                else return this.Id.CompareTo(other.Id);
            }

            public override int GetHashCode() => Id;
        }
    }
}
