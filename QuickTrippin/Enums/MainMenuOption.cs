using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTrippin.Enums
{
    //the int values here should match the number of the menu option

    /// <summary>
    /// An Enum to track the different main menu options,
    /// mapping directly to the numbered options on the menu
    /// </summary>
    public enum MainMenuOption
    {
        MainMenu = 0,
        EnterDistrictSales=1,
        GenerateDistrictReport=2,
        AddNewEmployee=3,
        AddStore=4,
        AddDistrict=5,
        Exit=6,
    }
}
