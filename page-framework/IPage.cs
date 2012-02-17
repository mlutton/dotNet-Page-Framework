using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace page_framework
{
    public interface IPage
    {
        void Visit();
        bool IsOn();
    }
}

