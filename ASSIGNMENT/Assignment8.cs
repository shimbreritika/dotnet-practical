using System;
using System.Collections.Generic;

class Vehicle
{
    public int VehicleId { get; set; }
    public string VehicleName { get; set; }
    public string VehicleType { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
    public int ManufacturingYear { get; set; }
}

class Program
{
    static List<Vehicle> vehicles = new List<Vehicle>();

    static void Main(string[] args)
    {
        Console.Write("Enter Employee Name: ");
        string employeeName = Console.ReadLine();

        Console.Write("Enter Employee ID: ");
        string employeeId = Console.ReadLine();

        Console.WriteLine("\nWelcome " + employeeName);

        int choice;

        do
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("TATA MOTORS");
            Console.WriteLine("Vehicle Management System");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. View All Vehicles");
            Console.WriteLine("3. Search Vehicle");
            Console.WriteLine("4. Update Vehicle Price");
            Console.WriteLine("5. Delete Vehicle");
            Console.WriteLine("6. Calculate Discount");
            Console.WriteLine("7. Show Vehicle Details");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Your Choice : ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddVehicle();
                    break;

                case 2:
                    ViewVehicles();
                    break;

                case 3:
                    SearchVehicle();
                    break;

                case 4:
                    UpdatePrice();
                    break;

                case 5:
                    DeleteVehicle();
                    break;

                case 6:
                    CalculateDiscount();
                    break;

                case 7:
                    ShowVehicleDetails();
                    break;

                case 8:
                    Console.WriteLine("\nThank You For Using TATA Motors System.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

        } while (choice != 8);
    }

    static void AddVehicle()
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

   static void ViewVehicles()
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

    static void SearchVehicle()
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

    static void UpdatePrice()
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

    static void DeleteVehicle()
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

    static void CalculateDiscount()
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

    static void ShowVehicleDetails()
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