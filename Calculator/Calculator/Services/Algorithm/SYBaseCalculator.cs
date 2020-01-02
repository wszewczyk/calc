using System;
using System.Collections.Generic;
using Calculator.Models;
using Calculator.Models.Enums;

namespace Calculator.Services.Algorithm
{
    public abstract class SYBaseCalculator<TResult, TInput> : ICalculator<TResult>
    {
        public TResult Execute(object expression)
        {
            List<TInput> inputList = this.Split(expression);
            Stack<object> inter = new Stack<object>();
            Stack<char> opr = new Stack<char>();
            foreach (TInput input in inputList)
            {
                if (IsForbidden(input)) throw new Exception("Bad formula");
                char? o = TypecastOperator(input);
                if (IsOperator(o))
                {
                    while (opr.Count > 0)
                    {
                        char ot = opr.Peek();
                        if (IsOperator(ot)
                            && ((Association((char)o) == Associativity.Left
                                 && Precedence((char)o, ot) <= 0)
                                || (Association((char)o) == Associativity.Right
                                    && Precedence((char)o, ot) < 0))) inter.Push(opr.Pop());
                        else break;
                    }

                    opr.Push((char)o);
                }
                else if (IsIdentifier(input))
                {
                    inter.Push(input);

                }
                else if (input.ToString() == "(")
                {
                    opr.Push('(');
                }
                else if (input.ToString() == ")")
                {
                    bool pe = false;
                    while (opr.Count > 0)
                    {
                        char sc = opr.Peek();
                        if (sc == '(')
                        {
                            pe = true;
                            break;
                        }
                        else inter.Push(opr.Pop());
                    }

                    if (!pe) throw new Exception("No Left (");
                    opr.Pop();
                }
                else
                {
                    if (IsForbidden(input)) throw new Exception("Undefined token");
                }
            }

            while (opr.Count > 0) inter.Push(opr.Pop());

            Queue<object> res = new Queue<object>(inter.Reverse());
            Stack<TResult> var = new Stack<TResult>();

            while (res.Count > 0)
            {
                object o = res.Dequeue();
                if (o.GetType() == typeof(TInput))
                {
                    var.Push(TypecastIdentifier((TInput)o));
                }

                if (o is char c)
                {
                    var r = var.Pop();
                    var l = var.Pop();
                    var.Push(Evaluate(l, c, r));
                }
            }

            return var.Peek();
        }

        protected abstract bool IsForbidden(TInput input);
        protected abstract TResult Evaluate(TResult result1, char opr, TResult result2);
        protected abstract TResult TypecastIdentifier(TInput input);
        protected abstract bool IsIdentifier(TInput input);
        protected abstract double Precedence(char opr1, char opr2);
        protected abstract Associativity Association(char opr);
        protected abstract bool IsOperator(char? Opr);
        protected abstract char? TypecastOperator(TInput opr);
        protected abstract List<TInput> Split(object expression);
    }
}