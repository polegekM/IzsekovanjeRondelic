using Newtonsoft.Json;
using SlugsLib;
using SlugsLib.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                UtilityLib.Helpers.CommonMethods.LogThis(response.ValidationError);
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
                UtilityLib.Helpers.CommonMethods.LogThis(model.ValidationError);
                return Json(model);
            }

            return Json(model);
        }

        [HttpGet]
        public IHttpActionResult GetSlugsSum(decimal length, decimal width, decimal radius, decimal edgeLength, decimal edgeWidth, decimal minDistanceItem)
        {
            ResponseAPIModel<ProductModel> response = new ResponseAPIModel<ProductModel>();
            try
            {
                int userID = UtilityLib.Helpers.CommonMethods.ParseInt(Request.Headers.Where(h => h.Key == Enums.RequestHeader.UserToken.ToString()).FirstOrDefault().Value.FirstOrDefault());
                if (userID > 0)
                {
                    CalculateSlugs calcSlugs = new CalculateSlugs(length, width, radius, edgeLength, edgeWidth, minDistanceItem);

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    ProductModel model = new ProductModel();
                    model.ProductId = 0;
                    model.UserId = userID;
                    model.Name = "Izračun rondelic dne, " + DateTime.Now.ToString("dd. MMMM yyyy");
                    model.EdgeLength = edgeLength;
                    model.EdgeWidth = edgeWidth;
                    model.Length = length;
                    model.MinDistanceItem = minDistanceItem;
                    model.Radius = radius;
                    model.Width = width;

                    model.ItemsSum = calcSlugs.CalculateSum();
                    timer.Stop();
                    model.ElapsedTime = timer.Elapsed;

                    model.ProductId = productRepo.SaveProduct(model);
                    response.Content = model;
                    response.IsRequestSuccesful = true;
                    response.ValidationError = "";
                }
            }
            catch (ArgumentValidationException arg)
            {
                response.IsRequestSuccesful = false;
                response.ValidationError = ExceptionValidationHelper.GetExceptionSource(arg);
                UtilityLib.Helpers.CommonMethods.LogThis(response.ValidationError);
                return Json(response);
            }
            catch (Exception ex)
            {
                response.IsRequestSuccesful = false;
                response.ValidationError = ExceptionValidationHelper.GetExceptionSource(ex);
                UtilityLib.Helpers.CommonMethods.LogThis(response.ValidationError);
                return Json(response);
            }

            return Json(response);
        }
    }
}
