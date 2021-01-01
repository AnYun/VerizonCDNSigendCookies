using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerizonCDNSigendCookies
{
    public static class HttpResponseExtension
    {
        /// <summary>
        /// 設定 Token 時間
        /// </summary>
        /// <param name="response"></param>
        /// <param name="token"></param>
        public static void SetTokenCookies(this HttpResponse response, string token, bool? isRemove = null)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                //SameSite = SameSiteMode.None,
                Domain = ".domain.com",
                Path = "/eBooks/"
            };

            if (isRemove == true)
            {
                cookieOptions.Expires = DateTime.UtcNow.AddYears(-1);
            }

            response.Cookies.Append("token", token, cookieOptions);
        }
    }
}
