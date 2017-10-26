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
            context.Friends.AddOrUpdate(f => f.FirstName,
            new Friend { FirstName = "Kenopp", LastName = "Alic" },
            new Friend { FirstName = "Jacob", LastName = "Gan" },
            new Friend { FirstName = "Jacob", LastName = "Demo" },
            new Friend { FirstName = "Samwise", LastName = "Gamgi" }
            );
        }
    }
}
