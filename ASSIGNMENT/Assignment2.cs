using System;

class SmartCityLighting
{
    static void Main()
    {
        int power;
        int totalPower = 0;
        int maintenance = 0;
        int normal = 0;
        int efficient = 0;

        for (int light = 1; light <= 30; light++)
        {
            power = 80 + (light * 5);
            totalPower = totalPower + power;

            if (power > 180)
            {
                Console.WriteLine("Light " + light + " = " + power + " W - Maintenance Required");
                maintenance++;
            }
            else if (power >= 140 && power <= 180)
            {
                Console.WriteLine("Light " + light + " = " + power + " W - Normal Operation");
                normal++;
            }
            else
            {
                Console.WriteLine("Light " + light + " = " + power + " W - Energy Efficient");
                efficient++;
            }
        }

        double average = (double)totalPower / 30;

        Console.WriteLine();
        Console.WriteLine("Total Power Consumed = " + totalPower + " W");
        Console.WriteLine("Average Power Consumption = " + average + " W");
        Console.WriteLine("Maintenance Required = " + maintenance);
        Console.WriteLine("Normal Operation = " + normal);
        Console.WriteLine("Energy Efficient = " + efficient);
    }
}