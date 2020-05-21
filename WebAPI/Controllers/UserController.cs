using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityLib.Exceptions;
using UtilityLib.Helpers;
using UtilityLib.Models;
using UtilityLib.Models.User;
using WebAPI.Domain.Abstract;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository userRepo;

        public UserController(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        [HttpGet]
        public IHttpActionResult LogIn(string username, string password)
        {
            ResponseAPIModel<UserModel> response = new ResponseAPIModel<UserModel>();

            try
            {
                response.Content = userRepo.LogIn(username, password);

                response.IsRequestSuccesful = true;
                response.ValidationError = "";
            }
            catch (UserCredentialsException uex)
            {
                response.IsRequestSuccesful = false;
                response.ValidationError = ExceptionValidationHelper.GetExceptionSource(uex);
                CommonMethods.LogThis(response.ValidationError);
                return Json(response);
            }
            catch (Exception ex)
            {
                response.IsRequestSuccesful = false;
                response.ValidationError = ExceptionValidationHelper.GetExceptionSource(ex);
                CommonMethods.LogThis(response.ValidationError);
                return Json(response);
            }

            return Json(response);
        }
    }
}
