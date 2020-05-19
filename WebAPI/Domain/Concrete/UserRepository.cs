using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityLib.Exceptions;
using UtilityLib.Helpers;
using UtilityLib.Models.User;
using UtilityLib.Resources;
using WebAPI.Domain.Abstract;

namespace WebAPI.Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        RondeliceEntities context;

        public UserRepository(RondeliceEntities _context)
        {
            context = _context;
        }

        public UserModel LogIn(string username, string password)
        {
            UserModel model = null;

            var decodedPass = CommonMethods.Base64Decode(password);
            var user = context.user.Where(u => u.username.CompareTo(username) == 0).FirstOrDefault();

            if (user != null)
            {
                if (String.Compare(user.username, username, false) != 0 && String.Compare(CommonMethods.Base64Decode(user.password), password) != 0)
                    throw new UserCredentialsException(ExceptionsRes.res_01);

                model = new UserModel();
                model.Email = user.email;
                model.FirstName = user.first_name;
                model.LastName = user.last_name;
                model.UserId = user.user_id;
                model.Username = user.username;
            }
            else
                throw new UserCredentialsException(ExceptionsRes.res_01);

            return model;
        }
    }
}