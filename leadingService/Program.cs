using System;
using System.IO;
using System.Threading;
using Grpc.Core;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Leading.Services;
using Grpc.Reflection.V1Alpha;
using Grpc.Reflection;

namespace leadingService
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        public static IConfigurationRoot Configuration { get; set; }
        public static string ConnectionString = "";      
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables();

            Configuration = builder.Build();

            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();

            ILogger logger = loggerFactory.CreateLogger<Program>();
        
            var port = int.Parse(Configuration["service:port"]);
            ConnectionString = Configuration["ConnectionStrings:LeadingDB"];

            var warehouseService = new WarehouseServiceImpl(new WarehouseRepositoryImpl(), loggerFactory.CreateLogger<WarehouseServiceImpl>());
            var regionService = new RegionServiceImpl(new RegionRepositoryImpl(), new AddressRepositoryImpl(), loggerFactory.CreateLogger<RegionServiceImpl>());

            var refImpl = new ReflectionServiceImpl(
                ServerReflection.Descriptor, WarehouseService.Descriptor, RegionService.Descriptor);

            Server server = new Server
            {
                Services = { WarehouseService.BindService(warehouseService),
                             RegionService.BindService(regionService),
                             ServerReflection.BindService(refImpl)},
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            server.Start();

            logger.LogInformation("Warehouse gRPC Service Listening on Port " + port);
            logger.LogInformation("Region gRPC Service Listening on Port " + port);

            mre.WaitOne();
        }
    }
}
