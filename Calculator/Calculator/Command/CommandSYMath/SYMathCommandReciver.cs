namespace Calculator.Command.CommandSYMath
{
    using System;

    public class SYMathCommandReciver : ISYReciever
    {
        SY_OPERATION_LIST currentAction;

        public void SetAction(SY_OPERATION_LIST action)
        {
            currentAction = action;
        }

        public double GetResult(double x, double y)
        {
            double result;

            switch (currentAction)
            {
                case SY_OPERATION_LIST.ADD:
                    result = x + y;
                    break;
                case SY_OPERATION_LIST.MULTIPLY:
                    result = x * y;
                    break;
                case SY_OPERATION_LIST.SUBTRACT:
                    result = x - y;
                    break;
                case SY_OPERATION_LIST.DIV:
                    result = x / y;
                    break;
                case SY_OPERATION_LIST.POW:
                    result = (double)Math.Pow(x, y);
                    break;
                default:
                    throw new Exception("Unknown operation");
            }

            return result;
        }
    }

}
