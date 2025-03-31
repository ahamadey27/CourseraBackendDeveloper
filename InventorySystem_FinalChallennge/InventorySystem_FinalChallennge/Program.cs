using System.Linq;

class InventoryManager
{
    static List<string[]> productNamePrice = new List<string[]>();
    static List<int> productInventory = new List<int>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to Cinco's Inventory Manager System.");
            Console.WriteLine("1. Add Product and Price");
            Console.WriteLine("2. Add Inventory");
            Console.WriteLine("3. Manage Inventory");
            Console.WriteLine("4. View All Prodcut Info ");
            Console.WriteLine("5. Exit Program");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProductAndPrice();
                    break;

                case "2":
                    AddInventory();
                    break;

                case "3":
                    ManageInventory();
                    break;

                case "4":
                    ViewInventory();
                    break;

                case "5":
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddProductAndPrice()
    {
        Console.WriteLine("Enter Product:");
        string product = Console.ReadLine();
        Console.WriteLine("Enter Price of product:");
        string input = Console.ReadLine();
        decimal price;

        while (!decimal.TryParse(input, out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal value for the price:");
            input = Console.ReadLine();
        }

        productNamePrice.Add(new string[] { product, price.ToString() });
        productInventory.Add(0); // Initialize inventory to 0 for the new product
        Console.WriteLine("Information added to inventory");
    }

    static void AddInventory()
    {
        Console.WriteLine("Enter product name:");
        string productName = Console.ReadLine();
        int productIndex = productNamePrice.FindIndex(p => p[0].Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (productIndex != -1)
        {
            Console.WriteLine("Enter amount of product in inventory:");
            int inventory = Convert.ToInt32(Console.ReadLine());
            productInventory[productIndex] += inventory;
            Console.WriteLine("Amount added to product's inventory");
        }
        else
        {
            Console.WriteLine("Product not found in the system.");
        }
    }

    static void ManageInventory()
    {
        while (true)
        {
            Console.WriteLine("Please enter product name and we'll see if it's in our system:");
            string productName = Console.ReadLine();

            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Invalid input. Please enter a valid product name.");
                continue;
            }

            int productIndex = productNamePrice.FindIndex(p => p[0].Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productIndex != -1)
            {
                Console.WriteLine($"{productName} found in the system.");
                Console.WriteLine($"Product Inventory: {productInventory[productIndex]}");
                Console.WriteLine($"Enter the new inventory for the product: {productName}");

                int newInventory;
                while (!int.TryParse(Console.ReadLine(), out newInventory))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value for the inventory:");
                }

                productInventory[productIndex] = newInventory;
                Console.WriteLine($"Inventory of {newInventory} set for {productName}.");
                break;
            }
            else
            {
                Console.WriteLine("Product not found. Would you like to try again or exit to the main menu?");
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Exit to Main Menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Replace this with a method that takes me back to the ManageInventory method");
                        continue;

                    case "2":
                        break;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }

                    
            }
        }
    }

    static void ViewInventory()
    {
        for (int i = 0; i < productNamePrice.Count; i++)
        {
            Console.WriteLine($"Product: {productNamePrice[i][0]} || Price: {productNamePrice[i][1]} || Inventory: {productInventory[i]}");
        }
    }
}
