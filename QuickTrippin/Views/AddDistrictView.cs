using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTrippin.Data;
using QuickTrippin.Models;

namespace QuickTrippin.Views
{
    public class AddDistrictView : ViewBase
    {
        public AddDistrictView(AppView appView) : base(appView)
        {
            
        }

        private DataManager _data;


        public bool ValidNewDistrict(District district)
        {
            var errorMessage = string.Empty;

            //id must number greater than 0
            if (district.Id == null || district.Id < 1)
            {
                errorMessage += $"Invalid ID, please use an integer up to 4 digits long.";
            }

            //Id must be unique
            if (_data.Districts.GetById(district.Id) != null)
            {
                errorMessage += $"District ID '{district.Id}' is already in use, ID must be unique.";
            }

            //name must be unique
            if (_data.Districts.GetByName(district.Name) != null)
            {
                errorMessage += $"District Name {district.Name} is already in use, Name must be unique.";
            }

            //if there is no error message then it was successful
            return String.IsNullOrWhiteSpace(errorMessage);
        }

        public void Show()
        {

        }
    }
}
