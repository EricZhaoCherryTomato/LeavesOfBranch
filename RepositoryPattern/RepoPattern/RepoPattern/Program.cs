using System;
using Autofac;
using Autofac.Builder;

namespace RepoPattern
{
    internal class Program
    {
        private static IContainer Container { get; set; }
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PersonRepository>()
                  .As<IPersonRepository>()
                  .InstancePerLifetimeScope();

            builder.RegisterType<PersonService>()
                   .As<IPersonService>()
                   .InstancePerLifetimeScope();

            Container = builder.Build();

            var scope = Container.BeginLifetimeScope();

            var  ps = scope.Resolve<IPersonService>();

            var person = ps.GetPerson(1);

            Console.WriteLine(person.FirstName);
            Console.ReadKey(true);
        }
    }
}