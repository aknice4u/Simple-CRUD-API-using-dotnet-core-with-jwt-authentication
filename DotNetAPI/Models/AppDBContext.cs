using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Models
{
	public class AppDBContext:DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}
		public DbSet<User> userTable { get; set; }
		public DbSet<Products> Products { get; set; }
	}
}
