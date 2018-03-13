using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhegalkinPolinom
{
    /// <summary>
    /// Class of conjuncts for Zhegalkin polinom
    /// </summary>
    class Conjunct : IComparable
    {
        /// <summary>
        /// Shows if variable is in conjunct
        /// </summary>
        public bool[] VarIsIncluded = new bool[4];

        /// <summary>
        /// Shows if included variable is complement
        /// </summary>
        public bool[] VarIsComplement = new bool[4];

        /// <summary>
        /// Shows if conjuct equals to 1
        /// </summary>
        public bool IsOne = true;

        /// <summary>
        /// Amount of included variables
        /// </summary>
        private int VarCount = 0;

        /// <summary>
        /// Amount of complement variables
        /// </summary>
        private int CompCount = 0;

        /// <summary>
        /// Makes new conjunct
        /// </summary>
        /// <param name="variables">Number of included variables (If null, then makes conjunct that equals 1)</param>
        public Conjunct(params int[] variables)
        {
            if (variables != null)
            {
                IsOne = false;
                foreach (var variable in variables)
                {
                    if (variable < 0)
                    {
                        VarIsComplement[Math.Abs(variable) - 1] = true;
                        CompCount++;
                    }
                    VarIsIncluded[Math.Abs(variable) - 1] = true;
                    VarCount++;
                }
            }
        }

        /// <summary>
        /// Makes new conjunct from string
        /// </summary>
        /// <param name="conjString">String represent of conjunct</param>
        public Conjunct(string conjString)
        {
            if (conjString != "1")
            {
                this.IsOne = false;
                var splittedConj = conjString.Split('&');
                foreach (var variable in splittedConj)
                {
                    var number = (variable[variable.Length - 1] - '0') - 1;
                    this.VarIsIncluded[number] = true;
                    this.VarCount++;
                    if (variable[0] == '-')
                    {
                        this.VarIsComplement[number] = true;
                        this.CompCount++;
                    }
                }
            }
        }

        /// <summary>
        /// Makes string from conjunct
        /// </summary>
        /// <returns>String represent of conjunct</returns>
        public override string ToString()
        {
            if (IsOne) return "1";
            var conj = "";
            bool somethingWasPrinted = false;
            for (var i = 0; i < VarIsIncluded.Length; i++)
            {
                if (VarIsIncluded[i])
                {
                    if (somethingWasPrinted)
                        conj += "&";
                    if (VarIsComplement[i])
                        conj += $"-x{i + 1}";
                    else
                        conj += $"x{i + 1}";
                    somethingWasPrinted = true;
                }
            }
            return conj;
        }

        /// <summary>
        /// Checks if two conjucts are equal
        /// </summary>
        /// <param name="obj">Conjunct</param>
        /// <returns>Are conjuncts equal or not</returns>
        public override bool Equals(object obj)
        {
            var conj = obj as Conjunct;
            for(int i = 0; i < VarIsIncluded.Length; i++)
            {
                if (conj.VarIsIncluded[i] != this.VarIsIncluded[i] || conj.VarIsComplement[i] != this.VarIsComplement[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Counts value of polinom on set of values
        /// </summary>
        /// <param name="values">Set of values</param>
        /// <returns>True\False</returns>
        public bool GetValue(bool[] values)
        {
            if (IsOne) return true;
            bool result = true;
            for (int i = 0; i < values.Length; i++)
            {
                if (VarIsComplement[i])
                    result = result && !values[i];
                else
                    result = result && values[i];
            }
            return result;
        }

        /// <summary>
        /// Gets hash code of conjunct
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -595977561;
            hashCode = hashCode * -1521134295 + EqualityComparer<bool[]>.Default.GetHashCode(VarIsIncluded);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool[]>.Default.GetHashCode(VarIsComplement);
            hashCode = hashCode * -1521134295 + IsOne.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares two conjuncts
        /// </summary>
        /// <param name="obj">Conjunct to compare with</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the value parameter</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Conjunct)) throw new Exception("Wrong comparement exception");
            var conjunct = obj as Conjunct;
            
            if (this.IsOne && conjunct.IsOne)
                return 0;

            if (this.VarCount > conjunct.VarCount)
                return 1;
            if (this.VarCount < conjunct.VarCount)
                return -1;

            if (this.CompCount > conjunct.CompCount)
                return 1;
            if (this.CompCount < conjunct.CompCount)
                return -1;
            
            var thisVarString = "";
            var conjunctVarString = "";
            var thisCompString = "";
            var conjunctCompString = "";
            for (int i = 0; i < VarIsIncluded.Length; i++)
            {
                if (this.VarIsIncluded[i])
                    thisVarString += $"{i + 1}";
                if (conjunct.VarIsIncluded[i])
                    conjunctVarString += $"{i + 1}";
                if (this.VarIsComplement[i])
                    thisCompString += $"{i + 1}";
                if (conjunct.VarIsComplement[i])
                    conjunctCompString += $"{i + 1}";
            }
            if (!thisVarString.Equals(conjunctVarString))
                return thisVarString.CompareTo(conjunctVarString);
            if (!thisCompString.Equals(conjunctCompString))
                return thisCompString.CompareTo(conjunctCompString);
            return 0;
        }
    }
    
    /// <summary>
    /// Class of Zhegalkin polinom
    /// </summary>
    class ZhegalkinPolinom
    {
        /// <summary>
        /// Array with included conjuncts
        /// </summary>
        Conjunct[] Polinom = new Conjunct[50];
        /// <summary>
        /// Amount of included conjuncts
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// Adds conjunct to polinom
        /// </summary>
        /// <param name="conj">Conjunct</param>
        public void Insert(Conjunct conj)
        {
            if (Count == Polinom.Length) return;
            for (int i = 0; i < Count; i++)
            {
                if (conj.Equals(Polinom[i]))
                    return;
            }
            Polinom[Count] = conj;
            Count++;
        }

        /// <summary>
        /// Makes new polinom with conjuncts including certain variable
        /// </summary>
        /// <param name="i">Variable number</param>
        /// <returns>New polinom</returns>
        public ZhegalkinPolinom MakePolinomWith(int variable)
        {
            var newPolinom = new ZhegalkinPolinom();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Polinom[i].VarIsIncluded[i - 1])
                    newPolinom.Insert(this.Polinom[i]);
            }
            return newPolinom;
        }

        /// <summary>
        /// Makes Zhegalkin polinom from string
        /// </summary>
        /// <param name="s">String represent of polinom</param>
        /// <returns>Zhegalkin polinom</returns>
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

        /// <summary>
        /// Makes string represent of Zhegalkin polinom
        /// </summary>
        /// <returns>String represent of Zhegalkin polinom</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(Polinom[i]);
                if (i != Count - 1)
                    builder.Append("+");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Makes sum from two polinoms
        /// </summary>
        /// <param name="polinom">Polinom to sum with</param>
        /// <returns>Summed polinoms</returns>
        public ZhegalkinPolinom Sum(ZhegalkinPolinom polinom)
        {
            foreach (var conjunct in polinom.Polinom)
                this.Insert(conjunct);
            return this;
        }

        /// <summary>
        /// Checks the result on the set of values
        /// </summary>
        /// <param name="values">Boolean set of values</param>
        /// <returns>Value of polinom</returns>
        public bool GetValue(bool[] values)
        {
            bool result = Polinom[0].GetValue(values);
            for (int i = 1; i < Count; i++)
            {
                var conjunctValue = Polinom[i].GetValue(values);
                if (conjunctValue == result)
                    result = false;
                else
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// Sorts polinom by length of conjuncts
        /// </summary>
        public void SortByLength()
        {
            for (int i = 0; i < Count; i++)
                for (int j = i + 1; j < Count; j++)
                    if (Polinom[i].CompareTo(Polinom[j]) > 0)
                    {
                        var pol = Polinom[j];
                        Polinom[j] = Polinom[i];
                        Polinom[i] = pol;
                    }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
