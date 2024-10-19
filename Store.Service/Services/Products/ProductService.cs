using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecs;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllBrandsAsync()
        {

            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();

            var MappedBrands = _mapper.Map<IReadOnlyList<BraandTypeDetailsDto>>(brands);

            return MappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            var products = await _unitOfWork.Repository<Product, int>().GetAllwithSpecificationAsync(specs);
            var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);



            return MappedProducts;
        }

        public Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<BraandTypeDetailsDto>> GetAllTypesAsync()
        {

            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var mappedTypes = _mapper.Map<IReadOnlyList<BraandTypeDetailsDto>>(types);


            return mappedTypes;
        }


        public async Task<ProductDto> GetProductBuIdAsync(int? id)
        {

            if (id is null)

                throw new Exception("Id IS NULL");

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);

            if (product is null)
                throw new Exception("Product not Found");


            var MappedProduct = _mapper.Map<ProductDto>(product);

            return MappedProduct;


        }
    }
}


