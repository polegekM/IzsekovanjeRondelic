using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib.Models.User;

namespace WebAPI.Domain.Abstract
{
    public interface IUserRepository
    {
        UserModel LogIn(string username, string password);
    }
}
