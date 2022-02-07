using QuickTrippin.Models;

namespace QuickTrippin.Data.Repositories
{
    public class DistrictRepository
    {
        private List<District> _districts;

        /// <summary>
        /// A method for retrieving all Districts from the databse
        /// </summary>
        /// <returns>A List<District> containing all the Districts in the database</District></returns>
        public List<District> GetAll() => _districts;

        /// <summary>
        /// A method for retrieving a single District by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single District with an ID matching the id parameter</returns>
        public District GetById(int id) => _districts?.FirstOrDefault(d => d.Id == id);

        /// <summary>
        /// Method to Insert a District into the database
        /// </summary>
        /// <param name="district">The new District instance to be Inserted</param>
        /// <returns>A tuple containing a boolean indicating if the Insert was successful,
        /// and a string that is empty if successful or an explanation if a failure.</returns>
        public (bool success, string errorMsg) TryInsert(District district)
        {
            if (!ValidNewDistrict(district, out string errorMessage))
            {
                return ResondWithFailure(errorMessage);
            }
            else
            {
                _districts.Add(district);
                return RespondWithSuccess();
            }
        }

        private (bool, string) RespondWithSuccess()
        {
            return (true, "");
        }

        private (bool, string) ResondWithFailure(string message)
        {
            return (false, message);
        }

        private bool ValidNewDistrict(District newDistrict, out string errorMessage)
        {
            //id must number greater than 0
            if (newDistrict.Id == null || newDistrict.Id < 1)
            {
                errorMessage = "Invalid ID";
                return false;
            }

            //Id must be unique
            if (_districts.Where(d => d.Id == newDistrict.Id).Any())
            {
                errorMessage = $"District ID '{newDistrict.Id}' is already in use.";
                return false;
            }

            //name must be unique
            if (_districts.Where(d => d.Name == newDistrict.Name).Any())
            {
                errorMessage = $"District Name {newDistrict.Name} is already in use.";
                return false;
            }

            //no errors, return success
            errorMessage = "";
            return true;
        }

    }
}
