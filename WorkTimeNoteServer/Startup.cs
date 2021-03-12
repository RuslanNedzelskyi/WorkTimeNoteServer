using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkTimeNoteCommon;
using WorkTimeNoteCommon.WebApi.ResponseFactory;
using WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts;
using WorkTimeNoteDataBase;
using WorkTimeNoteServices.TimeNoteServices;
using WorkTimeNoteServices.TimeNoteServices.Contracts;

namespace WorkTimeNoteServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            ConfigurationManager.SetAppSettingsProperties(Configuration);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WorkTimeNoteDbContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString(ConnectionNames.DEFAULT_CONNECTION)));

            services.AddControllers();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IResponseFactory, ResponseFactory>();

            services.AddTransient<ITimeNoteService, TimeNoteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
