using System;

namespace ZhegalkinPolinom
{
    public class Conjunct
    {
        public bool[] VarIsIncluded = new bool[4];
        
        public bool[] VarIsComplement = new bool[4];
        
        public bool IsOne = true;
        
        public int VarCount = 0;
        
        private int CompCount = 0;
        
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
        
        public override bool Equals(object obj)
        {
            var conj = obj as Conjunct;
            for (int i = 0; i < VarIsIncluded.Length; i++)
            {
                if (conj.VarIsIncluded[i] != this.VarIsIncluded[i] || conj.VarIsComplement[i] != this.VarIsComplement[i])
                    return false;
            }
            return true;
        }
        
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
    }
}
