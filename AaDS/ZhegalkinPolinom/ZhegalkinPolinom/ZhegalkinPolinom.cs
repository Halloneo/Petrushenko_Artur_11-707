using System.Text;

namespace ZhegalkinPolinom
{
    class ZhegalkinPolinom
    {
        public int Count = 0;

        public SinglyLinkedConjunctList ListOfConjuncts = new SinglyLinkedConjunctList();
        
        public void Insert(Conjunct newConjunct)
        {
            if (!ListOfConjuncts.Contains(newConjunct))
                ListOfConjuncts.Add(newConjunct);              
        }
        
        public ZhegalkinPolinom MakePolinomWith(int variable)
        {
            var newPolinom = new ZhegalkinPolinom();
            foreach (var elem in ListOfConjuncts)
            {
                if (elem.Data.VarIsIncluded[variable - 1])
                    newPolinom.Insert(elem.Data);
            }
            return newPolinom;
        }
        
        public static ZhegalkinPolinom MakeZhegalkinPolinom(string s)
        {
            var polinom = new ZhegalkinPolinom();
            var splittedString = s.Split('+');
            foreach (var conj in splittedString)
            {
                polinom.Insert(new Conjunct(conj));
            }
            return polinom;
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var conjunct in ListOfConjuncts)
            {
                sb.Append(conjunct.Data);
                sb.Append("+");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public ZhegalkinPolinom Sum(ZhegalkinPolinom polinom)
        {
            var sum = new ZhegalkinPolinom();

            foreach (var conjunct in this.ListOfConjuncts)
                sum.Insert(conjunct.Data);
            foreach (var conjunct in polinom.ListOfConjuncts)
                sum.Insert(conjunct.Data);

            return sum;
        }

        public bool GetValue(bool[] values)
        {
            bool nothingWasCounted = true;
            bool result = true;
            foreach (var conjunct in ListOfConjuncts)
            {
                if (nothingWasCounted)
                    result = conjunct.Data.GetValue(values);
                else
                {
                    if (conjunct.Data.GetValue(values) == result)
                        result = false;
                    else
                        result = true;
                }
            }
            return result;
        }

        public void SwapData(Node firstNode, Node secondNode)
        {
            var tmpData = firstNode.Data;
            firstNode.Data = secondNode.Data;
            secondNode.Data = tmpData;
        }

        public void SortByLength()
        {
            foreach (var firstElem in ListOfConjuncts)
                foreach (var secondElem in ListOfConjuncts)
                {
                    if (firstElem.Data.VarCount < secondElem.Data.VarCount)
                        SwapData(firstElem, secondElem);
                }
        }
    }
}
