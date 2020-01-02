using Calculator.Models;
using Calculator.Services.Algorithm;

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
            builder.RegisterType<SYMathCalculator>().As<ICalculator<double>>();
            builder.RegisterType<SYMathCommandReciver>().As<ISYReciever>();
            var container = builder.Build();
            return container;
        }

    }
}
