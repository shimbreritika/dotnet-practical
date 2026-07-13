using System;
using System.Collections.Generic;
using System.Linq;

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

class CartItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        // CUSTOMER REGISTRATION

        Customer customer = new Customer();

        Console.WriteLine("------ Customer Registration ------");

        Console.Write("Enter Customer ID : ");
        customer.CustomerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name : ");
        customer.Name = Console.ReadLine();

        Console.Write("Enter Email : ");
        customer.Email = Console.ReadLine();

        Console.Write("Enter Password : ");
        customer.Password = Console.ReadLine();

        Console.WriteLine("\nRegistration Successful");

        // LOGIN
       
        bool login = false;

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("\nLogin");

            Console.Write("Enter Email : ");
            string email = Console.ReadLine();

            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            if (email == customer.Email && password == customer.Password)
            {
                Console.WriteLine("\nWelcome " + customer.Name);
                login = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }

        if (!login)
        {
            Console.WriteLine("\nAccount Locked");
            return;
        }

        // PRODUCT ENTRY
        
        List<Product> products = new List<Product>();

        Console.Write("\nHow many products do you want to add? ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Product p = new Product();

            Console.WriteLine("\nEnter Product " + (i + 1));

            Console.Write("Product ID : ");
            p.ProductId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Product Name : ");
            p.ProductName = Console.ReadLine();

            Console.Write("Price : ");
            p.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stock : ");
            p.Stock = Convert.ToInt32(Console.ReadLine());

            products.Add(p);
        }

        // DISPLAY PRODUCTS

        Console.WriteLine("\n------ Product List ------");

        foreach (Product p in products)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Product ID : " + p.ProductId);
            Console.WriteLine("Product Name : " + p.ProductName);
            Console.WriteLine("Price : " + p.Price);
            Console.WriteLine("Stock : " + p.Stock);
        }

        // SEARCH PRODUCT

        Console.Write("\nEnter Product Name to Search : ");
        string search = Console.ReadLine();

        Product found = products.Find(x => x.ProductName.Equals(search, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine("\nProduct Found");
            Console.WriteLine("Product ID : " + found.ProductId);
            Console.WriteLine("Product Name : " + found.ProductName);
            Console.WriteLine("Price : " + found.Price);
            Console.WriteLine("Stock : " + found.Stock);
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }

       
        // CART

        List<CartItem> cart = new List<CartItem>();

        while (true)
        {
            Console.WriteLine("\nAvailable Products");

            foreach (Product p in products)
            {
                Console.WriteLine($"{p.ProductId} - {p.ProductName} - Rs.{p.Price} - Stock:{p.Stock}");
            }

            Console.Write("\nEnter Product ID : ");
            int pid = Convert.ToInt32(Console.ReadLine());

            Product product = products.Find(x => x.ProductId == pid);

            if (product == null)
            {
                Console.WriteLine("Invalid Product ID");
                continue;
            }

            Console.Write("Enter Quantity : ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (qty <= product.Stock)
            {
                product.Stock -= qty;

                cart.Add(new CartItem()
                {
                    ProductName = product.ProductName,
                    Quantity = qty,
                    Price = product.Price
                });

                Console.WriteLine("Added to Cart");
            }
            else
            {
                Console.WriteLine("Insufficient Stock");
            }

            Console.WriteLine("\nDo you want to add another product?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 2)
                break;
        }

        // DISPLAY CART

        Console.WriteLine("\n------CART------");

        double total = 0;

        foreach (CartItem item in cart)
        {
            Console.WriteLine(item.ProductName + " x" + item.Quantity);

            total += item.Price * item.Quantity;
        }

        // DISCOUNT
       
        double discount = 0;

        if (total >= 10000)
            discount = total * 0.30;
        else if (total >= 5000)
            discount = total * 0.20;
        else if (total >= 1000)
            discount = total * 0.10;

        double finalAmount = total - discount;

        Console.WriteLine("\n----- BILL -----");
        Console.WriteLine("Total Amount : " + total);
        Console.WriteLine("Discount : " + discount);
        Console.WriteLine("Final Amount : " + finalAmount);

       
        // PAYMENT
        

        Console.WriteLine("\nChoose Payment");
        Console.WriteLine("1. UPI");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. Debit Card");
        Console.WriteLine("4. Cash on Delivery");

        int payment = Convert.ToInt32(Console.ReadLine());

        switch (payment)
        {
            case 1:
                Console.WriteLine("Payment Successful using UPI");
                break;

            case 2:
                Console.WriteLine("Payment Successful using Credit Card");
                break;

            case 3:
                Console.WriteLine("Payment Successful using Debit Card");
                break;

            case 4:
                Console.WriteLine("Payment Successful using Cash on Delivery");
                break;

            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }
}