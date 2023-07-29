using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SystemChecker
{
    class Program
    {
        static string version = "202208r";

        public static void UnrefreshableGUI() //GUI that should not be refreshed
        {
            if (Checker.isLocked)
            {
                ConsolasGUI.Text($"System Checker v{version}");
                ConsolasGUI.Text("-------------------------");
            }
            else
            {
                ConsolasGUI.Text($"System Checker v{version} - EDITOR");
                ConsolasGUI.Text("----------------------------------");
            }
        }

        private static async Task InitChecker()
        {
            await Checker.ReadData();

            if (Checker.style == 1) ConsolasGUI.SetGUIStyle(1);
            else if (Checker.style == 2) ConsolasGUI.SetGUIStyle(2);
            else if (Checker.style == 3) ConsolasGUI.SetGUIStyle(3);
            else ConsolasGUI.SetGUIStyle(2); //Default

            if (Checker.isLocked == true) Checker.GUI();
            else Editor.GUI();
        }

        static void Main(string[] args)
        {
            InitChecker();

            if (!Checker.hasPassed)
            {
                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);
                ConsolasGUI.Text("Your system does not meet the minimum requirements to run this application!", ConsoleColor.Red);

                ConsolasGUI.Wait(5000);
            }
            else
            {
                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);
                ConsolasGUI.Text("All checks passed.", ConsoleColor.Green);
                ConsolasGUI.Wait(1000);
            }
        }

    }
}
