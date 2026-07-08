using System;

class PackageProcessing
{
    static void Main()
    {
        int total = 0;
        int quality = 0;
        int priority = 0;
        int normal = 0;

        for (int id = 1001; id <= 1020; id++)
        {
            total++;

            if (id % 4 == 0)
            {
                Console.WriteLine(id + " - Quality Check Required");
                quality++;
            }
            else if (id % 5 == 0)
            {
                Console.WriteLine(id + " - Priority Shipment");
                priority++;
            }
            else
            {
                Console.WriteLine(id + " - Normal Processing");
                normal++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total Packages = " + total);
        Console.WriteLine("Quality Check = " + quality);
        Console.WriteLine("Priority Shipment = " + priority);
        Console.WriteLine("Normal Packages = " + normal);
    }
}