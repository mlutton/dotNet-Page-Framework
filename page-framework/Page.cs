using System;
using NUnit.Framework;
using WatiN.Core;

namespace page_framework
{
    public static class Page
    {
        public static T On<T>() where T : IPage, new()
        {
            var page = new T();
            Assert.IsTrue(page.IsOn(), FormatIncorrectPageMessage(typeof(T)));
            return page;
        }

        public static T Visit<T>() where T : IPage, new()
        {
            var page = new T();
            page.Visit();
            Assert.IsTrue(page.IsOn(), FormatIncorrectPageMessage(typeof(T)));
            return page;
        }

        public static bool IsOn<T>() where T : IPage, new()
        {
            var page = new T();
            return page.IsOn();
        }

        private static string FormatIncorrectPageMessage(Type t)
        {
            var pageName = t.Name;
            return String.Format("You are not on the {0} page", pageName);
        }
    }
}

