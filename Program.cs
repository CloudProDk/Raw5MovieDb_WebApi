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
            var input1 = "a";
            int input2 = 1;
            var input3 = "c";
            var ds = new DataService();
            var actors = ds.BestMatchFunction(input1, input2, input3);

            Console.WriteLine("best mach:");

            foreach (var title in actors)
            {
                Console.WriteLine(title.Primarytitle);
            }

            CreateHostBuilder(args).Build().Run();

            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });




        }

       
    }
}
