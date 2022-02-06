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

        public District GetById(int id) => _districts.FirstOrDefault(d => d.Id == id);
    }
}
