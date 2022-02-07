using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTrippin.Data.Repositories;

namespace QuickTrippin.Data
{
    public class DataManager
    {
        public DataManager()
        {
            _districtRepository = new DistrictRepository();
        }

        private DistrictRepository _districtRepository;

        public DistrictRepository Districts
        {
            get => _districtRepository;
        }


    }
}
