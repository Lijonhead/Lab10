using Lab10;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindContext()) 
            {
                int choice;
                do
                {
                    Console.WriteLine("Northwind Database Menu:");
                    Console.WriteLine("1. Get all customers");
                    Console.WriteLine("2. Select a customer and view their orders");
                    Console.WriteLine("3. Add a customer");
                    Console.WriteLine("4. Exit");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                GetCustomers(context);
                                break;
                            case 2:
                                ViewCustomerAndOrders(context);
                                break;
                            case 3:
                                AddCustomer(context);
                                break;
                            case 4:
                                Console.WriteLine("Exiting program.");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                } while (choice != 4);
            }
        }
        static void GetCustomers(NorthwindContext context)
        {
            Console.WriteLine("Sort by company name (1. Ascending / 2. Descending):");
            int sortChoice = Convert.ToInt32(Console.ReadLine());

            if (true)
            {
                switch (sortChoice) 
                {
                    case 1:
                        context.Customers.OrderBy(c => c.CompanyName);
                            break;

                    case 2:
                        context.Customers.OrderByDescending(c => c.CompanyName);
                        break;


                }
                var customers = context.Customers.Include(c => c.Orders);
                
                foreach (var customer in customers)
                {
                    
                    
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Country: {customer.Country}");
                    Console.WriteLine($"Region: {customer.Region ?? "null"}");
                    Console.WriteLine($"Phone Number: {customer.Phone}");
                    Console.WriteLine($"Number of Orders: {customer.Orders.Count()}");
                    Console.WriteLine();
                    
                }
            }
            
        }
        static void ViewCustomerAndOrders(NorthwindContext context)
        {
            Console.Write("Enter Company Name: ");
            string companyName = Console.ReadLine();

            var customer = context.Customers
                .Include(c => c.Orders)
                .SingleOrDefault(c => c.CompanyName == companyName);

            if (customer != null)
            {
                
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine($"Region: {customer.Region ?? "null"}");
                Console.WriteLine($"Phone Number: {customer.Phone}");
                Console.WriteLine("Orders:");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($" Order ID: {order.OrderId}, Order Date: {order.OrderDate} ");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        static void AddCustomer(NorthwindContext context)
        {
            Console.Write("Enter Company Name: ");
            string companyName = Console.ReadLine();
            Console.Write("Enter Country: ");
            string country = Console.ReadLine();
            Console.Write("Enter Region: ");
            string region = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Contact Name: ");
            string contactName = Console.ReadLine();
            Console.Write("Enter Contact title: ");
            string contactTitle = Console.ReadLine();
            Console.Write("Enter Adress: ");
            string adress = Console.ReadLine();
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            Console.Write("Enter postal code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter Fax: ");
            string fax = Console.ReadLine();


            var newCustomer = new Customer
            {
                CustomerId = GenerateRandomString(5),
                CompanyName = string.IsNullOrWhiteSpace(region) ? null : companyName,
                ContactName = string.IsNullOrWhiteSpace(region) ? null : contactName,
                ContactTitle = string.IsNullOrWhiteSpace(region) ? null : contactTitle,
                Address = string.IsNullOrWhiteSpace(region) ? null : adress,
                City = string.IsNullOrWhiteSpace(region) ? null : city,
                PostalCode = string.IsNullOrWhiteSpace(region) ? null : postalCode,
                Fax = string.IsNullOrWhiteSpace(region) ? null : fax,
                Country = string.IsNullOrWhiteSpace(region) ? null : country,
                Region = string.IsNullOrWhiteSpace(region) ? null : region,
                Phone = string.IsNullOrWhiteSpace(region) ? null : phone
            };

            context.Customers.Add(newCustomer);
            context.SaveChanges();
            Console.WriteLine("Customer added successfully.");
        }

        static string GenerateRandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
