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
        public ViewBase(AppView appView, string headerText)
        {
            AppView = appView;
            _headerText = headerText;
        }

        private readonly string _headerText;
        private readonly string _mainBanner = @"
**********************************
|  QuickTrip Management Systems  |
**********************************";

        public AppView AppView { get; }
        public string ErrorMsg { get; set; } = String.Empty;

        private string CreateViewHeader()
        {
            int bannerWidth = _mainBanner.Split(Environment.NewLine)[1].Length;
            int titlePadding = ((bannerWidth - _headerText.Length) / 2) + _headerText.Length;

            string retVal = $@"{_mainBanner}
{_headerText.PadLeft(titlePadding)}
";
            return retVal;
        }
        public void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine(CreateViewHeader());
        }
    }
}
