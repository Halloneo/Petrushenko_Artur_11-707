using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatics
{
    class Element
    {
        public Element Left { get; set; }
        public Element Right { get; set; }
        public int Info { get; set; }

        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }


        public Element(int leftIndex, int rightIndex, int[] values, Func<int, int, int> func)
        {
            if (leftIndex == rightIndex)
            {
                Info = values[leftIndex];
            }
            else
            {
                int middle = (leftIndex + rightIndex) / 2;
                Left = new Element(leftIndex, middle, values, func);
                Right = new Element(middle + 1, rightIndex, values,  func);
                Info = func(Right.Info, Left.Info);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Left == Right)
                sb.Append(Info);
            else
            {
                sb.Append($"({Info},");
                sb.Append(Left);
                sb.Append(",");
                sb.Append(Right);
                sb.Append(")");
            }
            return sb.ToString();
        }

    }

    class SegmentTree
    {
        public Element Root { get; set; }
        public int[] Values { get; set; }

        public SegmentTree(int[] values)
        {
            var size = 1;
            while (size < values.Length)
            {
                size <<= 1;
            }
            Values = new int[size];
            Array.Copy(values, Values, values.Length);
            Root = new Element(0, Values.Length - 1, Values, (x, y) => x + y);

        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }
}
