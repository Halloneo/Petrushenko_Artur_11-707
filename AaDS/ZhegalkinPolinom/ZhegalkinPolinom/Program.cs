using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhegalkinPolinom
{
    class Program
    {
        static void Main(string[] args)
        {
            ZhegalkinPolinom pol = ZhegalkinPolinom.MakeZhegalkinPolinom("-x1&x2&-x3+x2&-x4+x4&x1&x3+1");
            ZhegalkinPolinom pol1 = ZhegalkinPolinom.MakeZhegalkinPolinom("-x1&x2&x3+x2&-x4&x1+x4&x1&x3+1");
            ZhegalkinPolinom sum = pol.Sum(pol1);
            sum.SortByLength();
            //sum = sum.MakePolinomWith(2);
            Console.WriteLine(sum);
        }
    }
}
