using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RegisterAndLogin_LTQL.Models
{
    public class Encrytion
    {
        [Obsolete]
        public string PasswordEncrytion(string pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }
    }
}