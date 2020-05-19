using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityLib.Helpers;
using UtilityLib.Models;
using UtilityLib.Models.Product;
using UtilityLib.Resources;
using WebAPI.Domain.Abstract;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository productRepo;

        public ProductController(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }


        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            ResponseAPIModel<List<ProductModel>> response = new ResponseAPIModel<List<ProductModel>>();

            try
            {
                response.Content = productRepo.GetProducts();

                response.IsRequestSuccesful = true;
                response.ValidationError = "";
            }
            catch (Exception ex)
            {
                response.IsRequestSuccesful = false;
                response.ValidationError = ExceptionValidationHelper.GetExceptionSource(ex);
                return Json(response);
            }

            return Json(response);
        }

        [HttpPost]
        public IHttpActionResult SaveProduct([FromBody]object productData)
        {
            ResponseAPIModel<ProductModel> model = null;
            try
            {
                model = JsonConvert.DeserializeObject<ResponseAPIModel<ProductModel>>(productData.ToString());

                if (model.Content != null)
                {
                    productRepo.SaveProduct(model.Content);

                    model.IsRequestSuccesful = true;
                }
                else
                {
                    model.IsRequestSuccesful = false;
                    model.ValidationError = ExceptionsRes.res_02;
                }
            }
            catch (Exception ex)
            {
                model.IsRequestSuccesful = false;
                model.ValidationError = ExceptionValidationHelper.GetExceptionSource(ex);
                return Json(model);
            }

            return Json(model);
        }
    }
}
