using System;
using System.Collections.Generic;
using System.Text;

namespace SystemChecker
{
    public class ConsolasGUI
    {
        static ConsoleColor backgroundColor;
        static ConsoleColor foregroundColor;

        /// <summary>
        /// Hard refresh whole console gui
        /// </summary>
        public static void Refresh()
        {
            Console.Clear();
            Program.UnrefreshableGUI();
        }

        /// <summary>
        /// Set gui style for the application program
        /// </summary>
        /// <param name="style"></param>
        public static void SetGUIStyle(int style)
        {           
            if (style == 1)
            {
                ConsolasGUI.SetBackground(ConsoleColor.Black);
                ConsolasGUI.SetForeground(ConsoleColor.White);
            }
            else if (style == 2)
            {
                ConsolasGUI.SetBackground(ConsoleColor.DarkBlue);
                ConsolasGUI.SetForeground(ConsoleColor.White);
            }
            else if (style == 3)
            {
                ConsolasGUI.SetBackground(ConsoleColor.DarkCyan);
                ConsolasGUI.SetForeground(ConsoleColor.White);
            }
            //TODO: Add more styles
        }

        /// <summary>
        /// Set the background of the console to some color
        /// </summary>
        /// <param name="color"></param>
        public static void SetBackground(ConsoleColor color)
        {
            backgroundColor = color;
            Console.BackgroundColor = backgroundColor;
            ConsolasGUI.Refresh();
        }

        /// <summary>
        /// Change the foreground (text, inputFields, Checkboxes, etc to some color)
        /// </summary>
        /// <param name="color"></param>
        public static void SetForeground(ConsoleColor color)
        {
            foregroundColor = color;
            Console.ForegroundColor = foregroundColor;
            ConsolasGUI.Refresh();
        }

        public static void Space(int space)
        {
            for (int i = 0; i < space; i++) Console.Write("\n");
        }

        /// <summary>
        /// Basic text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void Text(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = foregroundColor;
        }

        /// <summary>
        /// Basic text (Default foreground color)
        /// </summary>
        /// <param name="text"></param>
        public static void Text(string text)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
        }

        /// <summary>
        /// The InputField will return text that you have written in the console
        /// </summary>
        /// <param name="description"></param>
        public static string InputField(string description)
        {
            Console.Write(description);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input =  Console.ReadLine();
            Console.ForegroundColor = foregroundColor;

            return input;
        }

        /// <summary>
        /// The InputField will return text that you have written in the console (No description)
        /// </summary>
        public static string InputField()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ForegroundColor = foregroundColor;

            return input;
        }

        /// <summary>
        /// An infinite timer to stop the program from closing
        /// </summary>
        public static void WaitInf()
        {
            while (true) { }
        }

        /// <summary>
        /// Wait until a button is pressed (best to use for stopping the program from closing)
        /// </summary>
        public static void WaitInput()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Wait for some time (ms)
        /// </summary>
        public static void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        ///// <summary>
        ///// The checkbox will return either true or false acording to your input (answerIndex: (1)Yes/No, (2)On/Off, (3)True/False)
        ///// </summary>
        ///// <param name="description"></param>
        ///// <param name="answerIndex"></param>
        //public static bool Checkbox(string description, int answerIndex)
        //{
        //    bool isSelected = false;
        //    bool value = false;

        //    Console.Write(description);

        //    while (!isSelected)
        //    {
        //        if (Console.Read() == 32) //Space
        //        {
        //            if (value == true)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                if (answerIndex == 1) Console.Write("No");
        //                else if (answerIndex == 2) Console.Write("Off");
        //                else if (answerIndex == 3) Console.Write("False");
        //                Console.ForegroundColor = ConsoleColor.White;
        //                value = false;
        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                if (answerIndex == 1) Console.Write("Yes");
        //                else if (answerIndex == 2) Console.Write("On");
        //                else if (answerIndex == 3) Console.Write("True");
        //                Console.ForegroundColor = ConsoleColor.White;
        //                value = true;
        //            }

        //        }
        //        else if (Console.Read() == 13) //Enter
        //        {
        //            isSelected = false;
        //        }
        //    }

        //    return value;
        //}
    }
}
