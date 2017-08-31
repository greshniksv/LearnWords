using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using LearnWords.Models;

namespace LearnWords.Authentication
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string login, string password);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}