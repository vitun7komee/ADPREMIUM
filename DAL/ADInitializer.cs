using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTODEALERN.Model;

namespace AUTODEALERN.DAL
{  //CreateDatabaseIfNotExists // DropCreateDatabaseIfModelChanges
    class ADInitializer : System.Data.Entity.DropCreateDatabaseAlways<ADContext>
    {
        protected override void Seed(ADContext context)
        {
            
            List<Salesman> salesmen = new List<Salesman>
            {
                new Salesman { Name = "John Doe", Position = "Senior Sales Consultant", ContactInfo = "john@example.com" },
                new Salesman { Name = "Alice Smith", Position = "Sales Manager", ContactInfo = "alice@example.com" },
                new Salesman { Name = "Bob Johnson", Position = "Junior Sales Consultant", ContactInfo = "bob@example.com" },
                new Salesman { Name = "Emily Brown", Position = "Trainee Sales Consultant", ContactInfo = "emily@example.com" },
                new Salesman { Name = "Michael Wilson", Position = "Assistant Sales Consultant", ContactInfo = "michael@example.com" }
            };
            salesmen.ForEach(s => context.SalesmanDb.Add(s));

            List<Client> clients = new List<Client>
            {
                new Client { ClientNumber = 89011234567, Name = "Emma Johnson"},
                new Client { ClientNumber = 89159876543, Name = "Alexander Davis"},
                new Client { ClientNumber = 89035551234, Name = "Olivia White" },
                new Client { ClientNumber = 89258765432, Name = "Liam Robinson" },
                new Client { ClientNumber = 89103219876, Name = "Ava Thompson" }

            };
            clients.ForEach(s => context.ClientDb.Add(s));

            List<MenuItem> menuItems = new List<MenuItem> 
            {
                new MenuItem { Name = "Ford", Description = "Focus. 4602. ", Price = 700000, Category = "Sedan" },
                new MenuItem { Name = "Opel", Description = "Vivaro.", Price = 1000000, Category = "Sedan" },
                new MenuItem { Name = "Porsche", Description = "911", Price = 12000000, Category = "Sportscar" },
                new MenuItem { Name = "kia", Description = "Rio.", Price = 1200000, Category = "Sedan" },
                new MenuItem { Name = "Aston Martin", Description = "DBS", Price = 10000000, Category = "Sportscar" }

            };
            menuItems.ForEach(s => context.MenuItemDb.Add(s));
            base.Seed(context);
         
        }
       
    }
}
