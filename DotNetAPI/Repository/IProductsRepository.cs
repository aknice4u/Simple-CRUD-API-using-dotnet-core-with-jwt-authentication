using DotNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAPI.Repository
{
	public interface IProductsRepository
	{
		List<Products> GetAll();
		Products GetById(int id);
		void Insert(Products model);
		void Update(Products model);
		void Delete(object id);
	}
}
