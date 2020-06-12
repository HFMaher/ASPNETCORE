using Microsoft.AspNetCore.Http;
using ServiceLayer.Utils;
using System;

namespace ServiceLayer.CheckoutServices
{
    public class CheckoutCookie : CookieTemplate
    {
        public const string CheckoutCookieName = "EfCore-Cookie";

        public CheckoutCookie(IRequestCookieCollection cookiesIn, IResponseCookies cookiesOut = null)
            : base(CheckoutCookieName, cookiesIn, cookiesOut)
        {
        }

        protected override int ExpiresInThisManyDays => 200;    //Make this last, as it holds the user id for checking orders

    }


    
}
