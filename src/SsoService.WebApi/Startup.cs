using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using BaseUtility.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace SsoService.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            AutofacHelper.RegisterDBInstance();

        }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices_del(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddMvc();
            BaseUtility.Ioc.AutofacHelper.RegisterDBInstance();
            // Create the container builder.
            //var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            //builder.Populate(services); 

            //builder.RegisterType<Data.Orm.Dapper.SqlServerDatabase>().Named<Data.DbFactory.IDatabase>("Dapper.MSSQL");
            //builder.RegisterType<Data.Orm.EF.SqlServerDatabase>().Named<Data.DbFactory.IDatabase>("EF.MSSQL");


            //var config = new ConfigurationBuilder();
            //string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"Configs\autofac.xml");
            //config.AddJsonFile(path);//Microsoft.Extensions.Configuration.Json.dll
            //config.AddXmlFile(path);
            // Register the ConfigurationModule with Autofac.
            //var module = new ConfigurationModule(config.Build());
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(module);

            //this.ApplicationContainer = builder.Build();


            //var idatabaseList = this.ApplicationContainer.Resolve<IEnumerable<Data.DbFactory.IDatabase>>();
            //foreach(var idatabase in idatabaseList)
            //{
            //    idatabase.Select("ss");
            //}


            //Data.DbFactory.IDatabase idatabase0 = this.ApplicationContainer.ResolveNamed<Data.DbFactory.IDatabase>("IDatabase2");

            //Data.DbFactory.IDatabase idatabase2 = this.ApplicationContainer.Resolve<Data.DbFactory.IDatabase>(ResolvedParameter.ForNamed<Data.DbFactory.IDatabase>("IDatabase2"));
            //idatabase2.Select("dd");

            //this.ApplicationContainer.ResolveNamed<Data.DbFactory.IDatabase>("DapperMssql");
            //this.ApplicationContainer.ResolveNamed<Data.DbFactory.IDatabase>("EFMssql");
            //Data.DbFactory.IDatabase idatabase = this.ApplicationContainer.ResolveNamed<Data.DbFactory.IDatabase>("Dapper.MSSQL");
            //idatabase.Select("ss");

            //Data.DbFactory.IDatabase idatabase2 = this.ApplicationContainer.ResolveNamed<Data.DbFactory.IDatabase>("EF.MSSQL");
            //idatabase2.Select("ss");
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
