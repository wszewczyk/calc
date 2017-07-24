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

        public int GetResult(int x, int y)
        {
            int result;
            if (currentAction == SY_OPERATION_LIST.ADD)
            {
                result = x + y;

            }
            else if (currentAction == SY_OPERATION_LIST.MULTIPLY)
            {
                result = x * y;
            }
            else if (this.currentAction == SY_OPERATION_LIST.SUBTRACT)
            {
                result = x - y;
            }
            else if (this.currentAction == SY_OPERATION_LIST.DIV)
            {
                result = x / y;
            }
            else if (this.currentAction == SY_OPERATION_LIST.POW)
            {
                result = (int)Math.Pow(x, y);
            }
            else
            {
                throw new Exception("Unknown operation");
            }
            return result;
        }
    }

}
