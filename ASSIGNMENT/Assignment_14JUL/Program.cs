using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static List<StationeryItem> items = new List<StationeryItem>();

    // ==========================
    // LOGIN
    // ==========================
    static bool Login()
    {
        int attempts = 3;

        while (attempts > 0)
        {
            Console.Write("Enter Username : ");
            string user = Console.ReadLine() ?? "";

            Console.Write("Enter Password : ");
            string pass = Console.ReadLine() ?? "";

            if (user == "admin" && pass == "admin123")
            {
                Console.WriteLine("\nLogin Successful.");
                return true;
            }

            attempts--;

            Console.WriteLine("\nInvalid Login");

            if (attempts > 0)
            {
                Console.WriteLine("Attempts Left : " + attempts);
            }
        }

        throw new LoginFailedException();
    }

    // ==========================
    // MAIN MENU
    // ==========================
    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Stationery Store Management System");
        Console.WriteLine("------------------------------------");

        Console.WriteLine("1. Add Stationery Item");
        Console.WriteLine("2. Display All Items");
        Console.WriteLine("3. Search Item");
        Console.WriteLine("4. Update Item");
        Console.WriteLine("5. Delete Item");
        Console.WriteLine("6. Purchase Item");
        Console.WriteLine("7. View Low Stock Items");
        Console.WriteLine("8. Sort Items");
        Console.WriteLine("9. Exit");

        Console.Write("\nEnter Choice : ");
    }

    // ==========================
    // ADD ITEM
    // ==========================
    static void AddItem()
    {
        try
        {
            Console.WriteLine("\nSelect Item Type");
            Console.WriteLine("1. Notebook");
            Console.WriteLine("2. Pen");
            Console.WriteLine("3. Marker");

            Console.Write("Choice : ");

            int type = Convert.ToInt32(Console.ReadLine());

            StationeryItem item;

            switch (type)
            {
                case 1:
                    item = new Notebook();
                    break;

                case 2:
                    item = new Pen();
                    break;

                case 3:
                    item = new Marker();
                    break;

                default:
                    Console.WriteLine("Invalid Type.");
                    return;
            }

            Console.Write("Enter Item Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0)
            {
                Console.WriteLine("Item ID must be greater than 0.");
                return;
            }

            if (items.Any(x => x.ItemId == id))
            {
                throw new DuplicateItemException();
            }

            item.ItemId = id;

            Console.Write("Enter Name : ");
            item.ItemName = Console.ReadLine() ?? "";

            Console.Write("Enter Category : ");
            item.Category = Console.ReadLine() ?? "";

            Console.Write("Enter Brand : ");
            item.Brand = Console.ReadLine() ?? "";

            Console.Write("Enter Price : ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity : ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            // Notebook details
            if (item is Notebook notebook)
            {
                Console.Write("Enter Pages : ");
                notebook.Pages = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Paper Type : ");
                notebook.PaperType = Console.ReadLine() ?? "";
            }

            // Pen details
            else if (item is Pen pen)
            {
                Console.Write("Enter Ink Color : ");
                pen.InkColor = Console.ReadLine() ?? "";

                Console.Write("Enter Pen Type : ");
                pen.PenType = Console.ReadLine() ?? "";
            }

            // Marker details
            else if (item is Marker marker)
            {
                Console.Write("Permanent (true/false) : ");
                marker.Permanent = Convert.ToBoolean(Console.ReadLine());
            }

            items.Add(item);

            Console.WriteLine("\nItem Added Successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }

    // ==========================
    // DISPLAY ITEMS
    // ==========================
    static void DisplayItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("\nNo Items Found.");
            return;
        }

        Console.WriteLine("\n========== ALL ITEMS ==========");

        foreach (StationeryItem item in items)
        {
            item.DisplayDetails();
            Console.WriteLine("--------------------------------");
        }
    }

    // ==========================
    // SEARCH ITEM
    // ==========================
    static void SearchItem()
    {
        try
        {
            Console.WriteLine("\nSearch By");
            Console.WriteLine("1. Item Id");
            Console.WriteLine("2. Item Name");

            Console.Write("Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            StationeryItem? item = null;

            if (choice == 1)
            {
                Console.Write("Enter Item Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                item = items.FirstOrDefault(x => x.ItemId == id);
            }
            else if (choice == 2)
            {
                Console.Write("Enter Item Name : ");
                string name = Console.ReadLine() ?? "";

                item = items.FirstOrDefault(
                    x => x.ItemName.Equals(
                        name,
                        StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                Console.WriteLine("Invalid Choice.");
                return;
            }

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.WriteLine("\nItem Found\n");
            item.DisplayDetails();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }

    // ==========================
    // UPDATE ITEM
    // ==========================
    static void UpdateItem()
    {
        try
        {
            Console.Write("Enter Item Id to Update : ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem? item =
                items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.WriteLine("\nCurrent Details:");
            item.DisplayDetails();

            Console.Write("\nEnter New Brand : ");
            item.Brand = Console.ReadLine() ?? "";

            Console.Write("Enter New Price : ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter New Quantity : ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nItem Updated Successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }

    // ==========================
    // DELETE ITEM
    // ==========================
    static void DeleteItem()
    {
        try
        {
            Console.Write("Enter Item Id to Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem? item =
                items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.Write("\nDelete this item? (Y/N) : ");

            string input = Console.ReadLine() ?? "";

            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                items.Remove(item);

                Console.WriteLine("Item Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Delete Cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }

    // ==========================
    // PURCHASE ITEM
    // ==========================
    static void PurchaseItem()
    {
        try
        {
            Console.Write("Enter Item Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem? item =
                items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            Console.Write("Enter Quantity : ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (qty <= 0)
            {
                throw new InvalidQuantityException();
            }

            if (qty > item.Quantity)
            {
                throw new InsufficientStockException();
            }

            // Reduce stock
            item.ReduceQuantity(qty);

            // Generate bill
            Purchase bill = new Purchase(item);

            bill.GenerateBill(qty);

            Console.WriteLine("\nPurchase Successful.");
            Console.WriteLine("Remaining Stock : " + item.Quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }

    // ==========================
    // LOW STOCK
    // ==========================
    static void ViewLowStock()
    {
        var lowStock =
            items.Where(x => x.Quantity < 5).ToList();

        if (lowStock.Count == 0)
        {
            Console.WriteLine("\nNo Low Stock Items.");
            return;
        }

        Console.WriteLine("\n------ Low Stock Items ------");

        foreach (var item in lowStock)
        {
            item.DisplayDetails();
            Console.WriteLine("-----------------------------");
        }
    }

    // ==========================
    // SORT ITEMS
    // ==========================
    static void SortItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("\nNo Items Available.");
            return;
        }

        Console.WriteLine("\nSort By");
        Console.WriteLine("1. Price");
        Console.WriteLine("2. Name");
        Console.WriteLine("3. Quantity");

        Console.Write("Enter Choice : ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                items = items.OrderBy(x => x.Price).ToList();
                break;

            case 2:
                items = items.OrderBy(x => x.ItemName).ToList();
                break;

            case 3:
                items = items.OrderByDescending(x => x.Quantity).ToList();
                break;

            default:
                Console.WriteLine("Invalid Choice.");
                return;
        }

        Console.WriteLine("\nItems Sorted Successfully.\n");

        foreach (var item in items)
        {
            item.DisplayDetails();
            Console.WriteLine("--------------------------");
        }
    }

    // ==========================
    // MAIN
    // ==========================
    public static void Main(string[] args)
    {
        try
        {
            Login();

            while (true)
            {
                Menu();

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;

                    case 2:
                        DisplayItems();
                        break;

                    case 3:
                        SearchItem();
                        break;

                    case 4:
                        UpdateItem();
                        break;

                    case 5:
                        DeleteItem();
                        break;

                    case 6:
                        PurchaseItem();
                        break;

                    case 7:
                        ViewLowStock();
                        break;

                    case 8:
                        SortItems();
                        break;

                    case 9:
                        Console.WriteLine("\nThank You");
                        Console.WriteLine("Visit Again");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();

                Console.Clear();
            }
        }
        catch (LoginFailedException ex)
        {
            Console.WriteLine("\n" + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }
    }
}
