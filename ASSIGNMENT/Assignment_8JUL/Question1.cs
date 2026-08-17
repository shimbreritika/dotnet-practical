using System;

class Array1
{
    public static void Run()
    {
        int[] sales = { 25000, 32000, 28000, 40000, 35000, 30000 };

        int total = 0;
        int lowest = sales[0];
        int highest = sales[0];

        foreach (int s in sales)
        {
            Console.WriteLine(s);

            total += s;

            if (s < lowest)
                lowest = s;

            if (s > highest)
                highest = s;
        }

        double average = (double)total / sales.Length;

        Console.WriteLine("Total = " + total);
        Console.WriteLine("Average = " + average);
        Console.WriteLine("Highest = " + highest);
        Console.WriteLine("Lowest = " + lowest);
    }
}