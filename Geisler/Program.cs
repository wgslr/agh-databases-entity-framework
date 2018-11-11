using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geisler
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ProdContext ctx = new ProdContext();

            //System.Console.WriteLine("Products:");
            //foreach (Product p in ctx.Products)
            //{
            //    ctx.Entry(p).Reference(pr => pr.Category).Load();
            //    if (null != p.Category)
            //    {
            //        System.Console.WriteLine("{0} {1} in cat {2}", p.productId, p.Name, p.Category.Name);
            //    }
            //    else
            //    {
            //        System.Console.WriteLine("{0} {1} without category", p.productId, p.Name, p.Category.Name);
            //    }

            //}


            //System.Console.WriteLine("Specify category name");
            //String name = System.Console.ReadLine();
            //Category cat = new Category();
            //cat.Name = name;
            //ctx.Categories.Add(cat);

            //ctx.SaveChanges();

            //System.Console.WriteLine("Available categories are:");
            //foreach (Category c in ctx.Categories)
            //{
            //    System.Console.WriteLine("- " + c.Name);
            //}

            CategoryForm f = new CategoryForm();
            f.ShowDialog();
        }
    }
}
