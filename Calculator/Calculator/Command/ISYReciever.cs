namespace Calculator.Command
{
    public enum SY_OPERATION_LIST
    {
        ADD,
        SUBTRACT,
        MULTIPLY,
        DIV,
        POW
    }

    public interface ISYReciever
    {
        void SetAction(SY_OPERATION_LIST action);
        int GetResult(int x, int y);
    }

}
