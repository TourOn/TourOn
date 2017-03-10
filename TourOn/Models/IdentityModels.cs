﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourOn.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}


		
	
		public string Region { get; set; }

		[Required]
		public string Name { get; set; }

		
		public string Description { get; set; }

		//links genre to application user

		public string Genre { get; set; }

		[Required]
		[Phone]
		public string Phone { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string State { get; set; }

		[Required]
		[EmailAddress]
		public string PublicEmail { get; set; }

		//other websites
		public string OtherContacts { get; set; }

		//links comments and pictures to application user
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Picture> Pictures { get; set; }

		//determines account type
		public byte AccountType { get; set; }
		
		public static readonly byte AdminAccountType = 0;
		public static readonly byte BandAccountType = 1;
		public static readonly byte VenueAccountType = 2;
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public System.Data.Entity.DbSet<TourOn.Models.Genre> Genres { get; set; }

		public System.Data.Entity.DbSet<TourOn.Models.Region> Regions { get; set; }
	}
}