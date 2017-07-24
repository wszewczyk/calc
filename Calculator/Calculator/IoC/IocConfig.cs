namespace Calculator.IoC
{
    using Autofac;

    using Calculator.Command;
    using Calculator.Command.CommandSYMath;

    public class IocConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationLogic>();
            builder.RegisterType<SYMathCalculator>().As<ICalculator<int>>();
            builder.RegisterType<SYMathCommandReciver>().As<ISYReciever>();
            var container = builder.Build();
            return container;
        }

    }
}
