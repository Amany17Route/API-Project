using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory LoggerFactory)
        {


            try
            {

                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {

                    var brandData = File.ReadAllText(" .. /Store.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    if (brands is not null)
                    {

                        await context.ProductBrands.AddRangeAsync(brands);
                    }
                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {

                    var typeData = File.ReadAllText(" .. /Store.Repository/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    if (types is not null)
                    {

                        await context.ProductTypes.AddRangeAsync(types);
                    }
                }

                if (context.Products != null && !context.Products.Any())
                {
                    var productData = File.ReadAllText(" .. /Store.Repository/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    if (products is not null)
                    {
                        await context.Products.AddRangeAsync(products);
                    }
                }
                await context.SaveChangesAsync();

            }

            catch (Exception ex) {

                var logger = LoggerFactory.CreateLogger<StoreDbContext>();

                logger.LogError(ex.Message);
            }
        }
    }
}
