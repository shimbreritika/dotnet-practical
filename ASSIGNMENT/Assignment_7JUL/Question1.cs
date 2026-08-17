using System;

class Question1
{
    public static void Run()
    {
        int qualityCheck = 0;
        int priorityShipment = 0;
        int normalProcessing = 0;

        for (int packageId = 1001; packageId <= 1020; packageId++)
        {
            Console.WriteLine("Package ID: " + packageId);

            if (packageId % 4 == 0)
            {
                Console.WriteLine("Quality Check Required");
                qualityCheck++;
            }
            else if (packageId % 5 == 0)
            {
                Console.WriteLine("Priority Shipment");
                priorityShipment++;
            }
            else
            {
                Console.WriteLine("Normal Processing");
                normalProcessing++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total packages processed: 20");
        Console.WriteLine("Quality Check: " + qualityCheck);
        Console.WriteLine("Priority Shipment: " + priorityShipment);
        Console.WriteLine("Normal Processing: " + normalProcessing);
    }
}