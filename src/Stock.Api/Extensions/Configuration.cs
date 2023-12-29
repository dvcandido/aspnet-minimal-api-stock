using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Stock.Api.Endpoints;
using Stock.Api.Models;
using Microsoft.OpenApi.Models;
using FluentValidation;

namespace Stock.Api.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<StockContext>(options => 
            {
                options.UseSqlServer(builder.Configuration["StockDb:ConnectionString"]);
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            
            });

            builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
            builder.Services.AddScoped<IValidator<StockInput>, StockInputValidator>();
            builder.Services.AddScoped<IValidator<StockOutput>, StockOutputValidator>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Stock API",
                    Description = "API for product management, stock input, and output, d1"

                });
            });

        }

        public static void RegisterMiddlewares(this WebApplication app)
        {

        }

        public static void RegisterEndpoints(this WebApplication app)
        {
            app.RegisterProductsEndpoint();
            app.RegisterStockInputEndPoint();
            app.RegisterStockOutputEndPoint();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
                options.RoutePrefix = string.Empty;
            });
        }
        
    }
}