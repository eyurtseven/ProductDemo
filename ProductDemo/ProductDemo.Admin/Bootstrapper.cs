﻿using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Core.Repository;
using ProductDemo.Data.DataContext;

namespace ProductDemo.Admin
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            BuildAutofacContainer();
        }

        private static void BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().WithParameter("context", new ProductDemoContext());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}