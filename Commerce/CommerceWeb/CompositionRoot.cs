using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using CommerceDomain;
using CommerceWeb.Controllers;

namespace CommerceWeb
{
    public class CompositionRoot
    {
        private readonly IControllerFactory controllerFactory;

        public CompositionRoot()
        {
            this.controllerFactory = CompositionRoot.CreateControllerFactory();
        }

        public IControllerFactory ControllerFactory
        {
            get { return this.controllerFactory; }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings
                ["CommerceObjectContext"].ConnectionString;

            string productRepositoryTypeName =
                ConfigurationManager.AppSettings
                ["ProductRepositoryType"];
            var productRepositoryType =
                Type.GetType(productRepositoryTypeName, true);
            var repository =
                (ProductRepository)Activator.CreateInstance(
                productRepositoryType, connectionString);

            var controllerFactory =
                new CommerceControllerFactory(repository);

            return controllerFactory;
        }
    }

    public class CommerceControllerFactory : DefaultControllerFactory
    {
        private readonly Dictionary<string, Func<RequestContext, IController>> controllerMap;

        public CommerceControllerFactory(ProductRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            this.controllerMap = new Dictionary<string, Func<RequestContext, IController>>();
            this.controllerMap["Account"] = ctx => new AccountController();
            this.controllerMap["Home"] = ctx => new HomeController(repository);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return this.controllerMap[controllerName](requestContext);
        }

        public override void ReleaseController(IController controller)
        {
        }
    }
}