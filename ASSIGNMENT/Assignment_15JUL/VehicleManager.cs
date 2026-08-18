using System;
using System.Collections.Generic;

public class VehicleManager
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle()
    {
        Vehicle v = new Vehicle();

        Console.Write("Enter Vehicle ID : ");
        v.VehicleId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Vehicle Name : ");
        v.VehicleName = Console.ReadLine();

        Console.Write("Enter Vehicle Type (Car/Bike/Truck) : ");
        v.VehicleType = Console.ReadLine();

        Console.Write("Enter Brand : ");
        v.Brand = Console.ReadLine();

        Console.Write("Enter Price : ");
        v.Price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Manufacturing Year : ");
        v.ManufacturingYear = Convert.ToInt32(Console.ReadLine());

        vehicles.Add(v);

        Console.WriteLine("Vehicle Added Successfully.");
    }

    public void ViewVehicles()
    {
        if (vehicles.Count == 0)
        {
            Console.WriteLine("No Vehicles Available.");
            return;
        }

        foreach (Vehicle v in vehicles)
        {
            Console.WriteLine("Vehicle ID : " + v.VehicleId);
            Console.WriteLine("Vehicle Name : " + v.VehicleName);
            Console.WriteLine("Brand : " + v.Brand);
            Console.WriteLine("Vehicle Type : " + v.VehicleType);
            Console.WriteLine("Price : " + v.Price);
            Console.WriteLine("Manufacturing Year : " + v.ManufacturingYear);
            Console.WriteLine("--------------------------------");
        }
    }

    public void SearchVehicle()
    {
        Console.Write("Enter Vehicle ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Vehicle v in vehicles)
        {
            if (v.VehicleId == id)
            {
                Console.WriteLine("\nVehicle Found");
                Console.WriteLine("Vehicle ID : " + v.VehicleId);
                Console.WriteLine("Vehicle Name : " + v.VehicleName);
                Console.WriteLine("Vehicle Type : " + v.VehicleType);
                Console.WriteLine("Brand : " + v.Brand);
                Console.WriteLine("Price : " + v.Price);
                Console.WriteLine("Manufacturing Year : " + v.ManufacturingYear);
                return;
            }
        }

        Console.WriteLine("Vehicle Not Found.");
    }

    public void UpdatePrice()
    {
        Console.Write("Enter Vehicle ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Vehicle v in vehicles)
        {
            if (v.VehicleId == id)
            {
                Console.Write("Enter New Price : ");
                v.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Price Updated Successfully.");
                return;
            }
        }

        Console.WriteLine("Vehicle ID Does Not Exist.");
    }

    public void DeleteVehicle()
    {
        Console.Write("Enter Vehicle ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].VehicleId == id)
            {
                vehicles.RemoveAt(i);

                Console.WriteLine("Vehicle Deleted Successfully.");
                return;
            }
        }

        Console.WriteLine("Vehicle Not Available.");
    }

    public void CalculateDiscount()
    {
        Console.Write("Enter Vehicle ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Vehicle v in vehicles)
        {
            if (v.VehicleId == id)
            {
                double discount = 0;

                switch (v.VehicleType.ToLower())
                {
                    case "car":
                        discount = v.Price * 0.10;
                        break;

                    case "bike":
                        discount = v.Price * 0.05;
                        break;

                    case "truck":
                        discount = v.Price * 0.12;
                        break;

                    default:
                        Console.WriteLine("Invalid Vehicle Type.");
                        return;
                }

                Console.WriteLine("Vehicle Price : " + v.Price);
                Console.WriteLine("Discount : " + discount);
                Console.WriteLine("Final Price : " + (v.Price - discount));

                return;
            }
        }

        Console.WriteLine("Vehicle Not Found.");
    }

    public void ShowVehicleDetails()
    {
        Console.Write("Enter Vehicle Type : ");
        string type = Console.ReadLine().ToLower();

        switch (type)
        {
            case "car":
                Console.WriteLine("Car is a four wheeler.");
                Console.WriteLine("Suitable for family.");
                break;

            case "bike":
                Console.WriteLine("Bike is fuel efficient.");
                Console.WriteLine("Suitable for city rides.");
                break;

            case "truck":
                Console.WriteLine("Truck is used for transportation.");
                Console.WriteLine("Heavy load vehicle.");
                break;

            default:
                Console.WriteLine("Invalid Vehicle Type.");
                break;
        }
    }
}