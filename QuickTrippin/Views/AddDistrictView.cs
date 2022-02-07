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
            _districtRepo = DataManager.Districts;
        }

        private DistrictRepository _districtRepo;
        private int _validatedDistrictNumber;
        private string _validatedDistrictName;

        private void DisplayExistingDistricts()
        {
            string text = "Could not find any Districts.";

            List<District> allDistricts = _districtRepo.GetAll();

            if (allDistricts?.Count > 0)
            {
                var allDistrictListNames = allDistricts?
                    .Select(d => d.ListName)?
                    .ToList();

                text = @$"Districts:
{String.Join(Environment.NewLine, allDistrictListNames)}";

                Console.WriteLine(text);
            }
        }
        private void DisplayPromptForNewNumber()
        {
            string text = $@"{ErrorMsg}
Enter New District Number: ";
            Console.Write(text);

        }
        private void DisplayPromptForNewName()
        {
            string text = $@"{ErrorMsg}
Enter Name for new District {_validatedDistrictNumber}: ";
            Console.Write(text);

        }
        private void GetDistrictName()
        {
            bool validName = false;

            while (!validName)
            {
                DisplayHeader();
                DisplayExistingDistricts();
                DisplayPromptForNewName();
                var input = Console.ReadLine()?.Trim();
                validName = ValidNewDistrictName(input);
            }

            ErrorMsg = String.Empty;
        }
        private void GetDistrictNumber()
        {
            bool validNumber = false;

            while (!validNumber)
            {
                DisplayHeader();
                DisplayExistingDistricts();
                DisplayPromptForNewNumber();
                var input = Console.ReadLine();
                validNumber = ValidNewDistrictNumber(input);
            }

            ErrorMsg = String.Empty;
        }
        public void Load()
        {
            GetDistrictNumber();
            GetDistrictName();
            SaveNewDistrict();
            DetermineIfRepeating();
        }

        private void DetermineIfRepeating()
        {
            bool validInput = false;
            string input = String.Empty;

            while (!validInput)
            {
                DisplayHeader();
                DisplayExistingDistricts();
                DisplayRepeatPrompt();
                input = Console.ReadKey().KeyChar.ToString().ToUpper();
                validInput = (input == "Y" || input == "N");
            }

            if (input == "Y")
            {
                Load();
            }
            else
            {
                AppView.ReturnToMainMenu();
            }

            ErrorMsg = String.Empty;
        }

        private void DisplayRepeatPrompt()
        {
            string text = $@"
Add another District?  (y/n) ";
            Console.Write(text);
        }

        private void SaveNewDistrict()
        {
            var messagePieces = new List<string>()
            {
                Environment.NewLine,
                "Saving District",
                ".",
                ".",
                ".",
                ".",
                ".",
            };
            var newDistrict = new District(_validatedDistrictNumber, _validatedDistrictName);
            AppView.DisplayAnimatedMessage(messagePieces);
            _districtRepo.Insert(newDistrict);
            Console.WriteLine("Complete!");
        }

        private bool ValidNewDistrictName(string? input)
        {
            ErrorMsg = String.Empty;

            //must provide a value
            if (String.IsNullOrWhiteSpace(input)) { return false; }

            //must be unique
            if (_districtRepo.GetByName(input) != null)
            {
                ErrorMsg = $"District Name {input} already exists, Name must be unique.";
                return false;
            }

            _validatedDistrictName = input;
            return true;

        }

        private bool ValidNewDistrictNumber(string? input)
        {
            ErrorMsg = String.Empty;

            //must provide a value
            if (String.IsNullOrWhiteSpace(input)) { return false; }

            //must be a number
            if (!int.TryParse(input, out _validatedDistrictNumber))
            {
                ErrorMsg = "Please enter an unused number from 1 to 9999.";
                return false;
            }

            //must be no more than 4 digits
            if (_validatedDistrictNumber < 1 || _validatedDistrictNumber > 9999)
            {
                ErrorMsg = "Please enter an unused number from 1 to 9999.";
                return false;
            }

            //must be unique
            if (_districtRepo.GetById(_validatedDistrictNumber) != null)
            {
                ErrorMsg = $"District ID '{input}' already exists, ID must be unique.";
                return false;
            }

            return true;

        }
        private bool ValidNewDistrict(District district)
        {
            //already validated the rules for ID and Name, just need to make sure they haven't been created in the meantime
            ErrorMsg = string.Empty;

            //Id must be unique
            if (_districtRepo.GetById(district.Id) != null)
            {
                ErrorMsg = $"District ID '{district.Id}' already exists, ID must be unique.";
                return false;
            }

            //name must be unique
            if (_districtRepo.GetByName(district.Name) != null)
            {
                ErrorMsg = $"District Name {district.Name} already exists, Name must be unique.";
                return false;
            }

            return true;
        }
    }
}
