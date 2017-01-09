using System;
using Autofac;

namespace AutoFacMemeroyLeak
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyComponent>();
            var container = builder.Build();
            test(container);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadKey(true);
        }

        public static void test(ILifetimeScope scope)
        {
            var localScope = scope.BeginLifetimeScope();
            using (var auxComponent = localScope.Resolve<MyComponent>())
            { }
        }
    }
}