using QuickTrippin.Data.Repositories;
using QuickTrippin.Enums;
using QuickTrippin.Views;

namespace QuickTrippin
{
    /// <summary>
    /// A class to handle the view routing and to pass the data dependencies down to views for state management
    /// </summary>
    public class AppView
    {
        public AppView()
        {
            _districtRepo = new DistrictRepository();
        }

        private DistrictRepository _districtRepo;

        public void ShowView(MainMenuOption option)
        {
            switch (option)
            {
                case MainMenuOption.MainMenu:
                    var menu = new MainMenuView(this);
                    menu.Show();
                    break;

                case MainMenuOption.EnterDistrictSales:
                    var enterDistrictSalesView = new EnterDistrictSalesView(this, _districtRepo);
                    break;

                case MainMenuOption.GenerateDistrictReport:
                    DisplayComingSoonMessage("District Sales Report");
                    break;

                case MainMenuOption.AddNewEmployee:
                    DisplayComingSoonMessage("Employee Profile Creation");
                    break;

                case MainMenuOption.AddStore:
                    DisplayComingSoonMessage("Store Creation");
                    break;

                case MainMenuOption.AddDistrict:
                    DisplayComingSoonMessage("District Creation");
                    break;

                case MainMenuOption.Exit:
                    ExitAnimation();
                    break;

                default:
                    var defaultView = new MainMenuView(this);
                    defaultView.Show();
                    break;
            }
        }

        private void ExitAnimation()
        {
            List<string> textPieces = new List<string>()
            {
                Environment.NewLine,
                Environment.NewLine,
                "Exiting",
                ".",
                ".",
                ".",
                Environment.NewLine,
                "Goodbye!",
                "",
                "",
                Environment.NewLine,
                Environment.NewLine
            };

            CreateAnimatedMessage(textPieces);
        }

        private void DisplayComingSoonMessage(string optionName)
        {
            //create brief "loading" message then redirect back to main menu
            List<string> textPieces = new List<string>()
            {
                Environment.NewLine,
                Environment.NewLine,
                $"{optionName} coming soon",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
            };

            CreateAnimatedMessage(textPieces, 300);
            ShowView(MainMenuOption.MainMenu);

        }

        private void CreateAnimatedMessage(List<string> textPieces, int animationTimeout = 100)
        {
            textPieces.ForEach(piece =>
            {
                Console.Write(piece);
                Thread.Sleep(animationTimeout);
            });
        }

        public void Start()
        {
            ShowView(MainMenuOption.MainMenu);
        }
    }
}
