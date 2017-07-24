namespace Calculator
{
    using Autofac;

    using Calculator.IoC;

    class Program
    {
        static void Main(string[] args)
        {
            var container = IocConfig.Configure();

            var application = container.Resolve<ApplicationLogic>();

            application.Run();
        }
    }
}