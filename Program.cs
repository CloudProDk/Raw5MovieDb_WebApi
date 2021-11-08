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
            CreateHostBuilder(args).Build().Run();


            //trying to get the ADO / ENTITYFRAMWORK TO WORK
             var connectionstring = "host=rawdata.ruc.dk;db=Raw5;uid=postgres;pwd=Tristan!";
             GetAllUsersFunctionFromDatabase(connectionstring);



            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });




        }

        public static void GetAllUsersFunctionFromDatabase(string connectionstring)
        {
            var ctx = new MovieDbContext(connectionstring);
            ctx.users.FromSqlInterpolated($"SELECT * FROM get_all_users()");
        }
    }
}
