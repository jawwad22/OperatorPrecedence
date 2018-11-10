using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorPrece
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute("A+B/C*D");
            //see in Debug mode
        }
        public static Stack<string> Execute(string input)
        {
            Stack<string> stack = new Stack<string>();
            Stack<string> OPstack = new Stack<string>();

            string st;
            for (int i = 0; i < input.Length; i++)
            {
                if (!("()*/+-".Contains(input[i])))
                {
                    OPstack.Push(input[i].ToString());
                }
                else
                {
                    if (input[i].Equals("("))
                    {
                        stack.Push("(");
                    }
                    else if (input[i].Equals(")"))
                    {
                        st = stack.Pop();
                        while (!(st.Equals("(")))
                        {
                            OPstack.Push(st);
                            st = stack.Pop();
                        }
                    }
                    else
                    {
                        while (stack.Count > 0)
                        {
                            st = stack.Pop();
                            if (checkPriority(st) >= checkPriority(input[i].ToString()))
                            {
                                OPstack.Push(st);
                            }
                            else
                            {
                                stack.Push(st);
                                break;
                            }
                        }
                        stack.Push(input[i].ToString());
                    }
                }
            }
            while (stack.Count > 0)
            {
                OPstack.Push(stack.Pop());
            }

            return OPstack; //OUTPUT ARRAY
        }

        private static int checkPriority(string p)
        {
            switch (p)
            {
                case "(":
                case ")":
                    return 5;
                case "/":
                    return 4;
                case "*":
                    return 3;
                case "+":
                    return 2;
                case "-":
                    return 1;
            }
            return 0;
        }
    }
}


