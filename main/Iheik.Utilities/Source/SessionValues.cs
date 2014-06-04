using System;
using System.Web;
using System.Web.SessionState;
namespace Iheik.Utilities
{
    /// <summary>
    /// Session values for easy reference
    /// </summary>
    public enum SessionValue
    {
        UserId,
        UserName,
        UserRole,
        RowsPerPage,
    }

    /// <summary>
    /// Session handling methods.
    /// </summary>
    public class SessionValues
    {

        /// <summary>
        /// Saves a session object for a Key
        /// </summary>
        /// <param name="sessionKey">Name of the session object</param>
        /// <param name="objectValue">The object value.</param>
        public static void SaveSessionValue(SessionValue sessionKey, object objectValue)
        {
            HttpContext.Current.Session[sessionKey.ToString()] = objectValue;
        }

        /// <summary>
        /// Retrieves an item from the session cache
        /// </summary>
        /// <param name="sessionKey">Name of the session object</param>
        /// <returns>Object - the item being retrieved from the session store</returns>
        public static object GetSessionValue(SessionValue sessionKey)
        {
            object retVal;
            HttpSessionState session = ((HttpSessionState)HttpContext.Current.Session);

            try
            {
                if (SessionKeyExists(sessionKey.ToString()))
                {
                    retVal = session[sessionKey.ToString()];
                }
                else
                {
                    retVal = null;
                }
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// Saves a value to the session cache
        /// </summary>
        /// <param name="sessionKey">Name of the session object</param>
        /// <param name="sessionObject">Item being saved in the session</param>
        public static void SetSessionValue(SessionValue sessionKey, Object sessionObject)
        {
            HttpSessionState session = HttpContext.Current.Session;

            try
            {
                if (SessionKeyExists(sessionKey.ToString()))
                {
                    session.Remove(sessionKey.ToString());
                }

                session.Add(sessionKey.ToString(), sessionObject);
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        /// <summary>
        /// Removes an item from the session
        /// </summary>
        /// <param name="sessionKey">Name of the session object</param>
        public static void RemoveSessionValue(SessionValue sessionKey)
        {
            HttpSessionState session = HttpContext.Current.Session;

            if (SessionKeyExists(sessionKey.ToString()))
            {
                session.Remove(sessionKey.ToString());
            }
        }

        /// <summary>
        /// Checks whether a key exists in the current session
        /// </summary>
        /// <param name="sessionKey">Session key for checking</param>
        /// <returns>Boolean</returns>
        public static bool SessionKeyExists(string sessionKey)
        {
            bool keyExists = false;
            HttpSessionState session = HttpContext.Current.Session;

            foreach (string key in session.Keys)
            {
                if (key.Equals(sessionKey, StringComparison.OrdinalIgnoreCase))
                {
                    keyExists = true;
                    break;
                }
            }

            return keyExists;
        }

        /// <summary>
        /// Checks whether a key exists in the current session
        /// </summary>
        /// <param name="sessionKey">SessionValue enum</param>
        /// <returns>Boolean - -True for the existence of the session key</returns>
        public static bool SessionKeyExists(SessionValue sessionKey)
        {
            bool keyExists = false;
            HttpSessionState session = HttpContext.Current.Session;

            foreach (string key in session.Keys)
            {
                if (key.Equals(sessionKey.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    keyExists = true;
                    break;
                }
            }

            return keyExists;
        }
    }
}
