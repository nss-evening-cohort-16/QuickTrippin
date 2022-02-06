using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTrippin.Enums;

namespace QuickTrippin.Views
{
    public class ViewBase
    {
        public ViewBase(AppView appView)
        {
            AppView = appView;
        }

        public AppView AppView { get; }
    }
}
