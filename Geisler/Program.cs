using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geisler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdContext ctx = new ProdContext();

            while (true)
            {

                System.Console.WriteLine("Specify category name");
                String name = System.Console.ReadLine();
                Category cat = new Category();
                cat.Name = name;
                ctx.Categories.Add(cat);

                ctx.SaveChanges();

                System.Console.WriteLine("Available categories are:");
                foreach (Category c in ctx.Categories)
                {
                    System.Console.WriteLine("- " + c.Name);
                }
            }
        }
    }
}
