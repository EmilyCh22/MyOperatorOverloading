using System;
namespace Lesson9_MyOperatorOverloading
{
    public class CalorieCount
    {
        public string? FoodName { get; set; }
        public string? ServingSize { get; set; }
        public double Servings { get; set; } = 0;
        public double Calories { get; set; }

        public static CalorieCount operator ++(CalorieCount servings)
        {
            servings.Servings += 0.5;
            return servings;
        }
        public static CalorieCount operator *(CalorieCount food, CalorieCount servings)
        {
            food.Calories *= servings.Servings;
            food.Calories = Math.Round(food.Calories, 1);
            return food;
        }
        public static bool operator <(CalorieCount food, CalorieCount food2)
        {
            bool result = false;
            if (food.Calories < food2.Calories)
            {
                result = true;
            }
            return result;
        }
        public static bool operator >(CalorieCount food, CalorieCount food2)
        {
            bool result = false;
            if (food.Calories > food2.Calories)
            {
                result = true;
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CalorieCount chickenAlfredo = new CalorieCount
            {
                FoodName = "Chicken Alfredo",
                ServingSize = "2 cups",
                Calories = 600,
            };
            CalorieCount macAndCheese = new CalorieCount
            {
                FoodName = "Mac and Cheese",
                ServingSize = "1 cup",
                Calories = 500,
            };

            CalorieCount newFood = new CalorieCount
            {
                FoodName = InputValidString("Enter the name of your food: "),
                ServingSize = InputValidString("Enter the serving size: "),
                Calories = InputValidDouble("Enter the amount of calories (per serving): "),
                Servings = InputValidDouble("Enter how many servings you are having: ")
            };

            Console.WriteLine("\nThe first two foods will be set to 1.5 servings!");
            for (int i = 0; i < 3; i++)
            {
                chickenAlfredo++;
                macAndCheese++;
            }

            List<CalorieCount> foods = new List<CalorieCount>
            { chickenAlfredo, macAndCheese, newFood };

            foreach (var food in foods)
            {
                Console.WriteLine("\nFood Name: " + food.FoodName);
                Console.WriteLine("Serving Size: " + food.ServingSize);
                Console.WriteLine("Servings: " + food.Servings);
                var totalCal = food * food;
                Console.WriteLine("Total Calories: " + totalCal.Calories); // Usage of overloaded binary operator
            }

            Console.Write($"\nIs Chicken Alfredo more caloric than {newFood.FoodName}?  ");
            if (chickenAlfredo > newFood) // Usage of overloaded comparison operator
            { Console.Write("Yes!"); }
            else if (chickenAlfredo < newFood)
            { Console.Write("No!"); }
            else { Console.Write("They are the same!"); }

            Console.Write($"\nIs Mac and Cheese more caloric than {newFood.FoodName}?  ");
            if (macAndCheese > newFood)
            { Console.Write("Yes!"); }
            else if (macAndCheese < newFood)
            { Console.Write("No!"); }
            else { Console.Write("They are the same!"); }

            Console.WriteLine("");
        }

        public static string InputValidString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("No blank strings allowed. Please try again.");
                    continue;
                }
            }
        }
        public static double InputValidDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double doubleInput))
                {
                    return doubleInput;
                }
                else
                {
                    Console.WriteLine("Please input a number.");
                    continue;
                }
            }
        }

    }
}
