using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exceptions

class LoginFailedException : Exception
{
    public LoginFailedException()
        : base("Login Failed! Maximum attempts reached.")
    {
    }
}

class InvalidPriceException : Exception
{
    public InvalidPriceException()
        : base("Price must be greater than 0.")
    {
    }
}

class InvalidQuantityException : Exception
{
    public InvalidQuantityException()
        : base("Quantity must be greater than 0.")
    {
    }
}

class DuplicateItemException : Exception
{
    public DuplicateItemException()
        : base("Item ID already exists.")
    {
    }
}

class ItemNotFoundException : Exception
{
    public ItemNotFoundException()
        : base("Item not found.")
    {
    }
}

class InsufficientStockException : Exception
{
    public InsufficientStockException()
        : base("Insufficient Stock.")
    {
    }
}

#endregion

#region Interface

interface IBill
{
    void GenerateBill(int qty);
}

#endregion

#region Abstract Class

abstract class Product
{
    public abstract double CalculateDiscount(double amount);
}

#endregion

#region Stationery Item

class StationeryItem : Product
{
    private int itemId;
    private string itemName;
    private string category;
    private double price;
    private int quantity;
    private string brand;

    public int ItemId
    {
        get { return itemId; }
        set { itemId = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                throw new InvalidPriceException();

            price = value;
        }
    }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value < 0)
                throw new InvalidQuantityException();

            quantity = value;
        }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("ID       : " + ItemId);
        Console.WriteLine("Name     : " + ItemName);
        Console.WriteLine("Category : " + Category);
        Console.WriteLine("Brand    : " + Brand);
        Console.WriteLine("Price    : " + Price);
        Console.WriteLine("Quantity : " + Quantity);
    }

    public void UpdateQuantity(int qty)
    {
        Quantity = qty;
    }

    public override double CalculateDiscount(double amount)
    {
        return 0;
    }
}

#endregion

#region Notebook

class Notebook : StationeryItem
{
    public int Pages { get; set; }
    public string PaperType { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Pages : " + Pages);
        Console.WriteLine("Paper : " + PaperType);
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.10;
    }
}

#endregion

#region Pen

class Pen : StationeryItem
{
    public string InkColor { get; set; }
    public string PenType { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Ink Color : " + InkColor);
        Console.WriteLine("Pen Type  : " + PenType);
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.05;
    }
}

#endregion

#region Marker

class Marker : StationeryItem
{
    public bool Permanent { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Permanent : " + Permanent);
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.08;
    }
}

#endregion

#region Purchase Class

class Purchase : IBill
{
    private StationeryItem item;

    public Purchase(StationeryItem item)
    {
        this.item = item;
    }

    public void GenerateBill(int qty)
    {
        double subtotal = item.Price * qty;

        double discount = item.CalculateDiscount(subtotal);

        double afterDiscount = subtotal - discount;

        double gst = afterDiscount * 0.18;

        double total = afterDiscount + gst;

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Bill");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Item      : " + item.ItemName);
        Console.WriteLine("Price     : " + item.Price);
        Console.WriteLine("Quantity  : " + qty);
        Console.WriteLine("Discount  : " + discount);
        Console.WriteLine("GST       : " + gst);
        Console.WriteLine("Total     : " + total);
        Console.WriteLine("--------------------------------");
    }
}

#endregion

class Program
{
    static List<StationeryItem> items = new List<StationeryItem>();

    static bool Login()
    {
        int attempts = 3;

        while (attempts > 0)
        {
            Console.Write("Enter Username : ");
            string user = Console.ReadLine();

            Console.Write("Enter Password : ");
            string pass = Console.ReadLine();

            if (user == "Ritika" && pass == "ritika27")
            {
                Console.WriteLine("\nLogin Successful.");
                return true;
            }

            attempts--;

            Console.WriteLine("\nInvalid Login");

            if (attempts > 0)
                Console.WriteLine("Attempts Left : " + attempts);
        }

        throw new LoginFailedException();
    }

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

        //==========================
    // ADD ITEM
    //==========================
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

            if (items.Any(x => x.ItemId == id))
                throw new DuplicateItemException();

            item.ItemId = id;

            Console.Write("Enter Name : ");
            item.ItemName = Console.ReadLine();

            Console.Write("Enter Category : ");
            item.Category = Console.ReadLine();

            Console.Write("Enter Brand : ");
            item.Brand = Console.ReadLine();

            Console.Write("Enter Price : ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity : ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            // Child Class Details
            if (item is Notebook notebook)
            {
                Console.Write("Enter Pages : ");
                notebook.Pages = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Paper Type : ");
                notebook.PaperType = Console.ReadLine();
            }
            else if (item is Pen pen)
            {
                Console.Write("Enter Ink Color : ");
                pen.InkColor = Console.ReadLine();

                Console.Write("Enter Pen Type : ");
                pen.PenType = Console.ReadLine();
            }
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
            Console.WriteLine(ex.Message);
        }
    }

   
    // DISPLAY ALL ITEMS
   
    static void DisplayItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("\nNo Items Found.");
            return;
        }

        Console.WriteLine();

        foreach (StationeryItem item in items)
        {
            item.DisplayDetails();
            Console.WriteLine();
        }
    }

    
    // SEARCH ITEM
 
    static void SearchItem()
    {
        try
        {
            Console.WriteLine("\nSearch By");
            Console.WriteLine("1. Item Id");
            Console.WriteLine("2. Item Name");

            Console.Write("Choice : ");
            int ch = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = null;

            if (ch == 1)
            {
                Console.Write("Enter Item Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                item = items.FirstOrDefault(x => x.ItemId == id);
            }
            else if (ch == 2)
            {
                Console.Write("Enter Item Name : ");
                string name = Console.ReadLine();

                item = items.FirstOrDefault(
                    x => x.ItemName.Equals(name,
                    StringComparison.OrdinalIgnoreCase));
            }

            if (item == null)
                throw new ItemNotFoundException();

            Console.WriteLine("\nItem Found\n");
            item.DisplayDetails();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

        
    // Update Item
    
    static void UpdateItem()
    {
        try
        {
            Console.Write("Enter Item Id to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            Console.WriteLine("\nCurrent Details:");
            item.DisplayDetails();

            Console.Write("\nEnter New Brand: ");
            item.Brand = Console.ReadLine();

            Console.Write("Enter New Price: ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter New Quantity: ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nItem Updated Successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

   
    // Delete Item
   
    static void DeleteItem()
    {
        try
        {
            Console.Write("Enter Item Id to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            Console.Write("\nDelete this item? (Y/N): ");
            char ch = Convert.ToChar(Console.ReadLine().ToUpper());

            if (ch == 'Y')
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
            Console.WriteLine(ex.Message);
        }
    }

       
    // Purchase Item
       static void PurchaseItem()
    {
        try
        {
            Console.Write("Enter Item Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            Console.Write("Enter Quantity : ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (qty > item.Quantity)
                throw new InsufficientStockException();

            item.Quantity -= qty;

            Purchase bill = new Purchase(item);
            bill.GenerateBill(qty);

            Console.WriteLine("\nPurchase Successful.");
            Console.WriteLine("Remaining Stock : " + item.Quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // View Low Stock Items
   
    static void ViewLowStock()
    {
        var lowStock = items.Where(x => x.Quantity < 5).ToList();

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

    
    // Sort Items
    
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

       
    // Main Method
 
    static void Main(string[] args)
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
                        Console.WriteLine("\nThank You!");
                        Console.WriteLine("Visit Again.");
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
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}