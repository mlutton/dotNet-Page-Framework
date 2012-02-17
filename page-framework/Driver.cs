using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;

namespace page_framework
{
    public static class Driver
    {
        private static Browser _browser = null;

        public static Browser GetInstance()
        {
            if (_browser != null) return _browser;

            _browser = new IE();

            return _browser;
        }

        public static void Close()
        {
            if (_browser == null) return;

            _browser.Close();
            _browser.Dispose();
            _browser = null;
        }

    }
}

