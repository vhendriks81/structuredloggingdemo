namespace DemoApi
{
    using DemoApi.Services;
    using DemoApi.Tasks;
    using Destructurama;
    using Hellang.Middleware.ProblemDetails;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Setup Serilog
            Log.Logger = new LoggerConfiguration()
                .Destructure.UsingAttributes()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq("http://seq:5341")
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application specific dependency injection
            services.AddSingleton<ITaskRunner, TaskRunner>();
            services.AddTransient<DemoTask>();
            services.AddScoped<IDemoService, DemoService>();

            // Add serilog logging
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add swagger documentation.
            services.AddSwaggerDocument();

            // Add problem details nuget, making sure that every error response is standardized.
            services.AddProblemDetails();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            // Initialize problem details nuget, making sure that every error response is standardized.
            app.UseProblemDetails();


            // Add swagger documentation.
            app.UseSwagger();
            app.UseSwaggerUi3();
            app.UseMvc();

            // Just for demo purposes a quick and dirty task runner.
            var taskRunner = app.ApplicationServices.GetRequiredService<ITaskRunner>();
            taskRunner.Run();
        }
    }
}
