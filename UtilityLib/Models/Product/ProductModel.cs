using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib.Models.User;

namespace UtilityLib.Models.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal EdgeLength { get; set; }
        public decimal EdgeWidth { get; set; }
        public decimal MinDistanceItem { get; set; }
        public decimal Radius { get; set; }
        public int ItemsSum { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public DateTime InsertDate { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
