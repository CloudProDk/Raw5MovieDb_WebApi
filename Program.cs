using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Raw5MovieDb_WebApi.Services;
using Microsoft.EntityFrameworkCore;
namespace Raw5MovieDb_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var actorname = "tristan";
            var ds = new DataService();
            var actors = ds.GetCoActors(actorname);

            Console.WriteLine("ACTORS:");

            foreach (var actor in actors)
            {
               Console.WriteLine(actor.Primaryname);
            }

            CreateHostBuilder(args).Build().Run();

            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });




        }
    }
}
