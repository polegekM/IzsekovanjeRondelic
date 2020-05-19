using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib.Models.Product;

namespace WebAPI.Domain.Abstract
{
    public interface IProductRepository
    {
        List<ProductModel> GetProducts();
        int SaveProduct(ProductModel model);
    }
}
