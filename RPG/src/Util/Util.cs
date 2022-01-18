using System;

namespace RPG {

    public class Util {

        public static void WriteRed (string text1) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{text1}");
            Console.ForegroundColor = ConsoleDefaultForegroudColor();
        }

        public static void WriteBlue (string text1) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{text1}");
            Console.ForegroundColor = ConsoleDefaultForegroudColor();
        }

        public static void WriteGreyAndRed (string text1, string text2) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text2);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteGreyAndGreen (string text1, string text2) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text2);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteHeroText (Hero hero, string text1) {
            ConsoleColor foregroundColor = ConsoleDefaultForegroudColor();
            ConsoleColor backgroundColor = ConsoleDefaultBackgroudColor();

            Console.Write($"\n   {hero.GetName()} - ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(text1);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine();
        }

        public static ConsoleColor ConsoleDefaultForegroudColor () {
            return Console.ForegroundColor;
        }

        public static ConsoleColor ConsoleDefaultBackgroudColor () {
            return Console.BackgroundColor;
        }  

    }

}