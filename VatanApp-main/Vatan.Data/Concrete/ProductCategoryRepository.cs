using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vatan.Data.Abstract;
using Vatan.Entity;

namespace Vatan.Data.Concrete
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, VatanDbContext>, IProductCategoryRepository
    {
    }
}
