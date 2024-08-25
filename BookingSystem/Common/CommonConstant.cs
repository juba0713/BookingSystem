// Author: Julius.B
// Date: August 24, 2024
// Description: Common Constant
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingSystem.Common
{
    public class CommonConstant
    {
        public const string HTML_LOGIN_PATH = "~/Views/Login.cshtml";
        public const string HTML_REGISTER_PATH = "~/Views/Register.cshtml";
        public const string HTML_DASHBOARD_PATH = "~/Views/Dashboard.cshtml";

        /*Admin*/
        public const string HTML_ADMIN_DASHBOARD_PATH = "~/Views/Admin/Dashboard.cshtml";
        public const string HTML_ADMIN_USERS_PATH = "~/Views/Admin/Users.cshtml";
        public const string HTML_ADMIN_USERS_CREATE_PATH = "~/Views/Admin/Users/Create.cshtml";

        /*Super*/
        public const string HTML_SUPER_DASHBOARD_PATH = "~/Views/System/Dashboard.cshtml";
        public const string HTML_SUPER_USERS_PATH = "~/Views/System/Users.cshtml";
        public const string HTML_SUPER_USERS_CREATE_PATH = "~/Views/System/Users/Create.cshtml";

        /*Role*/
        public const string ROLE_SUPER = "SUPER";
        public const string ROLE_ADMIN = "ADMIN";
        public const string ROLE_USER = "USER";
    }
}
