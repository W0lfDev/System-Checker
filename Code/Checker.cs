using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SystemChecker
{
    public class Checker
    {
        public static string name;
        public static int systemArch;
        public static int minRam;
        public static int minCpu;
        public static int minStorage;
        public static int style;
        public static bool isLocked;

        public static bool hasPassed = true;

        public static async Task LockChecker()
        {
            string[] data =
            {
                name,
                systemArch.ToString(),
                minRam.ToString(),
                minCpu.ToString(),
                minStorage.ToString(),
                style.ToString(),
                isLocked.ToString()
            };

            File.WriteAllLines("checkerconf.txt", data);
        }

        public static async Task ReadData()
        {
            string[] data = File.ReadAllLines("checkerconf.txt");

            name = data[0];
            systemArch = int.Parse(data[1]);
            minRam = int.Parse(data[2]);
            minCpu = int.Parse(data[3]);
            minStorage = int.Parse(data[4]);
            style = int.Parse(data[5]);
            isLocked = bool.Parse(data[6]);
        }

        public static async void GUI()
        {
            int cpu = Environment.ProcessorCount;
            double ram = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory * 0.000001;
            DriveInfo drive = new DriveInfo("C");
            double storage = drive.TotalFreeSpace * 0.000001;

            ConsolasGUI.Space(1);

            if (systemArch == 1)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    ConsolasGUI.Text("System architecure: 64bit");
                    ConsolasGUI.Text("Passed", ConsoleColor.Green);
                    ConsolasGUI.Wait(250);
                }
                else
                {
                    ConsolasGUI.Text("System architecure: 32bit");
                    ConsolasGUI.Text("Failed", ConsoleColor.Red);
                    ConsolasGUI.Text("Application does not support 32bit systems");
                    ConsolasGUI.Wait(1500);
                    hasPassed = false;
                    return;
                }
            }
            else
            {
                ConsolasGUI.Text("Checking system architecture...");
                ConsolasGUI.Wait(250);
                ConsolasGUI.Refresh();
            }

            if (minRam <= ram)
            {
                ConsolasGUI.Text("System ram ammount: " + ram);
                ConsolasGUI.Text("Passed", ConsoleColor.Green);
                ConsolasGUI.Wait(250);
            }
            else
            {
                ConsolasGUI.Text("System ram ammount: " + ram);
                ConsolasGUI.Text("Failed", ConsoleColor.Red);
                ConsolasGUI.Text("Application does not support systems with " + ram + " MB ram or less");
                ConsolasGUI.Wait(1500);
                hasPassed = false;
                return;
            }

            if (minCpu <= cpu)
            {
                ConsolasGUI.Text("System cpu cores count: " + cpu);
                ConsolasGUI.Text("Passed", ConsoleColor.Green);
                ConsolasGUI.Wait(250);
            }
            else
            {
                ConsolasGUI.Text("System cpu cores count: " + cpu);
                ConsolasGUI.Text("Failed", ConsoleColor.Red);
                ConsolasGUI.Text("Application does not support systems with " + cpu + " cores or less");
                ConsolasGUI.Wait(1500);
                hasPassed = false;
                return;
            }

            if (minStorage <= storage)
            {
                ConsolasGUI.Text("System available storage: " + storage + " MB");
                ConsolasGUI.Text("Passed", ConsoleColor.Green);
                ConsolasGUI.Wait(250);
                await StartApp();
                return;
            }
            else
            {
                ConsolasGUI.Text("System available storage: " + storage + " MB");
                ConsolasGUI.Text("Failed", ConsoleColor.Red);
                ConsolasGUI.Text("Not enough storage is available");
                ConsolasGUI.Wait(1500);
                hasPassed = false;
                return;
            }
        }
        static async Task StartApp()
        {
            if (hasPassed)
            {
                ConsolasGUI.Refresh();
                ConsolasGUI.Space(1);
                ConsolasGUI.Text("Starting application...");

                Process.Start(name);
            }
        }
    }
}
