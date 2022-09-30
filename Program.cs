// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;
using System.Runtime.InteropServices;

using (Ecommerce db = new Ecommerce())
{
    Console.WriteLine("Vuoi generare valori di default? \n 1.si \n 2.no");
    if(Int32.Parse(Console.ReadLine()!) == 1){
        Default();
    }

    Console.WriteLine("Vuoi Registrarti? \n 1.si \n 2.no");
    if (Int32.Parse(Console.ReadLine()!) == 1)
    {
        Console.WriteLine("Inserisci nome");
        string newName = Console.ReadLine();

        Console.WriteLine("Inserisci cognome");
        string newSurname = Console.ReadLine();

        Console.WriteLine("Inserisci Email");
        string newEmail = Console.ReadLine();

        Customer customer = new Customer { Name = newName, Surname = newSurname, Email = newEmail };
        db.Add(customer);
        db.SaveChanges();

        Console.WriteLine("vuoi visualizzare tutti i prodotti? \n 1.si \n 2.no");
        if (Int32.Parse(Console.ReadLine()!) == 1)
        {
            Console.WriteLine("Che prodotto vuoi acquistare?");
            List<Product> list = db.Products.ToList();
            foreach (Product p in list)
            {
                Console.WriteLine(p.ProductId +". " + p.Name + " " + p.prince);
            }
        }
        bool flag = true;
        Order order = new();
        while (flag)
        {
            
            int scelta = Int32.Parse(Console.ReadLine());
            Product p = FindProduct(scelta);
            order.ListProducts.Add(p);
            order.Amount += (float)p.prince;
            Console.WriteLine("Vuoi comprare altro? \n 1.si \n 2.no");
            if (Int32.Parse(Console.ReadLine()!) != 1)
            {
                flag = false;
            }

        }
        order.Status = true;
        order.CustomerId = customer.CustomerId;
        order.EmployeeId = 1;
        
        db.Add(order);
        db.SaveChanges();
    }


    Product FindProduct(int id)
    {
        Product product = db.Products.Where(product => product.ProductId == id ).First();
        return product;
    }

    void Default()
    {
        Customer customer = new Customer { Name = "Pippo", Surname = "Pippi", Email = "ppp@gmail.com" };
        db.Add(customer);
        db.SaveChanges();
        Customer customer1 = new Customer { Name = "Ugo", Surname = "DeUghi", Email = "ppp@gmail.com" };
        db.Add(customer1);
        db.SaveChanges();

        Product prodotto1 = new Product { Name = "Shampo", description = "Shampo ala camomilla", prince = 3.5 };
        db.Add(prodotto1);
        db.SaveChanges();
        Product prodotto2 = new Product { Name = "Balsamo", description = "Balsamo capelli lisci", prince = 4 };
        db.Add(prodotto2);
        db.SaveChanges();

        Employee employee1 = new Employee { Name = "Gino", Surname = "Gigini", level = 3 };
        db.Add(employee1);
        db.SaveChanges();
        Employee employee2 = new Employee { Name = "Gina", Surname = "Gigina", level = 2 };
        db.Add(employee2);
        db.SaveChanges();

    }
}