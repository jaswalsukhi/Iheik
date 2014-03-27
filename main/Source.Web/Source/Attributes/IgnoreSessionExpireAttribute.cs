﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iheik.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class IgnoreSessionExpireAttribute : Attribute
    {
    }
}