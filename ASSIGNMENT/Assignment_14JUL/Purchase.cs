using System;

public class Purchase : IBill
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

        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("              BILL");
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