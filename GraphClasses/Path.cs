using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphClasses
{
    public class Path : List<ushort>
    {
        public ushort From => this.First();

        public ushort To => this.Last();

        public int VertexCount => Count;

        public int EdgeCount => VertexCount - 1;

        public ulong Length { get; protected set; }

        public bool IsCycle => From == To;

        public Path(ulong initLength)
        {
            Length = initLength;
        }

        public Path(ulong initLength, IEnumerable<ushort> initPath) : base(initPath)
        {
            Length = initLength;
        }

        public string FullInfo()
        {
            StringBuilder strb = new StringBuilder($"Длина: {Length}" + Environment.NewLine);
            strb.AppendLine("Путь: ");
            strb.Append(this.ToString());
            return strb.ToString();
        }

        public override string ToString()
        {
            if (VertexCount == 0) return "пустой путь";
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < VertexCount; i++) strb.Append($"{this[i]}=>");
            strb.Remove(strb.Length - 2, 2);
            return strb.ToString();
        }
    }
}

