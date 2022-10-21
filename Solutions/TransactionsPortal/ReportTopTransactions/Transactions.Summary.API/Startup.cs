using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Service;

namespace Transactions.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();

            _ = services.AddScoped<ITransactionsService, TransactionsServiceManagerInMemory>();

            _ = services.AddCors(options =>
              {
                  options.AddDefaultPolicy(
                      builder =>
                      {
                          //builder.WithOrigins("http://localhost", "http://w-mj05e66e", "http://firstam-tmct-transactionportal.s3-website-us-west-2.amazonaws.com", "http://firstam-csse-transactionportal.s3-website-us-west-2.amazonaws.com/");
                          _ = builder.WithOrigins("*");
                      });

              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable IDE0060 // Remove unused parameter
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            _ = app.UseCors();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
