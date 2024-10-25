using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Handle_Response;
using Store.Service.Services.CachService;
using Store.Service.Services.Products;
using Store.Service.Services.Products.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));

            services.AddSingleton<ICachService , CachServices>();

            services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                    .Where(model => model.Value?.Errors.Count > 0)
                    .SelectMany(model => model.Value?.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                    var errorResponce = new ValidationErrorResponse
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(errorResponce);
                };
            }
            );


            return services;
        }


    }
}
