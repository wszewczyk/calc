namespace Calculator
{
    using System.Collections.Generic;

    public interface ICalculator<TResult, TInput>
    {
        TResult Execute(List<TInput> InputList);
    }
}
