using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAPI.Models
{
	public class Products
	{
		[Key]
		public int productId { get; set; }

		public string ProductName { get; set; }

		public string Price { get; set; }

		public int Quantity { get; set; }
	}
}
