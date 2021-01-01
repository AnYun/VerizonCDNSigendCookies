using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerizonCDNSigendCookies
{
    public static class DateTimeExtensions
    {
        public static int FromEpoch(this DateTime expirationTime)
        {
            TimeSpan t = expirationTime - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }
    }
}
