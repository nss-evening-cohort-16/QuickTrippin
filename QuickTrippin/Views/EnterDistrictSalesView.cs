using QuickTrippin.Data.Repositories;
using QuickTrippin.Models;

namespace QuickTrippin.Views
{
    public class EnterDistrictSalesView : ViewBase
    {
        public EnterDistrictSalesView(AppView appView,
            DistrictRepository districtRepo) : base(appView, "Enter District Sales")
        {
            _districtRepo = districtRepo;
        }

        private string _bannerText = @"
**************************
|  Enter District Sales  |
**************************";
        private District _district;
        private DistrictRepository _districtRepo;
        
        public string DistrictList
        {
            get
            {
                return $@"
Districts:
 {_districtRepo.GetAll().OrderBy(d => d.Id).Select(d => d.ListName)}";
            }
        }
        public string TextForIdPrompt
        {
            get
            {
                return $@"
{_bannerText}

{DistrictList}

Enter sales for District #";
            }
        }

        private void DetermineDistrict()
        {
            bool validInput = false;

            while (!validInput)
            {
                PromptForDistrictId();
                if (ValidDistrictId()) { PromptForDistrictSales(); }
            }
        }
        public void Show()
        {
            DetermineDistrict();
        }
        private void PromptForDistrictId()
        {
            throw new NotImplementedException();
        }
        private void PromptForDistrictSales()
        {
            Console.WriteLine(TextForIdPrompt);
        }
        private bool ValidDistrictId()
        {
            throw new NotImplementedException();
        }



    }
}
