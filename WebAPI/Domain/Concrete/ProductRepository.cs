using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityLib.Models.Product;
using UtilityLib.Models.User;
using WebAPI.Domain.Abstract;

namespace WebAPI.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private RondeliceEntities context;

        public ProductRepository(RondeliceEntities _context)
        {
            context = _context;
        }

        public List<ProductModel> GetProducts()
        {
            var query = from p in context.product
                        select new ProductModel
                        {
                            Code = p.code,
                            EdgeLength = p.edge_length.HasValue ? p.edge_length.Value : 0,
                            EdgeWidth = p.edge_width.HasValue ? p.edge_width.Value : 0,
                            ElapsedTime = p.elapsed_time.Value,
                            InsertDate = p.ts.HasValue ? p.ts.Value : DateTime.MinValue,
                            ItemsSum = p.items_sum.HasValue ? p.items_sum.Value : 0,
                            Length = p.length.HasValue ? p.length.Value : 0,
                            MinDistanceItem = p.min_distance_item.HasValue ? p.min_distance_item.Value : 0,
                            Name = p.name,
                            ProductId = p.product_id,
                            Radius = p.radius.HasValue ? p.radius.Value : 0,
                            Width = p.width.HasValue ? p.width.Value : 0,
                            User = (from u in context.user
                                    where u.user_id == p.ts_user_id.Value
                                    select new UserModel
                                    {
                                        UserId = u.user_id,
                                        FirstName = u.first_name,
                                        LastName = u.last_name
                                    }).FirstOrDefault(),
                        };

            return query.OrderByDescending(o=>o.ProductId).ToList();
        }

        public int SaveProduct(ProductModel model)
        {
            product p = context.product.Where(prod => prod.product_id == model.ProductId).FirstOrDefault() ?? new product();

            p.code = model.Code;
            p.edge_length = model.EdgeLength;
            p.edge_width = model.EdgeWidth;
            p.elapsed_time = model.ElapsedTime;
            p.items_sum = model.ItemsSum;
            p.length = model.Length;
            p.min_distance_item = model.MinDistanceItem;
            p.name = model.Name;
            p.product_id = model.ProductId;
            p.radius = model.Radius;
            p.width = model.Width;
            p.ts_user_id = model.UserId;
            p.ts = model.InsertDate;

            if (p.product_id == 0)
            {
                p.code = DateTime.Now.Year.ToString() + "/" + (context.product.Count() + 1).ToString();
                p.ts = DateTime.Now;
                context.product.Add(p);
            }

            context.SaveChanges();

            return p.product_id;
        }
    }
}