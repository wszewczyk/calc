namespace Calculator.IoC
{
    using Autofac;

    public class IocConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationLogic>();
            builder.RegisterType<SYMathCalculator>().As<ICalculator<int>>();
            var container = builder.Build();
            return container;
        }

    }
}
