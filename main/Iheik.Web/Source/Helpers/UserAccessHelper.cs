using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iheik.Helpers
{

    /// <summary>
    /// Basically this class exposes the User Credential properties to UI pages, 
    /// so the Membership object is not to exposed directly (cleaner).
    /// </summary>
    public static class UserAccessHelper
    {

        /// <summary>
        /// Property for checking whether a user is logged on
        /// </summary>
        static public bool UserLoggedOn
        {
            get
            {
                return IsCurrentUserLoggedOn();
            }
        }

        /// <summary>
        /// Checks if a user has an active session
        /// </summary>
        /// <returns>Boolean - True if current user is logged in.</returns>
        private static bool IsCurrentUserLoggedOn()
        {
            bool userLoggedOn = false;

            userLoggedOn = HttpContext.Current.User.Identity.IsAuthenticated;

            return userLoggedOn;
        }

        /// <summary>
        /// Property for checking whether a user is an administrator 
        /// </summary>
        static public bool UserIsAdmin
        {
            get
            {
                return IsCurrentUserAdmin();
            }
        }

        /// <summary>
        /// Checks if a user is an administrator
        /// </summary>
        /// <returns>Boolean - True if current user is admin.</returns>
        private static bool IsCurrentUserAdmin()
        {
            bool userIsAdmin = false;

            userIsAdmin = HttpContext.Current.User.IsInRole("GetRoleNamefromConfig");

            return userIsAdmin;
        }

        /// <summary>
        /// Property for checking whether a user is a system administrator 
        /// </summary>
        static public bool UserIsSysAdmin
        {
            get
            {
                return IsCurrentUserSysAdmin();
            }
        }

        /// <summary>
        /// Checks if a user is a system administrator
        /// </summary>
        /// <returns>Boolean - True if current user is sys admin.</returns>
        private static bool IsCurrentUserSysAdmin()
        {
            bool userIsAdmin = false;

            userIsAdmin = HttpContext.Current.User.IsInRole("GetRoleNamefromConfig");

            return userIsAdmin;
        }

        /// <summary>
        /// Exposes name of the user.
        /// </summary>
        static public string UserName
        {
            get
            {
                return GetUserName();
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>Logged in User Name.</returns>
        private static string GetUserName()
        {
            string userName = string.Empty;

            if (IsCurrentUserLoggedOn())
            {
                userName = HttpContext.Current.User.Identity.Name;
            }

            return userName;
        }

        /// <summary>
        /// Gets a value indicating whether to show detailed error.
        /// </summary>
        static public bool ShowDetailedError
        {
            get
            {
                return DetailedErrorAreOn();
            }
        }

        /// <summary>
        /// Determines whether to Show Detailed Errors.
        /// </summary>
        /// <returns>Boolean - True for showing a detail error stack on page.</returns>
        private static bool DetailedErrorAreOn()
        {
            bool showDetailedError = false;

            showDetailedError = false; //"GetSettingFromConfig";

            return showDetailedError;
        }

    }
}