using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace page_framework
{
    public static class WatinExtensions
    {
        public static bool HasCssClass(this WatiN.Core.Element element, string cssClassName)
        {
            if (element.ClassName == null) return false;
            return element.ClassName.Split(' ').Contains(cssClassName);
        }

        public static void TypeFast(this WatiN.Core.TextField textField, string text)
        {
            textField.SetAttributeValue("value", text);
            textField.FireEvent("onChange");
            textField.FireEvent("onBlur");
        }
    }
}

