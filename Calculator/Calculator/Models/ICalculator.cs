namespace Calculator.Models
{
    public interface ICalculator<out TResult>
    {
        TResult Execute(object expression);
    }
}
