namespace TourOn.Migrations
{
	using Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using Microsoft.AspNet.Identity;

	internal sealed class Configuration : DbMigrationsConfiguration<TourOn.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

		}

        protected override void Seed(TourOn.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
			var passwordHash = new PasswordHasher();
			string password = passwordHash.HashPassword("Password@123");
			context.Users.AddOrUpdate(
			 p => p.UserName,
			 new ApplicationUser { Id = "00901eeb-5301-4eee-8b7b-b2775aaa569a", Name = "Music Box Supper Club", PasswordHash = password, Phone = "2162421250", Street = "1148 Main Ave", City = "Cleveland", State = "OH", PublicEmail = "info@musicboxcel.com", Email = "info@musicboxcel.com", UserName = "info@musicboxcel.com", Zip = 44113, Capacity = 500, AccountType = 2 },
			 new ApplicationUser { Id = "05dd9b23-c497-478a-a9fe-71d7f7f74f5d", Name = "Symposium Nightclub", PasswordHash = password, Phone = "8662576252", Street = "11794 Detroit Ave", City = "Lakewood", State = "OH", PublicEmail = "symposiumnightclub@facebook.com", Email = "symposiumnightclub@facebook.com", UserName = "symposiumnightclub@facebook.com", Zip = 44107, Capacity = 150, AccountType = 2 },
			 new ApplicationUser { Id = "13c2ca72-1375-4d8e-8dc9-db5b9c8bac02", Name = "The Outpost", PasswordHash = password, Phone = "3306789667", Street = "4962 Oh-43", City = "Kent", State = "OH", PublicEmail = "outpostkent@gmail.com", Email = "outpostkent@gmail.com", UserName = "outpostkent@gmail.com", Zip = 44240, Capacity = 300, AccountType = 2 },
			 new ApplicationUser { Id = "175dc7c4-5922-4edc-b40d-60ba6beb8000", Name = "Annabell's", PasswordHash = password, Phone = "3305351112", Street = "784 W. Market St", City = "Akron", State = "OH", PublicEmail = "annabellsakron@facebook.com", Email = "annabellsakron@facebook.com", UserName = "annabellsakron@facebook.com", Zip = 44303, Capacity = 200, AccountType = 2 },
			 new ApplicationUser { Id = "29ff475f-e94d-4738-8f0c-2d2482866a16", Name = "Grog Shop", PasswordHash = password, Phone = "2163215588", Street = "2785 Cleveland Heights Blvd", City = "Cleveland Heights", State = "OH", PublicEmail = "grogkat@gmail.com", Email = "grogkat@gmail.com", UserName = "grogkat@gmail.com", Zip = 44113, Capacity = 400, AccountType = 2 },
			 new ApplicationUser { Id = "2f8c3965-18db-4664-8a8e-dbcea3b67df7", Name = "Brother's Lounge", PasswordHash = password, Phone = "2162262767", Street = "11609 Detroit Ave", City = "Cleveland", State = "OH", PublicEmail = "info@brotherslounge.com", Email = "info@brotherslounge.com", UserName = "info@brotherslounge.com", Zip = 44107, Capacity = 300, AccountType = 2 },
			 new ApplicationUser { Id = "314d7d09-945e-4e9a-821e-a939a14a4ced", Name = "Pat's In the Flats", PasswordHash = password, Phone = "2166218044", Street = "2233 W 3rd St.", City = "Cleveland", State = "OH", PublicEmail = "PatsInTheFlats@Facebook.com", Email = "PatsInTheFlats@Facebook.com", UserName = "PatsInTheFlats@Facebook.com", Zip = 44113, Capacity = 300, AccountType = 2 },
			 new ApplicationUser { Id = "3adeb608-a2a6-48aa-b495-7f1a4ae49355", Name = "Musica", PasswordHash = password, Phone = "3303741114", Street = "51 E. Market St", City = "Akron", State = "OH", PublicEmail = "LiveatMusica@gmail.com", Email = "LiveatMusica@gmail.com", UserName = "LiveatMusica@gmail.com", Zip = 44308, Capacity = 350, AccountType = 2 },
			 new ApplicationUser { Id = "430d2cd5-d7df-4d0e-bfe5-97ea2e07fb12", Name = "The Phantasy Concert Club", PasswordHash = password, Phone = "4405084621", Street = "11802 Detroit Ave", City = "Lakewood", State = "OH", PublicEmail = "phantnightclub@facebook.com", Email = "phantnightclub@facebook.com", UserName = "phantnightclub@facebook.com", Zip = 44107, Capacity = 500, AccountType = 2 },
			 new ApplicationUser { Id = "590b7de5-91a9-46bb-9805-bd7f736ab156", Name = "Now That's Class", PasswordHash = password, Phone = "2162218576", Street = "11213 Detroit Ave.", City = "Cleveland", State = "OH", PublicEmail = "ntc11213@gmail.com", Email = "ntc11213@gmail.com", UserName = "ntc11213@gmail.com", Zip = 44102, Capacity = 150, AccountType = 2 },
			 new ApplicationUser { Id = "7a8e86ab-e8fc-45c1-8c4c-ec1a01c09799", Name = "Beachland Ballroom and Tavern", PasswordHash = password, Phone = "2163831124", Street = "15711 Waterloo Rd", City = "Cleveland", State = "OH", PublicEmail = "jamesbeachlandbooking@gmail.com", Email = "jamesbeachlandbooking@gmail.com", UserName = "jamesbeachlandbooking@gmail.com", Zip = 44110, Capacity = 500, AccountType = 2 },
			 new ApplicationUser { Id = "90b7952c-cc57-4748-9293-73163015c13a", Name = "Cleveland Agora Ballroom", PasswordHash = password, Phone = "2168812221", Street = "5000 Euclid Ave #101", City = "Cleveland", State = "OH", PublicEmail = "bundy@agoracleveland.com", Email = "bundy@agoracleveland.com", UserName = "bundy@agoracleveland.com", Zip = 44103, Capacity = 150, AccountType = 2 },
			 new ApplicationUser { Id = "941f2a8b-721a-4165-8c36-0249f881c881", Name = "The Foundry Concert Club", PasswordHash = password, Phone = "4406375483", Street = "11729 Detroit Ave", City = "Lakewood", State = "OH", PublicEmail = "BillZ.Foundry@gmail.com", Email = "BillZ.Foundry@gmail.com", UserName = "BillZ.Foundry@gmail.com", Zip = 44107, Capacity = 200, AccountType = 2 },
			 new ApplicationUser { Id = "e54a82eb-2673-465d-baac-33a6bb574ffe", Name = "The Happy Dog", PasswordHash = password, Phone = "2166519474", Street = "5801 Detroit Ave", City = "Cleveland", State = "OH", PublicEmail = "HappydogBook@gmail.com", Email = "HappydogBook@gmail.com", UserName = "HappydogBook@gmail.com", Zip = 44102, Capacity = 150, AccountType = 2 },
			 new ApplicationUser { Id = "ec60f531-c7df-4326-b7e2-d6d4bd75010c", Name = "Mahall's 20 Lanes", PasswordHash = password, Phone = "2165213280", Street = "13200 Madison Ave", City = "Lakewood", State = "OH", PublicEmail = "info@mahalls20lanes.com", Email = "info@mahalls20lanes.com", UserName = "info@mahalls20lanes.com", Zip = 44107, Capacity = 250, AccountType = 2 }
		   );
		}
    }
}
