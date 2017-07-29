using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using SimpleShoppingList.DataAccess;
using SimpleShoppingList.IDataAccess;
using System.Web.Mvc;
using SimpleShoppingList.DataProvider;

namespace SimpleShoppingList
{
    public class IocConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterType<ShoppingListRepository>().As<IShoppingListRepository>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.RegisterType<ShoppingListContext>().InstancePerLifetimeScope().PropertiesAutowired();

            IContainer container = builder.Build();
            AutofacDependencyResolver controllerResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(controllerResolver);
            
        }
    }
}