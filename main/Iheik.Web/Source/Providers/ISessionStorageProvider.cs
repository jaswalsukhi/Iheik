using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iheik.Utilities;

namespace Iheik.Providers
{
    public interface ISessionStorageProvider
    {
        void RemoveValue(SessionValue key);
        T GetValue<T>(SessionValue key);
        void SetValue<T>(SessionValue key, T value);
        bool KeyExists(SessionValue key);
    }
}