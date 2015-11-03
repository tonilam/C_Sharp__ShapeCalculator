using System;
using System.Linq;

namespace MathShapeCalculation {
    public enum TaskOption {
        CircleCircumference, CircleArea, SquarePerimeter, SquareArea, ExitProgram
    };

    /// <summary>
    /// Author: Lam Kwok Shing (Toni)
    /// Student No.: N9516778
    /// Date: 4th November, 2015
    /// </summary>
    class ShapeCalculation {
        static void Main(string[] args) {
            TaskOption
                minMenuItem = Enum.GetValues(typeof(TaskOption)).Cast<TaskOption>().First(),
                maxMenuItem = Enum.GetValues(typeof(TaskOption)).Cast<TaskOption>().Last(),
                selectedOption = minMenuItem;
            bool
                finishedChoosingMenuOption,
                validInput;
            double userInput;

            /* Continue to ask user to choose a task to do until the user decides to end the program */
            do {
                /* Ask for user option in the main menu */
                do {
                    finishedChoosingMenuOption = false;
                    PrintMenu(selectedOption);
                    selectedOption = ListenUserInput(selectedOption, ref finishedChoosingMenuOption);
                    if (selectedOption < minMenuItem) {
                        selectedOption = minMenuItem;
                    } else if (selectedOption > maxMenuItem) {
                        selectedOption = maxMenuItem;
                    }
                } while (!finishedChoosingMenuOption);

                /* Select the equivalent action based on user choice */
                switch (selectedOption) {
                    case TaskOption.CircleCircumference:
                        do {
                            PromptCircleCircumference();
                            validInput = ReadNumber(out userInput);
                        } while (!validInput);
                        CalculateCircleCircumference(userInput);
                        break;
                    case TaskOption.CircleArea:
                        do {
                            PromptCircleArea();
                            validInput = ReadNumber(out userInput);
                        } while (!validInput);
                        CalculateCircleArea(userInput);
                        break;
                    case TaskOption.SquarePerimeter:
                        do {
                            PromptSquarePerimeter();
                            validInput = ReadNumber(out userInput);
                        } while (!validInput);
                        CalculateSquarePerimeter(userInput);
                        break;
                    case TaskOption.SquareArea:
                        do {
                            PromptSquareArea();
                            validInput = ReadNumber(out userInput);
                        } while (!validInput);
                        CalculateSquareArea(userInput);
                        break;
                    case TaskOption.ExitProgram:
                        break;
                    default:
                        break;
                }

                /* If user is not selected ending the program, then prompt for restart */
                if (selectedOption < maxMenuItem) {
                    PromptToPressAnyKey("Press any key to go back to the main menu...");
                }
            } while (selectedOption < maxMenuItem);
            
            /* Inform the user that is the end of the program */
            PromptToPressAnyKey("Program end. Press any key to close the window...");
        }

        /// <summary>
        ///    Print the main menu.
        /// </summary>
        /// <param name="selectedOption">selectedOption not null</param>
        /// <returns>the menu length</returns>
        private static int PrintMenu(TaskOption selectedOption) {
            string[] menuItemText = {
                "Circumference of a circle",
                "Area of a circle",
                "Perimeter of a square",
                "Area of a square",
                "Exit the program"
                };
            
            Console.Clear();
            Console.WriteLine("   Select a task:");
            Console.WriteLine(" {0} ", String.Empty.PadLeft(30, '-'));
            for (int index = 0; index < menuItemText.Length; index++) {
                PrintMenuItem(menuItemText[index], index == (int) selectedOption);
            }
            Console.WriteLine(" {0} ", String.Empty.PadLeft(30, '-'));
            return menuItemText.Length;
        }

        /// <summary>
        ///    Print the main menu item.
        /// </summary>
        /// <param name="itemText">itemText not null</param>
        /// <param name="isCurrentIndex">isCurrentIndex not null</param>
        /// <returns>the menu item printed on console</returns>
        private static void PrintMenuItem(string itemText, bool isCurrentIndex) {
            Console.Write("│");
            if (isCurrentIndex) {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.Write(" {0,-26} ", itemText);
            Console.ResetColor();
            Console.WriteLine("│");
        }

        /// <summary>
        ///    Listen to user input, if the key pressed is up arrow or down arrow, then change the selected option value.
        ///    If the user pressed enter, the end the current task.
        /// </summary>
        /// <param name="selectedOption">selectedOption not null</param>
        /// <param name="taskEnd">true</param>
        /// <returns>the updated select option value or change the task status</returns>
        private static TaskOption ListenUserInput(TaskOption selectedOption, ref bool finishSelect) {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key){
                case ConsoleKey.UpArrow:
                    selectedOption--;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption++;
                    break;
                case ConsoleKey.Enter:
                    finishSelect = true;
                    break;
                default:
                    break;
            }
            return selectedOption;
        }

        ///<summary>
        ///    Read the user input and parse it as a double type
        ///</summary>
        ///<param>true</param>
        ///<results>
        ///    Return success/failure of the parsing double value from input.
        ///    Store the parsed value to the given double variable.
        ///</results>
        private static bool ReadNumber(out double parseValue) {
            bool parseSuccess;
            parseSuccess = double.TryParse(Console.ReadLine(), out parseValue);
            if (!parseSuccess) {
                Console.WriteLine("It is not a valid decimal number! Please try again.");
            }
            return parseSuccess;
        }

        /// <summary>
        ///    Ask the user for the radius of the circle
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on console</results>
        private static void PromptCircleCircumference() {
            Console.WriteLine("\nWhat is the radius of the circle?");
        }

        /// <summary>
        ///    Use the given redius to calculate the circumference of the circle
        /// </summary>
        /// <param name="inputtedRadius">inputtedRadius not null</param>
        /// <returns>Print the result of circumference on console</returns>
        private static void CalculateCircleCircumference(double inputtedRadius) {
            double result = 2 * Math.PI * inputtedRadius;    // circumference of circle = 2 * Pi * r
            Console.WriteLine("\nThe circumference of a circle with radius {0:f2} is {1:f2}.", inputtedRadius, result);
        }

        /// <summary>
        ///    Ask the user for the radius of the circle
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on console</results>
        private static void PromptCircleArea() {
            Console.WriteLine("\nWhat is the radius of the circle?");
        }

        /// <summary>
        ///    Use the given redius to calculate the area of the circle
        /// </summary>
        /// <param name="inputtedRadius">inputtedRadius not null</param>
        /// <returns>Print the result of area on console</returns>
        private static void CalculateCircleArea(double inputtedRadius) {
            double result = Math.PI * Math.Pow(inputtedRadius, 2);    // Area of circle = Pi * r^2
            Console.WriteLine("\nThe area of a circle with radius {0:f2} is {1:f2}.", inputtedRadius, result);
        }

        /// <summary>
        ///    Ask the user for the side length of the circle
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on console</results>
        private static void PromptSquarePerimeter() {
            Console.WriteLine("\nWhat is the side length of the square?");
        }

        /// <summary>
        ///    Use the given redius to calculate the circumference of the circle
        /// </summary>
        /// <param name="inputtedRadius">inputtedRadius not null</param>
        /// <returns>Print the result of circumference on console</returns>
        private static void CalculateSquarePerimeter(double inputtedSideLength) {
            double result = inputtedSideLength * 4;    // Perimeter of square = 4a
            Console.WriteLine("\nThe circumference of a circle with radius {0:f2} is {1:f2}.", inputtedSideLength, result);
        }

        /// <summary>
        ///    Ask the user for the side length of the circle
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on console</results>
        private static void PromptSquareArea() {
            Console.WriteLine("\nWhat is the side length of the circle?");
        }

        /// <summary>
        ///    Use the given redius to calculate the circumference of the circle
        /// </summary>
        /// <param name="inputtedRadius">inputtedRadius not null</param>
        /// <returns>Print the result of circumference on console</returns>
        private static void CalculateSquareArea(double inputtedSideLength) {
            double result = Math.Pow(inputtedSideLength, 2);    // area of square = a^2
            Console.WriteLine("\nThe circumference of a circle with radius {0:f2} is {1:f2}.", inputtedSideLength, result);
        }
        /// <summary>
        ///    Promot the user to press any key to go to the next step.
        /// </summary>
        /// <param name="message">message not null</param>
        /// <returns>print the given message on console</returns>
        private static void PromptToPressAnyKey(string message) {
            Console.Write("\n{0}", message);
            Console.ReadKey();
        }

    }
}
