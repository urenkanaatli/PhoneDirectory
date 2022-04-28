using DirectoryService.Insfrastructure.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryService.Application;
using DirectoryService.Insfrastructure;
using DirectoryService.Core.DomainClasses;
using DirectoryService.Application.Repositories;

namespace Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;


        private static Checkpoint _checkpoint;




        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();



            _configuration = builder.Build();



            var services = new ServiceCollection();

            services.AddApplication();
            services.AddInfrasturucture(_configuration);

            services.AddSingleton(Mock.Of<IHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "MyAPP"));

            services.AddLogging();



            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
            };

            EnsureDatabase();
        }

        private static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ContactDbContext>();

            context.Database.EnsureCreated();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }

        public static T Get<T>(object id) where T : class
        {
            using var scope = _scopeFactory.CreateScope();

            return scope.ServiceProvider.GetService<IRepository<T>>().GetById(id);


        }



        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("ContactDbConnectionString"));

        }



        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}
