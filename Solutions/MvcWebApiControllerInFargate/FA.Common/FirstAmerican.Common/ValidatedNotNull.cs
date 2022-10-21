using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstAmerican.Common
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    class ValidatedNotNullAttribute : Attribute
    {
    }
}
