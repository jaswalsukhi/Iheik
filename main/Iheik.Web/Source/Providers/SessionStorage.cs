using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iheik.Utilities;
namespace Iheik.Providers
{
    public class SessionStorage : ISessionStorageProvider
    {
        public void RemoveValue(SessionValue key)
        {
            SessionValues.RemoveSessionValue(key);
        }

        public T GetValue<T>(SessionValue key)
        {
            return (T)SessionValues.GetSessionValue(key);
        }

        public void SetValue<T>(SessionValue key, T value)
        {
            SessionValues.SetSessionValue(key, value);
        }

        public bool KeyExists(SessionValue key)
        {
            return SessionValues.SessionKeyExists(key);
        }
    }
}