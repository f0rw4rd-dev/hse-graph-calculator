using System;
using System.Collections.Generic;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        protected void Traverse(ushort start, bool isDFT, Func<Vertex, bool> Process)
        {
            EnsureVertexExists(start);
            Vertex startVertex = Vertices[start];
            MyHashSet<Vertex> available = new MyHashSet<Vertex>(Vertices);
            available.Remove(startVertex);
            if (isDFT) DFTBase(startVertex, available, Process);
            else BFTBase(startVertex, available, Process);
        }

        protected void DFTBase(Vertex start, MyHashSet<Vertex> available, Func<Vertex, bool> Process)
        {
            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                Vertex curVer = stack.Pop();
                if (Process(curVer)) break;
                foreach (Vertex v in GetExistOutEdgesUnsafe(curVer))
                    if (available.Remove(v)) stack.Push(v);
            }
        }

        protected void BFTBase(Vertex start, MyHashSet<Vertex> available, Func<Vertex, bool> Process)
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                Vertex curVer = queue.Dequeue();
                if (Process(curVer)) break;
                foreach (Vertex v in GetExistOutEdgesUnsafe(curVer))
                    if (available.Remove(v)) queue.Enqueue(v);
            }
        }

        public Path GetTraversal(ushort start, bool isDFT)
        {
            Path result = new Path(0);
            bool TraversalBuilder(Vertex v)
            {
                result.Add(v.Id);
                return false;
            }
            Traverse(start, isDFT, TraversalBuilder);
            return result;
        }

        public bool ConnectedVertices(ushort source, ushort destination, out List<ushort> connectedVertices)
        {
            bool result = false;
            List<ushort> conVertices = new List<ushort>();
            bool VertexCollector(Vertex v)
            {
                if (v.Id == destination) result = true;
                conVertices.Add(v.Id);
                return false;
            }
            Traverse(source, false, VertexCollector);
            connectedVertices = conVertices;
            return result;
        }
    }
}
