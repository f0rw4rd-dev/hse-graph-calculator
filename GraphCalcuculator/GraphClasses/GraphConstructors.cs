using System;
using System.Collections.Generic;
using System.Linq;
using MyHashSet;

namespace GraphClasses
{
    public partial class Graph
    {
        #region Constructors

        public Graph() => Vertices = new MyHashSet.IndexedHashSet<ushort, Vertex>(10);

        public Graph(ushort numVertex)
        {
            if (numVertex > MaxVertexNum) throw new ArgumentException($"Количество вершин графа не должно превышать {MaxVertexNum:N0}.");
            Vertices = new MyHashSet.IndexedHashSet<ushort, Vertex>(numVertex);
            for (ushort i = 1; i <= numVertex; i++) AddVertexUnsafe(new Vertex(i));
        }

        protected void ThrowCreationException(int line, string reason) =>
            throw new FormatException($"Ошибка в строке {line}!" + Environment.NewLine +
                                      reason);

        public Graph(string[] lines)
        {
            if (lines is null) throw new ArgumentNullException(nameof(lines));
            switch (lines[0].FirstOrDefault())
            {
                case 'S':FromVerEdgSets(lines); break;
                case 'M': FromAdjMtx(lines); break;
                default: ThrowCreationException(1, "Неопознанный маркер формы."); break;
            }
        }

        protected void FromVerEdgSets(string[] lines)
        {

            string[] vertices = lines[0].Split(' ');
            if (vertices.Length - 1 > MaxVertexNum)
                ThrowCreationException(1, $"Количество вершин не должно превышать {MaxVertexNum:N0}.");
            Vertices = new IndexedHashSet<ushort, Vertex>(vertices.Length - 1);

            // Добавляем вершины
            for (int i = 1; i < vertices.Length; i++)
            {
                if (!ushort.TryParse(vertices[i], out ushort vertex))
                    ThrowCreationException(1, $"Некорректный формат номера вершины {vertices[i]}.");
                if (vertex <= 0)
                    ThrowCreationException(1, $"Номер вершины {vertex} должен быть положительным числом.");
                if (!AddVertexUnsafe(new Vertex(vertex)))
                    ThrowCreationException(1, $"Вершина {vertex} встретилась второй раз.") ;
            }

            // Добавляем ребра
            for (int line = 1; line < lines.Length; line++)
            {
                int curLine = line + 1;
                if (string.IsNullOrWhiteSpace(lines[line])) continue;
                string[] edge = lines[line].Split(' ');
                if (edge.Length != 4) ThrowCreationException(curLine, "Некорректный формат ребра.");
                if (ushort.TryParse(edge[0], out ushort from) &&
                    ushort.TryParse(edge[1], out ushort to) &&
                    uint.TryParse(edge[2], out uint length) &&
                    (edge[3].ToUpper() == "О" || edge[3].ToUpper() == "Н"))
                {
                    if (!Vertices.Peek(from, out Vertex frVer))
                        ThrowCreationException(curLine, $"Вершина {from} не существует.");
                    if (!Vertices.Peek(to, out Vertex toVer))
                        ThrowCreationException(curLine, $"Вершина {to} не существует.");
                    if (length == 0 || length > MaxEdgeLen)
                        ThrowCreationException(curLine, $"Длина ребра должна быть больше нуля и не превышать {MaxEdgeLen:N0}.");
                    bool isDir = edge[3].ToUpper() == "О";
                    EdgeData toFrom = GetEdgeStateUnsafe(toVer, frVer.Id);
                    if (!isDir && toFrom.Exists)
                        if (toFrom.IsDir)
                            ThrowCreationException(curLine, $"Существует ориентированное ребро {to}-{from}.");
                        else if (toFrom.Length == length) continue;
                    if (!AddEdgeUnsafe(frVer, toVer, length, isDir))
                        ThrowCreationException(curLine, "Данное ребро уже существует.");
                }
                else ThrowCreationException(curLine, "Некорректные значения для ребра.");
            }
        }

        protected void FromAdjMtx(string[] lines)
        {
            string[] verticesStr = lines[0].Split(',');
            if (verticesStr.Length != lines.Length) ThrowCreationException(1, "Матрица должна быть квадратной.");
            if (verticesStr.Length - 1 > MaxVertexNum)
                ThrowCreationException(1, $"Количество вершин не должно превышать {MaxVertexNum:N0}.");
            Vertices = new IndexedHashSet<ushort, Vertex>(verticesStr.Length - 1);
            List<Vertex> vertices = new List<Vertex>(verticesStr.Length - 1);

            // Добавляем вершины
            for (int i = 1; i < verticesStr.Length; i++)
            {
                if (!ushort.TryParse(verticesStr[i], out ushort vertex))
                    ThrowCreationException(1, $"Некорректный формат номера вершины {verticesStr[i]}.");
                if (vertex <= 0)
                    ThrowCreationException(1, $"Номер вершины {vertex} должен быть положительным числом.");
                Vertex ver = new Vertex(vertex);
                if (!AddVertexUnsafe(ver))
                    ThrowCreationException(1, $"Вершина {vertex} встретилась второй раз.");
                vertices.Add(ver);
            }

            MyHashSet<ushort> usedVertices = new MyHashSet<ushort>(vertices.Count);
            // Добавляем ребра
            for (int line = 1; line < lines.Length; line++)
            {
                int curLine = line + 1;
                if (string.IsNullOrWhiteSpace(lines[line])) ThrowCreationException(curLine, "Пустая строка.");
                string[] edges = lines[line].Split(',');
                if (edges.Length != lines.Length) ThrowCreationException(curLine, "Неверная длина строки.");
                if (!ushort.TryParse(edges[0], out ushort from))
                    ThrowCreationException(curLine, $"Некорректный формат номера вершины {edges[0]}.");
                if (usedVertices.Contains(from))
                    ThrowCreationException(curLine, $"Вершина {from} встретилась второй раз.");
                usedVertices.Add(from);
                if (!Vertices.Peek(from, out Vertex frVer))
                    ThrowCreationException(curLine, $"Вершина {from} не существует.");
                for (int i = 1; i < edges.Length; i++)
                {
                    Vertex toVer = vertices[i - 1];
                    string currentEdge = $"{frVer.Id}-{toVer.Id}";
                    string[] edge = edges[i].Split(';');
                    if (!uint.TryParse(edge[0], out uint length) ||
                        edge.Length == 1 && length != 0 ||
                        edge.Length == 2 && (length == 0 || edge[1].ToUpper() != "О" && edge[1].ToUpper() != "Н") ||
                        edge.Length > 2)
                        ThrowCreationException(curLine, $"Некорректный формат ребра {currentEdge}.");                    
                    if (length == 0) continue;
                    bool isDir = edge[1].ToUpper() == "О";
                    EdgeData toFrom = GetEdgeStateUnsafe(toVer, frVer.Id);
                    if (!isDir && toFrom.Exists)
                        if (toFrom.IsDir)
                            ThrowCreationException(curLine, $"Существует ориентированное ребро {toVer.Id}-{frVer.Id}.");
                        else if (toFrom.Length == length) continue;
                    if (!AddEdgeUnsafe(frVer, toVer, length, isDir))
                        ThrowCreationException(curLine, $"Ребро {currentEdge} уже существует.");
                }
            }
        }

        #endregion
    }
}
