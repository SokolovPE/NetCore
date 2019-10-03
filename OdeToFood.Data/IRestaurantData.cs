using OdeToFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine = CuisineType.Italian},
                new Restaurant{ Id = 2, Name = "Cinnamon Club", Location="London", Cuisine = CuisineType.Indian},
                new Restaurant{ Id = 3, Name = "La Costa", Location="California", Cuisine = CuisineType.Mexican}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            /*return from r in restaurants
                   orderby r.Name
                   select r;*/
            return restaurants.Where(n=>string.IsNullOrWhiteSpace(name) || n.Name.StartsWith(name)) .OrderBy(x => x.Name);
        }
    }
}
