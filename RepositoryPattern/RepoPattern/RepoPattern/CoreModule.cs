using Autofac;

namespace RepoPattern
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PersonRepository>()
                   .As<IPersonRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<PersonService>()
                   .As<IPersonService>()
                   .InstancePerLifetimeScope();
        }
    }
}