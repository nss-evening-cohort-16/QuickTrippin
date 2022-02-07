using QuickTrippin.Enums;

namespace QuickTrippin.Views
{
    public class MainMenuView : ViewBase
    {
        public MainMenuView(AppView appView) : base(appView, "Main Menu")
        {
            _errorMessage = "";
            _menuChoice = (int)MainMenuOption.MainMenu;
        }

        private string _errorMessage;
        private int _menuChoice;

        public string MenuGraphic
        {
            get => @$"
{CreateViewHeader()}

1. Enter District Sales
2. Generate District Report
3. Add New Employee
4. Add Store
5. Add District
6. Exit

{_errorMessage}
Choose an option (1,2,3...): ";
        }

        public void Show()
        {
            Console.Clear();
            Console.Write(MenuGraphic);
            PromptForMenuChoice();
        }

        private void PromptForMenuChoice()
        {
            var input = Console.ReadKey().KeyChar.ToString();

            _errorMessage = ValidMenuChoice(input) ? "" : "Invalid Menu Option....";
            AppView.ShowView((MainMenuOption)_menuChoice);
        }

        private bool ValidMenuChoice(string input)
        {
            //must be an int
            if (!int.TryParse(input, out _menuChoice)) { return false; }

            //must be a number from 1 to highestMenuOption
            int highestMenuOption = Enum.GetValues(typeof(MainMenuOption)).GetUpperBound(0);
            if (_menuChoice < 1 || _menuChoice > highestMenuOption) { return false; }

            return true;
        }
    }
}
