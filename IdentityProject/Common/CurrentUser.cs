using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Common
{
    public class CurrentUser
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static CurrentUser Get
        {
            get
            {
                var user = HttpContext.Current.User;
                if (user == null)
                {
                    return null;
                }
                else if(string.IsNullOrEmpty(user.Identity.GetUserId()))
                {
                    return null;
                }
                var Juser = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.UserData).Value;
                return JsonConvert.DeserializeObject<CurrentUser>(Juser);
            }

        }
    }
}
