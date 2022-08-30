using System;
using System.Collections.Generic;
using System.Text;

namespace SystemChecker
{
    public class Editor
    {
        public static async void GUI()
        {
            ConsolasGUI.Space(1);
            string help = ConsolasGUI.InputField("Do you need help (Yes/No): ");
            if (help == "Yes" || help == "yes")
            {
                ConsolasGUI.Text($"Openning help page...");

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "http://google.com",
                    UseShellExecute = true
                });

                ConsolasGUI.Wait(250);
            }

            ConsolasGUI.Refresh();

            ConsolasGUI.Space(1);
            string changeStyle = ConsolasGUI.InputField("Do you want to change default gui style (Yes/No): ");
            if (changeStyle == "Yes" || changeStyle == "yes")
            {
                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);

                ConsolasGUI.Text("Set gui style: ");
                ConsolasGUI.Text("(1) Black    (2) Blue    (3) Cyan");

                ConsolasGUI.Space(1);
                Checker.style = int.Parse(ConsolasGUI.InputField());

                if (Checker.style == 1) ConsolasGUI.SetGUIStyle(1);
                else if (Checker.style == 2) ConsolasGUI.SetGUIStyle(2);
                else if (Checker.style == 3) ConsolasGUI.SetGUIStyle(3);

                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);
                ConsolasGUI.Text("Gui style is set");
                ConsolasGUI.Wait(500);
            }

            ConsolasGUI.Refresh();
            ConsolasGUI.Space(1);

            Checker.name = ConsolasGUI.InputField("Executable Name: ");
            ConsolasGUI.Text($"Setting name...");
            ConsolasGUI.Wait(250);
            ConsolasGUI.Space(2);


            ConsolasGUI.Text($"(1) 64bit    (2) 32bit");
            Checker.systemArch = int.Parse(ConsolasGUI.InputField($"Minimum system architecture: "));
            ConsolasGUI.Text($"Setting architecture...");
            ConsolasGUI.Wait(250);
            ConsolasGUI.Space(2);

            Checker.minRam = int.Parse(ConsolasGUI.InputField("Minimum ammount of ram for application: "));
            ConsolasGUI.Text($"Setting min ram...");
            ConsolasGUI.Wait(250);
            ConsolasGUI.Space(2);

            Checker.minCpu = int.Parse(ConsolasGUI.InputField("Minimum ammount of proccesor cores count for application: "));
            ConsolasGUI.Text($"Setting min cpu cores count...");
            ConsolasGUI.Wait(250);
            ConsolasGUI.Space(2);

            Checker.minStorage = int.Parse(ConsolasGUI.InputField("Minimum ammount of storage that the application needs (mb): "));
            ConsolasGUI.Text($"Setting min storage...");
            ConsolasGUI.Wait(250);

            ConsolasGUI.Refresh();
            ConsolasGUI.Space(1);

            ConsolasGUI.Text("Setup is finished.");
            ConsolasGUI.Space(1);

            ConsolasGUI.Text("Executable name: " + Checker.name);
            ConsolasGUI.Text("System architecture: " + Checker.systemArch);
            ConsolasGUI.Text("Minimum ram ammount: " + Checker.minRam + " MB");
            ConsolasGUI.Text("Minimum cpu cores count: " + Checker.minCpu);
            ConsolasGUI.Text("Minimum storage space: " + Checker.minStorage + " MB");
            ConsolasGUI.Space(1);

            ConsolasGUI.Text("Do you want to lock the checker?");
            ConsolasGUI.Text("(Yes)     (No)");
            ConsolasGUI.Space(1);
            string lockStatus = ConsolasGUI.InputField();

            ConsolasGUI.Space(1);

            if (lockStatus == "Yes" || lockStatus == "yes")
            {
                ConsolasGUI.Text("The editor CAN NOT be unlocked afterwards! You will not be able to make changes!");
                ConsolasGUI.Text("Are your sure you want to procceed?");
                ConsolasGUI.Text("(Yes)     (No)");
                ConsolasGUI.Space(1);
                lockStatus = ConsolasGUI.InputField();

                if (lockStatus == "Yes" || lockStatus == "yes")
                {
                    ConsolasGUI.Refresh();
                    ConsolasGUI.Space(1);

                    ConsolasGUI.Text($"Locking...");
                    Checker.isLocked = true;

                    await Checker.LockChecker();

                    ConsolasGUI.Wait(1000);
                    ConsolasGUI.Text($"System checker is locked");

                    ConsolasGUI.Wait(500);
                    ConsolasGUI.Space(2);
                    ConsolasGUI.Text($"Closing editor in 3 seconds");
                    ConsolasGUI.Wait(3000);
                    Environment.Exit(0);
                }
                else
                {
                    ConsolasGUI.Refresh();
                    ConsolasGUI.Space(1);
                    ConsolasGUI.Wait(500);
                    ConsolasGUI.Text($"System checker was not locked");

                    ConsolasGUI.Space(2);
                    ConsolasGUI.Text($"Closing editor in 3 seconds");
                    ConsolasGUI.Wait(3000);
                    Environment.Exit(0);
                }
            }
            else
            {
                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);
                ConsolasGUI.Wait(500);
                ConsolasGUI.Text($"System checker was not locked");

                ConsolasGUI.Space(2);
                ConsolasGUI.Text($"Closing editor in 3 seconds");
                ConsolasGUI.Wait(3000);
                Environment.Exit(0);
            }
        }
    }
}
