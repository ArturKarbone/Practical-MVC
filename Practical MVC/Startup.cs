using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication5.Infrastructure;
using WebApplication5.Services;

namespace WebApplication5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<BoardService>();
            services.AddDbContext<BoardContext>(options=>options.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyBoards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<string> logger, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole().AddDebug();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Trace);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    Debug.WriteLine("Hit entry point");
            //    logger.LogInformation("Hit entry point from logger");
            //    await context.Response.WriteAsync("Hello, World!");
            //});
        }
    }
}
