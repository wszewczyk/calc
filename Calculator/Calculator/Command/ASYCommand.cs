namespace Calculator.Command
{
    public abstract class ASYCommand
    {
        protected ISYReciever reciever = null;

        public ASYCommand(ISYReciever rec)
        {
            reciever = rec;
        }

        public abstract int Execute(int x, int y);
    }
}
