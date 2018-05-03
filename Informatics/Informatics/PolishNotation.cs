using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatics
{
    class PolskaSolver
    {
        public double Answer;
        string Str;

        public PolskaSolver(string str)
        {
            Str = Convert(str);
            Answer = Solve(Str);
        }

        int Priority(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 2;
                case '*':
                    return 3;
                case '/':
                    return 3;
                case '(':
                    return 1;
                case ')':
                    return 1;
                default:
                    return 0;
            }
        }

        protected bool StackChecker(Stack<char> stack, char ch)
        {
            foreach (var item in stack)
                if (Priority(item) > Priority(ch))
                    return false;
            return true;
        }

        public override string ToString()
        {
            return $"In PolishForm {Str}, Answer : {Answer}";
        }

        public string Convert(string str)
        {
            StringBuilder newStr = new StringBuilder();
            var stack = new Stack<char>();
            var list = new List<List<string>>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '+' && str[i] != '-' && str[i] != '*' && str[i] != '/' && str[i] != '(' && str[i] != ')')
                {
                    while (Char.IsDigit(str[i]))
                    {
                        newStr.Append(str[i]);
                        i++;
                        if (i == str.Length)
                            break;

                    }
                    i--;
                    newStr.Append('|');
                }
                else
                {
                    if (str[i] != '(' && str[i] != ')')
                    {
                        if (stack.Count == 0 || StackChecker(stack, str[i]))
                        {
                            stack.Push(str[i]);
                        }
                        else
                        {
                            while (Priority(stack.Peek()) >= Priority(str[i]))
                            {
                                newStr.Append(stack.Pop());

                                if (stack.Count == 0) break;
                            }
                            if (stack.Count == 0 || StackChecker(stack, str[i]))
                                stack.Push(str[i]);
                        }
                    }
                    else if (str[i] == '(')
                    {
                        stack.Push(str[i]);
                    }
                    else if (str[i] == ')')
                    {
                        while (stack.Pop() != '(')
                            newStr.Append(stack.Pop());
                    }

                }
            }

            while (stack.Count != 0)
                newStr.Append(stack.Pop());

            return newStr.ToString();
        }

        public double Solve(string str)
        {
            var stack = new Stack<double>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '+' && str[i] != '-' && str[i] != '*' && str[i] != '/')
                {
                    string number = "";
                    while (str[i] != '|')
                    {
                        number += str[i];
                        i++;
                    }
                    stack.Push(double.Parse(number));
                }
                else
                    switch (str[i])
                    {
                        case '+':
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }

                        case '-':
                            {
                                var temp = stack.Pop();
                                stack.Push(stack.Pop() - temp);
                                break;
                            }
                        case '*':
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case '/':
                            {
                                var temp = stack.Pop();
                                stack.Push(stack.Pop() / temp);
                                break;
                            }
                        default:
                            throw new ArgumentException("Wrong operation exception");
                    }
            }
            return stack.Peek();
        }
    }

    class ConverterAndSolver
    {
        public static double ConvertAndSolve(string str)
        {
            return new PolskaSolver(str).Answer;
        }

        static void Do(string[] args)
        {
            var str = "25+3*8+4/2-6";
            //238*+42/+6- 
            var polstr = new PolskaSolver(str);
            Console.WriteLine(polstr.ToString());
            var answer = ConvertAndSolve(str);
            Console.WriteLine(answer);
        }
    }

}