﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
	public class InMemoryRestaurantData : IRestaurantData
	{
		List<Restaurant> restaurants;
		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>()
			{
				new Restaurant { Id=1, Name = "Pizza", Cuisine=CuisineType.Italian},
				new Restaurant { Id=2, Name = "Tersiguels", Cuisine=CuisineType.French},
				new Restaurant { Id=3, Name = "Mango Grove", Cuisine=CuisineType.Indian}
			};
		}

		public void Add(Restaurant restaurant)
		{
			restaurant.Id = restaurants.Max(r => r.Id) + 1;
			restaurants.Add(restaurant);
		}

		public void Delete(int id)
		{
			var restaurant = Get(id);

			if(!(restaurant is null))
			{
				restaurants.Remove(restaurant);
			}
		}

		public Restaurant Get(int id)
		{
			return restaurants.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return restaurants.OrderBy(r => r.Name);
		}

		public void Update(Restaurant restaurant)
		{
			var existing = Get(restaurant.Id);

			if(existing != null)
			{
				existing.Name = restaurant.Name;
				existing.Cuisine = restaurant.Cuisine;
			}
		}

	}
}