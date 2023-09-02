using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        /// <summary>
        /// Поиск кратчайшего пути от вершины source до destination при помощи алгоритма Дейкстры
        /// </summary>
        /// <param name="from">Начальная вершина</param>
        /// <param name="to">Конечная вершина</param>
        /// <returns>Кратчайший путь</returns>
        public Path FindShortestPath(ushort from, ushort to)
        {
            EnsureVertexExists(from);
            if (from == to) return new Path(0) { from };
            EnsureVertexExists(to);
            if (!ConnectedVertices(from, to, out List<ushort> possiblePaths)) return null;

            // Первичная инициализация, подготовка для работы алгоритма
            IndexedHashSet<ushort, DijkstraVertex> dijkstraVertices = new IndexedHashSet<ushort, DijkstraVertex>(possiblePaths.Count);
            foreach (ushort v in possiblePaths) dijkstraVertices.Add(new DijkstraVertex(v, true, ulong.MaxValue, from));
            DijkstraVertex origin = new DijkstraVertex(from, true, 0, from);

            // Перебираем вершины, в которые можно попасть из текущей вершины
            for (int i = 0; i < possiblePaths.Count; i++)
            {
                if (origin.Id == to) break; //Преждевременный выход при достижении to
                dijkstraVertices[origin.Id] = new DijkstraVertex(origin, false); // Отмечаем вершину пройденной                
                Vertex originVertex = Vertices[origin.Id];

                // Перебираем все вершины, в которые есть прямой путь из данной вершины, назначаем "метку"
                foreach (ushort v in originVertex.AdjVertices)
                {
                    DijkstraVertex target = dijkstraVertices[v];
                    if (!target.Available) continue; //Проверка, что до вешины ещё не найден мин путь
                    ulong newDistance = origin.Distance + originVertex[v].Length;
                    if (newDistance < target.Distance) dijkstraVertices[v] = new DijkstraVertex(target, newDistance, origin.Id);
                }

                // Выбор следующей вершины с минимальной меткой
                origin = dijkstraVertices.Where(v => v.Available).Min();
            }

            // Составляем путь
            Path shortestPath = new Path(dijkstraVertices[to].Distance) { to };
            ushort pathVertex = to;
            do
            {
                pathVertex = dijkstraVertices[pathVertex].Previous;
                shortestPath.Add(pathVertex);
            } while (pathVertex != from);
            shortestPath.Reverse();

            return shortestPath;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        protected readonly struct DijkstraVertex : IIndexable<ushort>, IComparable<DijkstraVertex>
        {
            public ushort Id { get; }
            public readonly bool Available;
            public readonly ulong Distance;            
            public readonly ushort Previous;

            public DijkstraVertex(ushort id, bool available, ulong distance, ushort previous)
            {
                Id = id;
                Available = available;
                Distance = distance;
                Previous = previous;
            }

            public DijkstraVertex(DijkstraVertex prevState, ulong distance, ushort previous)
            {
                this.Id = prevState.Id;
                this.Available = prevState.Available;
                this.Distance = distance;
                this.Previous = previous;
            }

            public DijkstraVertex(DijkstraVertex prevState, bool available)
            {
                this.Id = prevState.Id;
                this.Available = available;
                this.Distance = prevState.Distance;
                this.Previous = prevState.Previous;
            }

            public int CompareTo(DijkstraVertex other) => this.Distance.CompareTo(other.Distance);
        }
    }
}
