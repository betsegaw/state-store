using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace state_store
{
    public class Program
    {
        public static void Main(string[] args)
        {

            YamlDotNet.Serialization.Deserializer x = new YamlDotNet.Serialization.Deserializer();

            var l = x.Deserialize<StateStoreConfiguration>(File.ReadAllText(@"C:\Users\betse\Source\Repos\state-store\src\state-store\SampleConfigurations\SampleConfiguration.yaml"));
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
