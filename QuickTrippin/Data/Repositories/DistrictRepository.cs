using QuickTrippin.Models;

namespace QuickTrippin.Data.Repositories
{
    public class DistrictRepository
    {
        public DistrictRepository()
        {
            _districts = new List<District>();
        }

        private List<District> _districts;

        public List<District> GetAll() => _districts;
        public District GetById(int id) => _districts.Where(d=>d.Id == id).FirstOrDefault();
        public District GetByName(string name) => _districts.Where(d=>d.Name==name).FirstOrDefault();
        public void Insert(District validatedDistrict) => _districts.Add(validatedDistrict);

    }
}
