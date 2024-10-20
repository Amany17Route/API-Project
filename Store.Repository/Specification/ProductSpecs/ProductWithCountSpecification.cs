using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithCountSpecification : BaseSpecification<Product>
    {

        public ProductWithCountSpecification(ProductSpecification specs) :
        base(prod => (!specs.BrandId.HasValue || prod.BrandId == specs.BrandId.Value) &&
                     (!specs.TypeId.HasValue || prod.TypeId == specs.BrandId.Value) &&
                      (string.IsNullOrEmpty(specs.Search) || prod.Name.Trim().ToLower().Contains(specs.Search))
        )
        {

        }

    }
}
