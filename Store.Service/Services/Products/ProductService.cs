using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllBrandsAsync()
        {

            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();

            IReadOnlyList<BraandTypeDetailsDto> MappedBrands = brands.Select(x => new BraandTypeDetailsDto

            {

                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Name = x.Name
            }).ToList();
            return MappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {

            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();

            var MappedProducts = products.Select(x => new ProductDto

            {

                Id = x.Id,
                Name = x.Name,
                BarndName = x.Brand.Name,
                TypeName = x.Type.Name,
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                PicturUrl = x.ImageUrl

            }).ToList();

            return MappedProducts;
        }



        public async Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllTypesAsync()
        {

            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();

            var mappedTypes = types.Select(x => new BraandTypeDetailsDto
            {


                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            }).ToList();

            return mappedTypes;
        }


        public async Task<ProductDto> GetProductBuIdAsync(int? id)
        {

            if (id is null)

                throw new Exception("Id IS NULL");

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);

            if (product is null)
                throw new Exception("Product not Found");

            var MappedProduct = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                BarndName = product.Brand.Name,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                PicturUrl = product.ImageUrl,
                Price = product.Price,
                TypeName = product.Type.Name
            };
            return MappedProduct;
        }
    }
}


