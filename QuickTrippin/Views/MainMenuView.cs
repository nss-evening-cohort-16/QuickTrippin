using QuickTrippin.Enums;

namespace QuickTrippin.Views
{
    public class MainMenuView : ViewBase
    {
        public MainMenuView(AppView appView) : base(appView, "Main Menu")
        {
            _menuChoice = (int)MainMenuOption.MainMenu;
        }

        private int _menuChoice;

        public string MenuGraphic
        {
            get => @$"
1. Enter District Sales
2. Generate District Report
3. Add New Employee
4. Add Store
5. Add District
6. Exit

{ErrorMsg}";
        }

        private void DisplayMenu()
        {
            Console.WriteLine(MenuGraphic);
        }
        private void PromptForMenuChoice()
        {
            Console.Write("Choose an option(1, 2, 3...): ");
            var input = Console.ReadKey().KeyChar.ToString();

            if (ValidMenuInput(input))
            {
                AppView.ShowView((MainMenuOption)_menuChoice);
            }
            else
            {
                Load();
            }
        }
        public void Load()
        {
            DisplayHeader();
            DisplayMenu();
            PromptForMenuChoice();
        }
        private bool ValidMenuInput(string input)
        {
            ErrorMsg = String.Empty;

            //must be an int
            if (!int.TryParse(input, out _menuChoice))
            {
                ErrorMsg = "Please enter a number. ";
                return false;
            }

            //must be a number from 1 to highestMenuOption
            int highestMenuOption = Enum.GetValues(typeof(MainMenuOption)).GetUpperBound(0);
            if (_menuChoice < 1 || _menuChoice > highestMenuOption)
            {
                ErrorMsg = $"Please enter a number from 1 to {highestMenuOption}.";
                return false;
            }

            return true;
        }
    }
}