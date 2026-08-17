using System;

class Question2
{
    public static void Run()
    {
        int totalPower = 0;
        int maintenance = 0;
        int normalOperation = 0;
        int energyEfficient = 0;

        for (int lightNumber = 1; lightNumber <= 30; lightNumber++)
        {
            int power = 80 + (lightNumber * 5);

            Console.WriteLine("Light Number: " + lightNumber);
            Console.WriteLine("Power Consumption: " + power + " W");

            if (power > 180)
            {
                Console.WriteLine("Maintenance Required");
                maintenance++;
            }
            else if (power >= 140 && power <= 180)
            {
                Console.WriteLine("Normal Operation");
                normalOperation++;
            }
            else
            {
                Console.WriteLine("Energy Efficient");
                energyEfficient++;
            }

            totalPower += power;
        }

        double averagePower = (double)totalPower / 30;

        Console.WriteLine();
        Console.WriteLine("Total Power Consumed: " + totalPower + " W");
        Console.WriteLine("Average Power Consumption: " + averagePower + " W");
        Console.WriteLine("Maintenance Required: " + maintenance);
        Console.WriteLine("Normal Operation: " + normalOperation);
        Console.WriteLine("Energy Efficient: " + energyEfficient);
    }
}