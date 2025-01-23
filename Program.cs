using FoodBankLibrary; // Reference to the FoodBankLibrary project

namespace FoodBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to hold all the food items in our inventory. Pulling from other code
            List<FoodItem> foodInventory = new List<FoodItem>();

            // Keep the program running until we choose to exit.
            for (; ; )
            {
                // Show the menu options to the user.
                Console.WriteLine(" "); // Extra line for readability
                Console.WriteLine("Food Bank Inventory System:");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                string input = Console.ReadLine();

                // user input
                switch (input)
                {
                    case "1":
                        // If they chose to add a food item, call the function to do that.
                        AddFoodItem(foodInventory);
                        break;
                    case "2":
                        // If they chose to delete a food item, call the function to do that.
                        DeleteFoodItem(foodInventory);
                        break;
                    case "3":
                        // If they chose to print the list, call the function to do that.
                        PrintFoodItems(foodInventory);
                        break;
                    case "4":
                        // If they chose to exit, say goodbye and stop the program.
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        // If they entered an invalid choice, tell them to try again.
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        // This function adds a new food item to the inventory list.
        static void AddFoodItem(List<FoodItem> inventory)
        {
            // Get the name of the food from the user.
            Console.Write("Enter food name: ");
            string name = Console.ReadLine();

            // Get the category of the food from the user.
            Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine();

            // Keep asking for the quantity until the user enters a valid number.
            int quantity;
            do
            {
                Console.Write("Enter quantity (positive number): ");
            } while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0);

            // Keep asking for the expiration date until the user enters a valid date.
            DateTime expirationDate;
            do
            {
                Console.Write("Enter expiration date (MM/DD/YYYY): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out expirationDate));

            // Create a new food item and add it to the inventory list.
            inventory.Add(new FoodItem(name, category, quantity, expirationDate));
            Console.WriteLine("Food item added successfully!");
        }

        // This function deletes a food item from the inventory list.
        static void DeleteFoodItem(List<FoodItem> inventory)
        {
            // Check if the inventory is empty.
            if (inventory.Count == 0)
            {
                Console.WriteLine("The inventory is empty. Nothing to delete.");
                return; // Stop the function if there's nothing to delete.
            }

            // Print the list of food items so the user knows what to delete.
            PrintFoodItems(inventory);

            // Keep asking for the item number until the user enters a valid number.
            int index;
            do
            {
                Console.Write("Enter the number of the item to delete (1 to {0}): ", inventory.Count);
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > inventory.Count);

            // Remove the item from the inventory list.
            inventory.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully!");
        }

        // This function prints all the food items in the inventory.
        static void PrintFoodItems(List<FoodItem> inventory)
        {
            // Check if the inventory is empty.
            if (inventory.Count == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return; // Stop the function if there's nothing to print.
            }

            Console.WriteLine("Current Food Items:");

            // Loop through each food item in the list.
            for (int i = 0; i < inventory.Count; i++)
            {
                // Print the information for each food item.
                Console.WriteLine($"Item {i + 1}:");
                Console.WriteLine($"  Name: {inventory[i].Name}");
                Console.WriteLine($"  Category: {inventory[i].Category}");
                Console.WriteLine($"  Quantity: {inventory[i].Quantity}");
                Console.WriteLine($"  Expiration Date: {inventory[i].ExpirationDate.ToShortDateString()}");
                Console.WriteLine(); // Add an empty line for better readability.
            }
        }

    }
}
