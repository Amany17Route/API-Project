using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public interface IProductService
    {

        Task<ProductDto> GetProductBuIdAsync(int? id);


        Task<IReadOnlyList<ProductDto>> GetAllProductsAsync(ProductSpecification specs);

        Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllBrandsAsync();

        Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllTypesAsync();

    }
}
