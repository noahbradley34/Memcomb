using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Memcomb.Models
{
	public class SignUp
	{
		/*
		public int ID { get; set; }
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		public decimal Price { get; set; }*/

		public int ID { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone_Number { get; set; }
	}

	public class SignUpDBContext : DbContext
	{
		public DbSet<SignUp> Signees { get; set; }
	}
}