using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTrippin.Data;
using QuickTrippin.Data.Repositories;
using QuickTrippin.Models;

namespace QuickTrippin.Views
{
    public class AddDistrictView : ViewBase
    {
        public AddDistrictView(AppView appView) : base(appView, "Add District")
        {
            _districts = DataManager.Districts;
            _errorMsg = String.Empty;
        }

        private DistrictRepository _districts;
        private string _errorMsg;

        public void Show()
        {
            GetDistrictNumber();
        }

        private void GetDistrictNumber()
        {
            DisplayHeader();
            //PromptForDistrictNumber();
        }

        private void DisplayHeader()
        {
            throw new NotImplementedException();
        }

        private bool ValidNewDistrict(District district)
        {
            _errorMsg = string.Empty;

            //id must number greater than 0
            if (district.Id == null || district.Id < 1)
            {
                _errorMsg += $"Invalid ID, please use an integer up to 4 digits long.";
            }

            //Id must be unique
            if (_districts.GetById(district.Id) != null)
            {
                _errorMsg += $"District ID '{district.Id}' is already in use, ID must be unique.";
            }

            //name must be unique
            if (_districts.GetByName(district.Name) != null)
            {
                _errorMsg += $"District Name {district.Name} is already in use, Name must be unique.";
            }

            //if there is no error message then it was successful
            return String.IsNullOrWhiteSpace(_errorMsg);
        }
    }
}
