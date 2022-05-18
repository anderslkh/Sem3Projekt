using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DesktopConsumer.Controller;

namespace DesktopConsumer.Security {
    static class CheckTokenValidity
    {
        private static TokenController tokenController = new TokenController();
        public static async Task<string> VerifyTokenValidity(TokenState tokenState)
        {
            return await tokenController.GetToken(tokenState);
        }
    }
}
