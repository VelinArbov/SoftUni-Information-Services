using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MVCFramework
{
    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);

        void ConfugreServices();
    }
}
