namespace Calculator
{
    using System.Collections.Generic;

    public interface ICalculator<TResult>
    {
        TResult Execute(object expression);
    }
}
