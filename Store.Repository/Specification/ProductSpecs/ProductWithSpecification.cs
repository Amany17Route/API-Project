using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithSpecification : BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpecification specs) :
                  base(prod =>
                      (!specs.BrandId.HasValue || prod.BrandId == specs.BrandId.Value) &&
                      (!specs.TypeId.HasValue || prod.TypeId == specs.BrandId.Value)
                  )
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrederBy(x => x.Name);

            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);

            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "PriceAsc":
                        AddOrederBy(x => x.Price);
                        break;
                    case "PriceDesc":
                        AddOrederByDecsending(x => x.Price);
                        break;
                    default:
                        AddOrederBy(x => x.Name);
                        break;

                }
            }


        }

        public ProductWithSpecification(int? id) : base(prod => prod.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
        }

    }
}
