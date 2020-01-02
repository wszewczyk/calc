namespace Calculator.Command
{
    public abstract class ASYCommand
    {
        protected ISYReciever reciever = null;

        public ASYCommand(ISYReciever rec)
        {
            reciever = rec;
        }

        public abstract double Execute(double x, double y);
    }
}
