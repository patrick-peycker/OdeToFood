using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
	public class SqlRestaurantData : IRestaurantData
	{
		private readonly OdeToFoodDbContext context;
		public SqlRestaurantData(OdeToFoodDbContext context)
		{
			this.context = context;
		}
		public void Add(Restaurant restaurant)
		{
			context.Restaurants.Add(restaurant);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var restaurant = context.Restaurants.Find(id);
			context.Restaurants.Remove(restaurant);
			context.SaveChanges();
		}

		public Restaurant Get(int id)
		{
			return context.Restaurants.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return context.Restaurants.OrderBy(r => r.Name);
		}

		public void Update(Restaurant restaurant)
		{
			var entry = context.Entry(restaurant);
			entry.State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
