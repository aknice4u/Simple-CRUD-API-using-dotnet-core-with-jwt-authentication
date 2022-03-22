using DotNetAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAPI.Repository
{
	public class ProductRepository : IProductsRepository
	{
		private AppDBContext _pr;
		public ProductRepository(AppDBContext pr)
		{
			_pr = pr;
		}

		public void Delete(object id)
		{
			var existing = _pr.Products.Find(id);
			_pr.Remove(existing);
			_pr.SaveChanges();
		}

		public List<Products> GetAll()
		{
			return _pr.Products.ToList();
		}

		public Products GetById(int id)
		{
			if (id == 0)
				return null;
			return _pr.Products.Find(id);
		}

		public void Insert(Products model)
		{
			try
			{

				_pr.Add(model);
				_pr.SaveChanges();


			}
			catch
			{

			}
		}

		public void Update(Products model)
		{
			_pr.Attach(model);
			_pr.Entry(model).State = EntityState.Modified;
			_pr.SaveChanges();
		}
	}
}

