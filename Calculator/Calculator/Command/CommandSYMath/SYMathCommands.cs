namespace Calculator.Command.CommandSYMath
{
    public class AddCommand : ASYCommand
    {
        public AddCommand(ISYReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute(int x, int y)
        {
            reciever.SetAction(SY_OPERATION_LIST.ADD);
            return reciever.GetResult(x, y);
        }
    }

    public class SubtractCommand : ASYCommand
    {
        public SubtractCommand(ISYReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute(int x, int y)
        {
            reciever.SetAction(SY_OPERATION_LIST.SUBTRACT);
            return reciever.GetResult(x, y);
        }
    }

    public class MultiplyCommand : ASYCommand
    {
        public MultiplyCommand(ISYReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute(int x, int y)
        {
            reciever.SetAction(SY_OPERATION_LIST.MULTIPLY);
            return reciever.GetResult(x, y);
        }
    }

    public class DivCommand : ASYCommand
    {
        public DivCommand(ISYReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute(int x, int y)
        {
            reciever.SetAction(SY_OPERATION_LIST.DIV);
            return reciever.GetResult(x, y);
        }
    }

    public class PowCommand : ASYCommand
    {
        public PowCommand(ISYReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute(int x, int y)
        {
            reciever.SetAction(SY_OPERATION_LIST.POW);
            return reciever.GetResult(x, y);
        }
    }

}
