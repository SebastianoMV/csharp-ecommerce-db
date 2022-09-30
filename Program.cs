// See https://aka.ms/new-console-template for more information
using csharp_ecommerce_db;

using (Ecommerce db = new Ecommerce())
{
    Console.WriteLine("Vuoi generare valori di default? \n 1.si \n 2.no");
    if(Int32.Parse(Console.ReadLine()!) == 1){
        Default();
    }

    Console.WriteLine("vuoi visualizzare tutti i prodotti? \n 1.si \n 2.no");
    if (Int32.Parse(Console.ReadLine()!) == 1)
    {
        List<Product> list = db.Products.ToList();
        foreach (Product p in list)
        {
            Console.WriteLine(p.Name + " " + p.prince);
        }
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