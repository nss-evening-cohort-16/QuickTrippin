using QuickTrippin.Data;
using QuickTrippin.Enums;
using QuickTrippin.Views;

namespace QuickTrippin
{
    /// <summary>
    /// A class to handle the view routing and to pass dependencies down to views
    /// </summary>
    public class AppView
    {
        public AppView()
        {
            _data = new DataManager();
        }

        private DataManager _data;

        private void CreateAnimatedMessage(List<string> textPieces, int animationTimeout = 100)
        {
            textPieces.ForEach(piece =>
            {
                Console.Write(piece);
                Thread.Sleep(animationTimeout);
            });
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
        private void DisplayExitAnimation()
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
        public void HandleException(string exceptionMessage)
        {
            var textPieces = new List<string>()
                {
                    Environment.NewLine,
                    "Sorry, something went wrong",
                    "",
                    "",
                    "",
                    Environment.NewLine,
                    exceptionMessage,
                    Environment.NewLine,
                    "Press enter to return to main menu..."
                };
            CreateAnimatedMessage(textPieces, 300);
            Console.ReadLine();
            ShowView(MainMenuOption.MainMenu);
        }
        public void ShowView(MainMenuOption option)
        {
            try
            {
                switch (option)
                {
                    case MainMenuOption.MainMenu:
                        var menu = new MainMenuView(this);
                        menu.Show();
                        break;

                    case MainMenuOption.EnterDistrictSales:
                        DisplayComingSoonMessage("Record District Sales");
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
                        var addDistrictView = new AddDistrictView(this);
                        addDistrictView.Show();
                        break;

                    case MainMenuOption.Exit:
                        DisplayExitAnimation();
                        break;

                    default:
                        var defaultView = new MainMenuView(this);
                        defaultView.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex.Message);
            }
        }
        public void Start()
        {
            ShowView(MainMenuOption.MainMenu);
        }
    }
}
