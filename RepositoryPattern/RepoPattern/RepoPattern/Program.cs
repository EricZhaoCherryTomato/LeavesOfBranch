using System;
using System.Reflection;
using Autofac;
using Autofac.Builder;

namespace RepoPattern
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(assemblies);
            var container = builder.Build();

            var scope = container.BeginLifetimeScope();

            var  ps = scope.Resolve<IPersonService>();

            var person = ps.GetPerson(1);

            Console.WriteLine(person.FirstName);
            Console.ReadKey(true);
        }
    }
}