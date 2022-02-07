using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTrippin.Data.Repositories;

namespace QuickTrippin.Data
{
    public static class DataManager
    {
        private static DistrictRepository _districtRepository;

        public static DistrictRepository Districts
        {
            get => _districtRepository;
        }


    }
}
