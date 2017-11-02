namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {

            context.Friends.AddOrUpdate(
              f => f.FirstName,
              new Friend { FirstName = "Andrew Peters" },
              new Friend { FirstName = "Brice Lambson" },
              new Friend { FirstName = "Rowan Miller" }
            );
            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "Java" }
                );
            context.SaveChanges();
            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+46 12345678", FriendId = context.Friends.First().Id });

        }
    }
}
